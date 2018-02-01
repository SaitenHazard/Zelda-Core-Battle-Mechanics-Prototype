using UnityEngine;
using System.Collections;

public class CharacterBaseControl : MonoBehaviour
{
    protected CharacterMovementModel m_MovementModel;
    protected CharacterInteractionModel m_InteractionModel;
    protected CharacterMovementView m_MovementView;
    protected CharacterPocketModel m_pocketModel;

    void Awake()
    {
        m_MovementModel = GetComponent<CharacterMovementModel>();
        m_MovementView = GetComponent<CharacterMovementView>();
        m_InteractionModel = GetComponent<CharacterInteractionModel>();
        m_pocketModel = GetComponent<CharacterPocketModel>();
    }

    protected Vector2 GetDiagonalizedDirection( Vector2 direction, float threshold )
    {
        if( Mathf.Abs( direction.x ) < threshold )
        {
            direction.x = 0;
        }
        else
        {
            direction.x = Mathf.Sign( direction.x );
        }

        if( Mathf.Abs( direction.y ) < threshold )
        {
            direction.y = 0;
        }
        else
        {
            direction.y = Mathf.Sign( direction.y );
        }

        return direction;
    }

    protected void InventoryAction()
    {
        m_InteractionModel.InventoryAction();
    }

    protected void SetDirection( Vector2 direction )
    {
        if( m_MovementModel == null )
        {
            return;
        }

        m_MovementModel.SetDirection( direction );
    }

    protected void Drop()
    {
        m_InteractionModel.DropPickUp();
    }

    protected void selectSlotBackward()
    {
        m_pocketModel.changeSelectedSlotID(false);
    }

    protected void selectSlotForward()
    {
        m_pocketModel.changeSelectedSlotID(true);
    }

    protected void OnActionPressed()
    {
        if( m_InteractionModel == null )
        {
            return;
        }

        m_InteractionModel.OnInteract();
    }

    protected void OnAttackPressed()
    {
        if( m_MovementModel == null )
        {
            return;
        }

        if( m_MovementModel.CanAttack() == false )
        {
            return;
        }

        m_MovementModel.DoAttack();
        m_MovementView.DoAttack();
    }
}
