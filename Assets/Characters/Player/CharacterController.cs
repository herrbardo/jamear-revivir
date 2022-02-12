using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float Speed = 4f;
    [SerializeField] float JumpForce;

    Rigidbody2D rb;
    Vector2 movement;
    public Transform pointer;
    public GameObject bala;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Shoot();
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") /*&& Mathf.Abs(rb.velicity.y < .001f)*/)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    void Shoot()
    {
        if (Input.GetButton("Fire1")) //click izquierdo o barra espaciadora salvo que se cambie
            Instantiate(bala, pointer.position, pointer.rotation); 
    }
}
