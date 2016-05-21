using UnityEngine;
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
	public bool testMode;
	bool currentlyInChat;

	EventSpriteEnabler charPortrait;
	EventSpriteEnabler NpcPortrait;
	EventSpriteEnabler buttonController;
	EventSpriteEnabler downArrow;

	public bool tutorialLevel;
	public bool firstLevel;

	public Animator anim;
	bool animWalkingRight;
	bool animWalkingLeft;
	bool animWalkingForward;
	bool animWalkingBackward;



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
		currentlyInChat = false;
		if (firstLevel) {
			buttonController = GameObject.FindGameObjectWithTag ("EnterButton").GetComponent<EventSpriteEnabler> ();
			downArrow = GameObject.FindGameObjectWithTag ("DownArrow").GetComponent<EventSpriteEnabler> ();
			charPortrait = GameObject.FindGameObjectWithTag ("CharacterPortrait").GetComponent<EventSpriteEnabler> ();
			NpcPortrait = GameObject.FindGameObjectWithTag ("NPCPortrait").GetComponent<EventSpriteEnabler> ();
		}
		currentHeldItem = "nothingHeld";
		spriteRenderer = GetComponent<SpriteRenderer> ();

		facingDir = FacingDirection.Right;
		controller = GetComponent<CharacterController>();
		pickupScript = GetComponent<PickupScript>();
		myTrans = transform;
	}

	void Update()
	{
		if (facingDir == FacingDirection.Right)
			spriteRenderer.sprite = spriteRight;
		if (facingDir == FacingDirection.Left)
			spriteRenderer.sprite = spriteLeft;
		if (facingDir == FacingDirection.Up)
			spriteRenderer.sprite = spriteUp;
		if (facingDir == FacingDirection.Down)
			spriteRenderer.sprite = spriteDown;
		if (tutorialLevel) {
			moveDir = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;
		}

		if (firstLevel) {
		
			if (currentlyInChat == false || Application.loadedLevelName == "f_Level_01") {
				moveDir = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
				moveDir = transform.TransformDirection (moveDir);
				moveDir *= speed;
				charPortrait.imageDisable ();
				NpcPortrait.imageDisable ();
				buttonController.imageDisable ();
				downArrow.imageDisable ();

			} else {
				moveDir = Vector3.zero;
				buttonController.ImageEnable ();
				charPortrait.ImageEnable ();
				NpcPortrait.ImageEnable ();
				downArrow.ImageEnable ();
			}
		}


//		Debug.Log (facingDir);
		if (moveDir.x > 0) {
			facingDir = FacingDirection.Right;
			walkPosition("Right");
		}
		if (moveDir.x < 0) {
			facingDir = FacingDirection.Left;
			walkPosition("Left");
		}
			if (moveDir.y > 0){
			facingDir = FacingDirection.Up;
			walkPosition("Forward");
		}  
		if (moveDir.y < 0){
			facingDir = FacingDirection.Down;
			walkPosition("Backward");
		} 
		if (moveDir.y == 0 && moveDir.x == 0) {

			walkPosition("Null"); 
			
		}


		anim.SetBool("WalkingRight", animWalkingRight);
		anim.SetBool ("WalkingLeft", animWalkingLeft);
		anim.SetBool ("WalkingForward", animWalkingForward);
		anim.SetBool ("WalkingBackward", animWalkingBackward);
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
				
			}
		}
		#region TestingArea
		// functions below are intended only for debugging and testing purposes, before utlizing these however, make sure testing mode is checked in the inspector, otherwise these won't work. /H
		if (testMode) {
		if (Input.GetKeyDown(KeyCode.G) )
				if (currentHeldItem != null)
				Debug.Log (currentHeldItem);
			else Debug.Log ("Nothing Is Currently Held By The Player");
		 

		}
		#endregion
	}


	void OnTriggerStay(Collider other)
	{
		NpcScript npcIdentifier = other.GetComponent<NpcScript> ();

		//call universal triggers here, don't put level-specific ones, probably best to create a seperate script for that (Aidan 11/10/15)
		if (other.tag == "NPC" || other.tag == "NPC_MotherBear")
		{
//			Debug.Log ("NPC detected you");
			NewChatScript chatCheckScript = other.GetComponent<NewChatScript>();
//			Debug.Log(chatCheckScript.chatEnabled);
			currentlyInChat = chatCheckScript.chatEnabled;
		}

		if (other.tag == "Tree")
		{
			Debug.Log(other.tag);
			return;
		}
		#region TestingArea2
		if (other.tag == "pickup" && testMode) {
			pickupScript = other.GetComponent<PickupScript>();
			Debug.Log (other.tag);

			if (Input.GetKeyDown(KeyCode.E))
			{
				lastHeldItem = currentHeldItem;
				pickupScript.SpriteUpdate();
			currentHeldItem = pickupScript.itemSecondaryTag; //Gets the secondary tag name from item you have just collided with, in case it is tagged as pick up /H

				PickupScript itemHeld = GetComponentInChildren<PickupScript>();
				itemHeld.spriteRenderer.enabled = true;
			}

		}

		#endregion
	   
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "NPC")
		{
			Debug.Log ("NPC no longer sees you");

		}
	}

	void walkPosition (string position)
	{
		if (position == "Forward") {
			animWalkingForward = true;
			animWalkingBackward = false;
			animWalkingLeft = false;
			animWalkingRight = false;
			}
		if (position == "Backward") {
			animWalkingForward = false;
			animWalkingBackward = true;
			animWalkingLeft = false;
			animWalkingRight = false;
		}
		if (position == "Left") {
			animWalkingForward = false;
			animWalkingBackward = false;
			animWalkingLeft = true;
			animWalkingRight = false;
		}
		if (position == "Right") {
			animWalkingForward = false;
			animWalkingBackward = false;
			animWalkingLeft = false;
			animWalkingRight = true;
		}

		if (position == "Null") {
			animWalkingForward = false;
			animWalkingBackward = false;
			animWalkingLeft = false;
			animWalkingRight = false;
		}
	}

	//!!DEV!!
	public void SpeedUp()
	{
		speed = 40f;
	}

	public void SlowDown()
	{
		speed = 2.5f;
	}
	//!!DEV!!
}
