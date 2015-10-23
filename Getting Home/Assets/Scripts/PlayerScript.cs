using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public float speed;					//The player's speed. Don't hardcode it in here, change it in the inspector.

	public FacingDirection facingDir;	//The direction the PC is currently facing. The base value is facing upwards, make sure to change it if the player is facing in a different direction at the start of a level.
	public Transform myTrans;			//The transform of the PC.

//	public float detectionRange;		//The detection range for the PC. Change this to increase the range at which the player can interact with things.

	//debug variables should go below here, disable them when you don't need them

	//This enum will give a list of directions the player can face. Ensure you update it each time the player changes their direction of movement. It's a good idea to keep track of it for animations/interactions/etc...
	public enum FacingDirection
	{
		Up,
		Down,
		Left,
		Right
	}

	void Start()
	{
		myTrans = transform;

	}

	void Update()
	{
		Move();	//Calls the movement function.

		//Mouse click stuff. The 0 represents left click, this particular Input requires and int to be passed through it.
		if (Input.GetMouseButtonDown (0))
		{
			Debug.Log ("Registered mouse click");
		}
	}

	void Move()
	{
		if (Input.GetKey (KeyCode.W))
		{
			transform.Translate(Vector2.up * speed * Time.deltaTime);		//When W is pressed and held, the character will move up.
			facingDir = FacingDirection.Up;									//The player's facing direction is changed to face up (forwards).
		}

		if (Input.GetKey (KeyCode.S))
		{
			transform.Translate(Vector2.down * speed * Time.deltaTime);		//When S is pressed and held, the character will move down.
			facingDir = FacingDirection.Down;								//The player's facing direction is changed to face down (backwards).
		}

		if (Input.GetKey (KeyCode.A))
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);		//When A is pressed and held, the character will move left.
			facingDir = FacingDirection.Left;								//The player's facing direction is changed to face left.
		}

		if (Input.GetKey (KeyCode.D))
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);	//When D is pressed and held, the character will move right.
			facingDir = FacingDirection.Right;								//The player's facing direction is changed to face right.
		}
	}

//	void DetectInteractDistance()
//	{
////		DetectionSphere.transform.position = myTrans.position * 1;
//
//		Collider[] objectsInRange = Physics.OverlapSphere (myTrans.position, detectionRange);
//
//		Debug.Log ("Checking for interactables...");
//
//		for (int i = 0; i < objectsInRange.Length; i++) 
//		{
////			objectsInRange[i].gameObject.GetComponent<InteractScript>();
//		}
//
//		Debug.Log ("Finished.");
//	}

	void OnTriggerEnter(Collider other)
	{
		//call universal triggers here, don't put level-specific ones here, probably best to create a seperate script for that (Aidan 11/10/15)
		if (other.tag == "NPC")
		{
			Debug.Log ("NPC detected you");
		}

		if (other.tag == "Tree")
		{
			Debug.Log(other.tag);
			return;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "NPC")
		{
			Debug.Log ("NPC no longer sees you");
		}
	}

//	void OnDrawGizmos()
//	{
//		Gizmos.DrawWireSphere(myTrans.position, detectionRange);
//	}
}












