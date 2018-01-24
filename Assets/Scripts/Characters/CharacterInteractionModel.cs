using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Character))]
public class CharacterInteractionModel : MonoBehaviour
{
    private CharacterPocketModel m_PocketModel;
    private Character m_Character;
    private Collider2D m_Collider;
    private CharacterMovementModel m_MovementModel;
    private InteractablePickup m_PickedUpObject;
    private PocketBase pocketItem;
    private string m_pickupDefaultLayer;

    void Awake()
    {
        m_Character = GetComponent<Character>();
        m_Collider = GetComponent<Collider2D>();
        m_MovementModel = GetComponent<CharacterMovementModel>();
        m_PocketModel = GetComponent<CharacterPocketModel>();
    }

    public void OnInteract()
    {
        if (m_MovementModel.getIsCarrying() == true)
        {
            ThrowCarryingObject(false);
            return;
        }

        InteractableBase usableInteractable = FindUsableInteractable();

        if (usableInteractable == null)
        {
            return;
        }

        usableInteractable.OnInteract(m_Character);
    }

    public void InventoryAction()
    {
        if (m_MovementModel.getIsCarrying() == true)
        {
            pocketItem = m_PickedUpObject.GetComponent<PocketBase>();

            if(pocketItem == null)
            {
                return;
            }

            m_PocketModel.AddItem(pocketItem.getType());
            Destroy(m_PickedUpObject.gameObject);
            SetUncarry();
        }
        else
        {
            return;
        }
    }

    private void SetUncarry()
    {
        m_PickedUpObject = null;
        m_MovementModel.SetIsAbleToAttack(true);
        m_MovementModel.setCarrying(false);
    }

    public void DropPickUp()
    {
        if (m_MovementModel.getIsCarrying() == true)
        {
            ThrowCarryingObject(true);
            return;
        }
        else
        {
            Debug.Log("Error: No held item");
        }
    }

    public Collider2D[] GetCloseColliders()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        return Physics2D.OverlapAreaAll(
            (Vector2)transform.position + boxCollider.offset + boxCollider.size * 0.6f,
            (Vector2)transform.position + boxCollider.offset - boxCollider.size * 0.6f);
    }

    public InteractableBase FindUsableInteractable()
    {
        Collider2D[] closeColliders = GetCloseColliders();

        InteractableBase closestInteractable = null;
        float angleToClosestInteractble = Mathf.Infinity;

        for (int i = 0; i < closeColliders.Length; ++i)
        {
            InteractableBase colliderInteractable = closeColliders[i].GetComponent<InteractableBase>();

            if (colliderInteractable == null)
            {
                continue;
            }

            Vector3 directionToInteractble = closeColliders[i].transform.position - transform.position;

            float angleToInteractable = Vector3.Angle(m_MovementModel.GetFacingDirection(), directionToInteractble);

            if (angleToInteractable < 40)
            {
                if (angleToInteractable < angleToClosestInteractble)
                {
                    closestInteractable = colliderInteractable;
                    angleToClosestInteractble = angleToInteractable;
                }
            }
        }

        return closestInteractable;
    }

    public void PickupObject(InteractablePickup pickupObject)
    {
        m_PickedUpObject = pickupObject;

        m_MovementModel.setCarrying(true);

        m_PickedUpObject.transform.parent = m_MovementModel.PickupItemParent;
        m_PickedUpObject.transform.localPosition = Vector3.zero;

        //m_MovementModel.SetFrozen( true, false, false );
        m_MovementModel.SetIsAbleToAttack(false);

        SetLayer(pickupObject.transform, "Characters");

        Collider2D pickupObjectCollider = pickupObject.GetComponent<Collider2D>();

        if (pickupObjectCollider != null)
        {
            pickupObjectCollider.enabled = false;
        }
    }

    public void ThrowCarryingObject(bool dropped)
    {
        Collider2D pickupObjectCollider = m_PickedUpObject.GetComponent<Collider2D>();

        if (pickupObjectCollider != null)
        {
            pickupObjectCollider.enabled = true;
            Physics2D.IgnoreCollision(m_Collider, pickupObjectCollider);
        }

        m_PickedUpObject.Throw(m_Character, dropped);

        if (dropped == true)
            StartCoroutine(SetLayer(m_PickedUpObject.transform, "Default", 1f));

        //m_MovementModel.SetFrozen( false, false, false );
        Physics2D.IgnoreCollision(m_Collider, pickupObjectCollider, false);
        SetUncarry();
    }

    IEnumerator SetLayer(Transform transform, string layerName, float delay)
    {
        yield return new WaitForSeconds(delay);

        Helper.SetSortingLayerForAllRenderers(transform, layerName);
    }

    private void SetLayer(Transform transform, string layerName)
    {
        Helper.SetSortingLayerForAllRenderers(transform, layerName);
    }

    public bool IsCarryingObject()
    {
        return m_PickedUpObject != null;
    }
}
