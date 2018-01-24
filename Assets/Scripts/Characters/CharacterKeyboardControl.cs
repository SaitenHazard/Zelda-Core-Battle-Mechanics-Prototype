using UnityEngine;
using System.Collections;

public class CharacterKeyboardControl : CharacterBaseControl 
{
    void Start() 
    {
        SetDirection( new Vector2( 0, -1 ) );
    }

    void Update() 
    {
        UpdateDirection();
        UpdateAction();
        UpdateAttack();
        UpdateDrop();
        UpdateAddToInventory();
    }

    void UpdateAttack()
    {
        if( Input.GetKeyDown( KeyCode.D ) )
        {
            OnAttackPressed();
        }
    }

    void UpdateAddToInventory()
    {
        if ( Input.GetKeyDown( KeyCode.W))
        {
            InventoryAction();
        }
    }

    void UpdateAction()
    {
        if( Input.GetKeyDown( KeyCode.S ) )
        {
            OnActionPressed();
        }
    }

    void UpdateDrop()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Drop();
        }
    }

    void UpdateDirection()
    {
        Vector2 newDirection = Vector2.zero;

        if( Input.GetKey( KeyCode.UpArrow ) )
        {
            newDirection.y = 1;
        }

        if( Input.GetKey( KeyCode.DownArrow ) )
        {
            newDirection.y = -1;
        }

        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            newDirection.x = -1;
        }

        if( Input.GetKey( KeyCode.RightArrow ) )
        {
            newDirection.x = 1;
        }

        SetDirection( newDirection );
    }
}
