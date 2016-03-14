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
	public GameObject questReliantNPC;
	public NpcScript questReliantScript;

	Transform myTransform;
//	Vector3 postBearCubPosition;

	// The start function can be used for initiation

	void Start () {
		if (charIdentifier == "BearCub")
		questReliantScript = questReliantNPC.GetComponent<NpcScript> ();

		doesCharHaveItemReq = false;
		doesCharHaveItemUnreq = false;
		myTransform = GetComponent<Transform> ();
	}
	void Update () {
		LevelScripter levelScripter = GameObject.FindGameObjectWithTag("LevelScripter").GetComponent<LevelScripter>();
		
		if (charIdentifier == "Beaver")
		{
			levelScripter.beaverObjCompleted = objectiveMet;
		}
		else if (charIdentifier == "MotherBear")
		{
			levelScripter.motherBearObjCompleted = objectiveMet;
		}
		else if (charIdentifier == "Fox")
		{
			levelScripter.foxObjCompleted = objectiveMet;
		}
		else if (charIdentifier == "BearCub")
		{
			levelScripter.bearCubObjCompleted = objectiveMet;
		}
	if (charIdentifier == "BearCub") {
			
			if (questReliantScript.objectiveMet)
			{
			TargetCheck targetPos1 = GameObject.FindGameObjectWithTag("BearCubTargetPos1").GetComponent<TargetCheck>();

			myTransform.position = targetPos1.targetPosTransform;
			}

			if (objectiveMet)
			{
				TargetCheck targetPos2 = GameObject.FindGameObjectWithTag("BearCubTargetPos2").GetComponent<TargetCheck>();
				myTransform.position = targetPos2.targetPosTransform;
			}
		}
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
				doesCharHaveItemUnreq = false;
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
