using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] float DistanceToPursuitPlayer;

    MovementState state;
    Rigidbody2D rb;

    void Start()
    {
        state = MovementState.None;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        SearchPlayer();
        Move();
    }

    void SearchPlayer()
    {
        if(CheckForPlayer(-Vector2.right))
            state = MovementState.Left;
        else if(CheckForPlayer(Vector2.right))
            state = MovementState.Right;
        else
            state = MovementState.None;
    }

    bool CheckForPlayer(Vector2 direction)
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(direction) * DistanceToPursuitPlayer, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(direction), DistanceToPursuitPlayer);

        return hit.collider != null && hit.collider.gameObject.tag == "Player";
    }

    void Move()
    {
        float move = 0;

        switch(state)
        {
            case MovementState.Left:
                move = -1;
            break;

            case MovementState.Right:
                move = 1;
            break;
        }

        move = move * MovementSpeed * Time.fixedDeltaTime;
        Vector3 targetVelocity = new Vector2(move, rb.velocity.y);
        rb.velocity = targetVelocity;
    }
}

public enum MovementState
{
    Left = 0,
    None,
    Right
}
