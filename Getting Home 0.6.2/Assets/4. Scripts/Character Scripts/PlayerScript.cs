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

	EventSpriteEnabler charPortrait;  // The character portrait located on the UI needs to be dragged into the game's inspector /H
	EventSpriteEnabler NpcPortrait;  //  The NPC portrait located on the UI needs to be dragged into the game's inspector /H                               
	EventSpriteEnabler buttonController;
	EventSpriteEnabler downArrow;   // This relates to the script associated with the down arrow that shows up during chat. Drag the downArrow here from the UI /H
	NewChatScript chatCheckScript;   


	 
	// The bools below are related to anim, and they are pretty self explanatory /H
	public Animator anim;
	bool animWalkingRight;
	bool animWalkingLeft;
	bool animWalkingForward;
	bool animWalkingBackward;

	// Rather than utilizing the fixedUpdate reliant onTriggerStay, these bools track whether or not you are currently standing in the vicinity of A) an item, or B) an NPC. note: Chat Trigger relates to NPC /H
	bool pickUpTrigger;
	bool chatTrigger;


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

	//This enum will give a list of directions the player can face. Ensure you update it each time the player changes their direction of movement.  /H
	//It's a good idea to keep track of it for animations/interactions/etc... /H
	public enum FacingDirection
	{
		Up,
		Down,
		Left,
		Right
	}

	void Start()
	{
		// Make sure currentlyInChat is labeled as false during initialisation, or else errors might occur. /H
		currentlyInChat = false;

			buttonController = GameObject.FindGameObjectWithTag ("EnterButton").GetComponent<EventSpriteEnabler> ();
			downArrow = GameObject.FindGameObjectWithTag ("DownArrow").GetComponent<EventSpriteEnabler> ();
			charPortrait = GameObject.FindGameObjectWithTag ("CharacterPortrait").GetComponent<EventSpriteEnabler> ();
			NpcPortrait = GameObject.FindGameObjectWithTag ("NPCPortrait").GetComponent<EventSpriteEnabler> ();
		
		// Either set the currentHeldItem Null or "nothingHeld" in the beginning. /H
		currentHeldItem = "nothingHeld";
		spriteRenderer = GetComponent<SpriteRenderer> ();

		// Change the facingDir depending on where the player faces when the game starts.
		// After (FacingDir = ) write:
		//FacingDirection.Right if you want him to face right
		//FacingDirection.Left if you want him to face left
		// ,etc... 

		facingDir = FacingDirection.Right;
		controller = GetComponent<CharacterController>();
		pickupScript = GetComponent<PickupScript>();
		myTrans = transform;
	}

	void Update()
	{

		// The if statement below checks whether or not you are in the vicinity of an equippable item. /H
		if (pickUpTrigger) {
			// if you are in the vicinity of an equippable item, the function below helps you pick up the item. /H
			if (Input.GetKeyDown(KeyCode.E))
			{
				// First thing it does is, it takes the data of whatever you were holding prior to picking up the new item, and stores it in the lastHeldItem variable. The lastHeldItem variable is cruical to the game's pickup system and must not be removed.
				// It lets the place you've picked the new item for know what you were holding last and it changes to that item, allowing you to switch or put down item. /H
				lastHeldItem = currentHeldItem;
				pickupScript.SpriteUpdate(); // Updates the sprite that shows you what you are holding.
				currentHeldItem = pickupScript.itemSecondaryTag; // this is what tells the game about which item it is that you have picked up. /H
				pickupScript.itemSecondaryTag = lastHeldItem;//Gets the secondary tag name from item you have just collided with, in case it is tagged as pick up /H
				
				PickupScript itemHeld = GetComponentInChildren<PickupScript>();
				if (itemHeld != null)
					itemHeld.spriteRenderer.enabled = true;
			}
		}	

		// The if statment below checks if you are in the vicinity of an NPC. /H
		if (chatTrigger) {
				currentlyInChat = chatCheckScript.chatEnabled; // Checks whether or not you are currently in chat state. /H
		}
			
		// the if statement below only lets you move when you are not in a chat.
		     if (currentlyInChat == false) {
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

		controller.Move(moveDir * Time.deltaTime);
		myTrans.position = new Vector3 (myTrans.position.x, myTrans.position.y, 0);
	}

	void OnTriggerEnter(Collider other)
	{		if (other.tag == "pickup") {
			pickUpTrigger = true;
			pickupScript = other.GetComponent<PickupScript>();
		}
		if (other.tag == "NPC" || other.tag == "NPC_MotherBear") {
			chatTrigger = true;
			chatCheckScript = other.GetComponent<NewChatScript>();
			}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "NPC"|| other.tag == "NPC_MotherBear")
		{
			chatTrigger = false;

		}
		if (other.tag == "pickup") {
			pickUpTrigger = false;
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
		anim.SetBool("WalkingRight", animWalkingRight);
		anim.SetBool ("WalkingLeft", animWalkingLeft);
		anim.SetBool ("WalkingForward", animWalkingForward);
		anim.SetBool ("WalkingBackward", animWalkingBackward);
		}

	//!!DEV!!
	public void SpeedUp(){
		speed = 40f;
	}

	public void SlowDown(){
		speed = 2.5f;	}
	//!!DEV!!
}
