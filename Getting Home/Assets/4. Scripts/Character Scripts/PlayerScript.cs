using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour 
{
	public float speed = 2;												//The player's speed.
	float gravity = 20f;												//The gravity, this'll ground the player. Try to leave it at the hardcoded default.
	private Vector3 moveDir;											//The direction of movement
	private Vector2 velocity;											//The velocity of movement
	private FacingDirection facingDir;									//The direction the PC is currently facing. The base value is facing upwards, make sure to change it if the player is facing in a different direction at the start of a level.
	public Transform myTrans;											//The transform of the PC.
	CharacterController controller; 
	Rigidbody2D myBody;

	SpriteRenderer spriteRenderer;
	public Sprite spriteUp;
	public Sprite spriteDown;
	public Sprite spriteRight;
	public Sprite spriteLeft;
	public string lastHeldItem;
	//	public List<GameObject> pickedUpObject = new List<GameObject>();
	
	PickupScript pickupScript;
	public string currentHeldItem;

	public bool[] npcsTalkedTo; // This variable is to keep track of who you have already talked to. The numbers refer to NPCs as follows /H
	// [0] Mother Bear
	// [1] Bear Cub
	// [2] Beaver
	// [3] Fox
	// /H

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
		currentHeldItem = "nothingHeld";
		spriteRenderer = GetComponent<SpriteRenderer> ();

		controller = GetComponent<CharacterController>();
		myBody = GetComponent<Rigidbody2D>();
		pickupScript = GetComponent<PickupScript>();
		myTrans = transform;
	}

	void Update()
	{
		if (facingDir == FacingDirection.Right) 
		{
			spriteRenderer.sprite = spriteRight;
		}
		if (facingDir == FacingDirection.Left) 
		{
			spriteRenderer.sprite = spriteLeft;
		}
		if (facingDir == FacingDirection.Up) 
		{
			spriteRenderer.sprite = spriteUp;
		}
		if (facingDir == FacingDirection.Down) 
		{
			spriteRenderer.sprite = spriteDown;
		}

		moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		moveDir = transform.TransformDirection(moveDir);
		moveDir *= speed;
		
		//	Debug.Log (facingDir);
		if (moveDir.x > 0)
			facingDir = FacingDirection.Right;
		if (moveDir.x < 0)
			facingDir = FacingDirection.Left;
		if (moveDir.y > 0)
			facingDir = FacingDirection.Up;
		if (moveDir.y < 0)
			facingDir = FacingDirection.Down;

		moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		moveDir = transform.TransformDirection(moveDir);
		moveDir *= speed;
		
//		moveDir.x -= gravity * Time.deltaTime;
		controller.Move(moveDir * Time.deltaTime);
//		myTrans.position = new Vector3 (myTrans.position.x, myTrans.position.y, 0);

		if( Input.GetButtonDown("pickup") && pickupScript != null) //the E key, it's pre-set in the input manager so can be changed by players on launch
		{
			if(currentHeldItem != null)
			{
				pickupScript.Drop();
			}
			else
			{
				pickupScript.Pickup(transform);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "NPC")
		{
			Debug.Log ("NPC detected you");
		}

		if (other.tag == "pickup") 
		{
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