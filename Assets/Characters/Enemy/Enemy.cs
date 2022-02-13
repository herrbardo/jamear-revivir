using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    [SerializeField] float MovementSpeed;

    MovementState state;
    Rigidbody2D rb;
    bool facingRight;
    Animator animator;


    void Start()
    {
        state = MovementState.None;
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Destroy(gameObject);
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
        
        animator.SetBool("IsWalking", move != 0);
        move = move * MovementSpeed * Time.fixedDeltaTime;
        Vector3 targetVelocity = new Vector2(move, rb.velocity.y);
        rb.velocity = targetVelocity;
    }

    private void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    public void MoveLeft()
    {
        state = MovementState.Left;
        if(facingRight)
        {
            facingRight = false;
            Flip();
        }
    }

    public void MoveRight()
    {
        state = MovementState.Right;
        if(!facingRight)
        {
            facingRight = true;
            Flip();
        }
    }

    public void Stop()
    {
        state = MovementState.None;
    }
}

public enum MovementState
{
    Left = 0,
    None,
    Right
}
