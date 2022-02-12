using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed = 4f;

    public Rigidbody2D rb;
    Vector2 movement;
    public Transform pointer;
    public GameObject bala;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
       
        if (Input.GetButton("Fire1")) //click izquierdo o barra espaciadora salvo que se cambie
        {
            Instantiate(bala, pointer.position, pointer.rotation); 
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }
   
}
