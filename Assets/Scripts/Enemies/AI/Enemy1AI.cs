using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy1AI : CharacterBaseControl
{
    private StateMachine stateMachine = new StateMachine();

    public float followRadius;
    public float turnRadius;
    public float turnSpeed;
    public float followSpeed;
    public GameObject player; 
    
    private CircleCollider2D followCollider;
    private CircleCollider2D turnColllider;
    private BoxCollider2D playerCollider;

    private void Awake()
    {
        createColliderComponents(followRadius, turnRadius);
    }

    private void Start()
    {
        playerCollider = player.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (turnColllider.IsTouching(playerCollider))
        {
            stateMachine.ChangeState(new StateRotate(player, gameObject.GetComponent<CharacterBaseControl>));
            return;
        }

        if(playerCollider.IsTouching(playerCollider))
        {
            stateMachine.ChangeState(new StateFollowPlayer());
            return;
        }
    }

    private Vector2 getPlayerVector()
    {
        Vector3 playerPosition = player.transform.position;

        Vector2 newVector;

        newVector.x = playerPosition.x;
        newVector.y = playerPosition.y;

        return newVector;
    }

    private void createColliderComponents(float followRadius, float turnRadious)
    {
        followCollider = gameObject.AddComponent<CircleCollider2D>();
        followCollider.radius = followRadius;

        turnColllider = gameObject.AddComponent<CircleCollider2D>();
        turnColllider.radius = turnRadious;
    }
}
