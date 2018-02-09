using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy1AI : MonoBehaviour
{
    private StateMachine stateMachine = new StateMachine();

    private LayerMask foodItemsLayer;

    private float viewRange;
    private string foodItemTag;

    private void Start()
    {
        stateMachine.ChangeState();

        stateMachine.ChangeState();
    }
}
