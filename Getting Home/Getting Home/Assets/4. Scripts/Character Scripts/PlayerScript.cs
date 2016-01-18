﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour 
{
	public float speed;													//The player's speed. Don't hardcode it in here, change it in the inspector.
	float gravity = 20f;												//The gravity, this'll ground the player. Try to leave it at the hardcoded default.
	private Vector3 moveDir;											//The direction of movement
	private FacingDirection facingDir;									//The direction the PC is currently facing. The base value is facing upwards, make sure to change it if the player is facing in a different direction at the start of a level.
	public Transform myTrans;											//The transform of the PC.
	 CharacterController controller; 
//	public List<GameObject> pickedUpObject = new List<GameObject>();

	PickupScript pickupScript;
	PickupScript currentHeldItem;

	//This enum will give a list of directions the player can face. Ensure you update it each time the player changes their direction of movement. 
	//It's a good idea to keep track of it for animations/interactions/etc...
	public enum FacingDirection
	{
		Up,
		Down,
		Left,
		Right
	}

	void Start()
	{
		controller = GetComponent<CharacterController>();
		pickupScript = GetComponent<PickupScript>();
		myTrans = transform;
	}

	void Update()
	{
		moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		moveDir = transform.TransformDirection(moveDir);
		moveDir *= speed;
		
//		moveDir.x -= gravity * Time.deltaTime;
		controller.Move(moveDir * Time.deltaTime);
		myTrans.position = new Vector3 (myTrans.position.x, myTrans.position.y, 0);

		if( Input.GetButtonDown("pickup") && pickupScript != null) //the E key, it's pre-set in the input manager so can be changed by players on launch
		{
			if(currentHeldItem != null)
			{
				pickupScript.Drop();
			}
			else
			{
				pickupScript.Pickup(transform);
				currentHeldItem = pickupScript;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//call universal triggers here, don't put level-specific ones, probably best to create a seperate script for that (Aidan 11/10/15)
		if (other.tag == "NPC")
		{
			Debug.Log ("NPC detected you");
		}

		if (other.tag == "Tree")
		{
			Debug.Log(other.tag);
			return;
		}

		if (other.tag == "pickup") {
			pickupScript = other.GetComponent<PickupScript>();
			Debug.Log (other.tag);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "NPC")
		{
			Debug.Log ("NPC no longer sees you");
		}
	}
}
