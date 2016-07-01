using UnityEngine;
using System.Collections;

public class NpcScript : MonoBehaviour {

	
	public string requiredItem;
	public string unrequiredItem;
	public string charIdentifier;
	public string specialItem;
	public bool objectiveMet;
	public bool altObjectiveMet;
	public bool altObjectiveMet2;
	public bool doesCharHaveItemReq;
	public bool doesCharHaveItemUnreq;
	public bool doesCharHaveSpecialItem;
	public bool doesCharHaveNothing;
	public GameObject questReliantNPC;
	public NpcScript questReliantScript;

	SpriteRenderer mySpriteRenderer;

	public Sprite faceFrontSprite;
	public Sprite initialSprite;

	public Animator anim;
	EventSpriteEnabler Ekey ;
	Transform myTransform;
//	Vector3 postBearCubPosition;

	// The start function can be used for initiation

	void Start () {
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
		mySpriteRenderer.sprite = initialSprite;
		
		Ekey = GetComponentInChildren<EventSpriteEnabler>();
		if (charIdentifier == "BearCub")
		questReliantScript = questReliantNPC.GetComponent<NpcScript> ();

		doesCharHaveItemReq = false;
		doesCharHaveItemUnreq = false;
		doesCharHaveSpecialItem = false;
		myTransform = GetComponent<Transform> ();
	}

	void Update () {

		if (anim != null) {
			anim.SetBool ("ObjectiveMet", objectiveMet);
		}

		LevelScripter levelScripter = GameObject.FindGameObjectWithTag("LevelScripter").GetComponent<LevelScripter>();
		
		if (charIdentifier == "Beaver")
		{
			levelScripter.beaverObjCompleted = objectiveMet;
		}

		else if (charIdentifier == "MotherBear")
		{
			levelScripter.motherBearObjCompleted = objectiveMet;

			if (objectiveMet)
			{
				
				TargetCheck motherBearPos = GameObject.FindGameObjectWithTag("MotherBearTargetPos").GetComponent<TargetCheck>();
				myTransform.position = motherBearPos.targetPosTransform;
			}

		}

		else if (charIdentifier == "Fox")
		{
			levelScripter.foxObjCompleted = objectiveMet;

			if (objectiveMet && altObjectiveMet == false )
			{
				TargetCheck foxTargetPos = GameObject.FindGameObjectWithTag("FoxTargetPos").GetComponent<TargetCheck>();
				myTransform.position = foxTargetPos.targetPosTransform;
			}

			if ( altObjectiveMet == true)
			{
				TargetCheck foxTargetPos = GameObject.FindGameObjectWithTag("FoxTargetPos2").GetComponent<TargetCheck>();
				myTransform.position = foxTargetPos.targetPosTransform;
			}
		}

		else if (charIdentifier == "BearCub")
		{

			levelScripter.bearCubObjCompleted = objectiveMet;
			if (questReliantScript.objectiveMet)
			{
				TargetCheck targetPos1 = GameObject.FindGameObjectWithTag("BearCubTargetPos1").GetComponent<TargetCheck>();				
				myTransform.position = targetPos1.targetPosTransform;
			}
			
			if (objectiveMet)
			{
				mySpriteRenderer.sprite = faceFrontSprite;
				TargetCheck targetPos2 = GameObject.FindGameObjectWithTag("BearCubTargetPos2").GetComponent<TargetCheck>();
				myTransform.position = targetPos2.targetPosTransform;
			}

		}
	}
	

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {

			Ekey.SpriteEnable();
			PlayerScript target = other.GetComponent<PlayerScript> ();
			NewChatScript currentChatScript = gameObject.GetComponent<NewChatScript>();
//			#region TestingArea			
//			#endregion

			if (currentChatScript.chatEnabled)
			{
				Ekey.SpriteDisable();
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

			else if ( specialItem == target.currentHeldItem)
			{
				doesCharHaveSpecialItem = true;
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
	void OnTriggerExit(Collider other)
	{
		Ekey.SpriteDisable ();
	}

}
