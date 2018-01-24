using UnityEngine;
using System.Collections;

public class InteractablePickup : InteractableBase
{
    public float ThrowDistance = 5;
    public float ThrowSpeed = 6;
    public float DropDistance = 2;
    public float DropSpeed = 12;

    Vector3 m_CharacterThrowPosition;
    Vector3 m_ThrowDirection;

    public override void OnInteract( Character character )
    {
        CharacterInteractionModel interactionModel = character.GetComponent<CharacterInteractionModel>();

        if( interactionModel == null )
        {
            return;
        }

        BroadcastMessage( "OnPickupObject", character, SendMessageOptions.RequireReceiver );

        interactionModel.PickupObject( this );
    }

    public void Throw( Character character, bool dropped )
    {
        if (dropped == true)
            StartCoroutine(ThrowRoutine(character.transform.position, character.Movement.GetFacingDirection(), DropDistance, DropSpeed, dropped));

        else
            StartCoroutine(ThrowRoutine( character.transform.position, character.Movement.GetFacingDirection(), ThrowDistance, ThrowSpeed, dropped) );
    }

    IEnumerator ThrowRoutine( Vector3 characterThrowPosition, Vector3 throwDirection, float distance, float speed, bool dropped )
    {
        transform.parent = null;

        Vector3 targetPosition = characterThrowPosition + throwDirection.normalized * distance;

        while ( transform.position != targetPosition )
        {
            transform.position = Vector3.MoveTowards( transform.position, targetPosition, speed * Time.deltaTime );
            yield return null;
        }

        if (dropped == false)
            BroadcastMessage( "OnObjectThrown", SendMessageOptions.RequireReceiver );
    }
}
