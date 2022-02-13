using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

	}

	void FixedUpdate ()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}