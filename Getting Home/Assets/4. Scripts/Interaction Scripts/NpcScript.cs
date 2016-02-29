using UnityEngine;
using System.Collections;

public class NpcScript : MonoBehaviour {

	
	public string requiredItem;
	public string charIdentifier;
	public bool objectiveMet;
	public bool doesCharHaveItemReq;
	public bool doesCharHaveItemUnreq;
	public bool doesCharHaveNothing;
	public bool testingMode;

	// The start function can be used for initiation

	void Start () {
		doesCharHaveItemReq = false;
		doesCharHaveItemUnreq = false;
	}
	
	void StartEvent()
	{
		// The following if statement can instruct the NPC how to progress if the item required has been acquired. /H
	if (doesCharHaveItemReq) { 

		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			PlayerScript target = other.GetComponent<PlayerScript> ();
			NewChatScript currentChatScript = gameObject.GetComponent<NewChatScript>();
			#region TestingArea
			// testing area - start
			if (Input.GetKeyDown(KeyCode.L) && testingMode)
				Debug.Log(target.currentHeldItem);
			// testing area - end
			
			#endregion
			if (currentChatScript.chatEnabled)
			{
				if (charIdentifier == "MotherBear")
					target.npcsTalkedTo[0] = true;
				if (charIdentifier == "BearCub")
					target.npcsTalkedTo[1] = true;
				if (charIdentifier == "Beaver")
					target.npcsTalkedTo[2] = true;
				if (charIdentifier == "Fox")
					target.npcsTalkedTo[3] = true;
			}


			if (requiredItem == target.currentHeldItem) // Executes if the player has the item required by the current NPC in their hands. /H
			{
				doesCharHaveItemReq = true; 
			}

			else if (target.currentHeldItem != null) // Executes if the player has an item not required by the current NPC in their hands. /H
			{
				doesCharHaveItemUnreq = true;
			}
			else if (target.currentHeldItem == null) // Executes if the player is empty handed. /H
			{
				doesCharHaveNothing = true;
			}
		}

		}

}
