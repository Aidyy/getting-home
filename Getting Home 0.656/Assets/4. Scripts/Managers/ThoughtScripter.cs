using UnityEngine;
using System.Collections;

public class ThoughtScripter : MonoBehaviour {

	public enum QuestTracker {
		findingTheFox,
		findingTheHunter,
		findingMotherBear,
		findingBearCub,
		findingPerfectLog,
		backToTheCave,
		rescuingTheFox,
		followingTheFox,
		nullState
	}

	public QuestTracker questTracker;

	#region TextRenderers
	public Sprite poorThingLooksTrapped;
	public Sprite iWonderWhatHappenedHere;
	public Sprite isThatABearCub;
	public Sprite maybeIShouldFollowThatPath;
	public Sprite iNeedToFindTheHunter;
	public Sprite iShouldProbablyFindThatRiver;
	public Sprite maybeThatBeaver;
	public Sprite theBeaverSaidThatTheWoodsman;
	public Sprite iShouldGetThisBackToBeaver;
	public Sprite iShouldProbablyHeadBackToTheCave;
	public Sprite nowICanFreeTheFox;
	public Sprite iMissMyHome;
	public Sprite iMissMyFamily;
	public Sprite theFoxSaidIShouldHeadSouth;
	public Sprite iCantGoThisWay;
	public Sprite aHouse;
	public Sprite iHopeThatBearIsFriendly;
	public Sprite whereDoesThisPathGo;
	public Sprite isThatBlood;
	public Sprite aMine;
	#endregion

	public bool motherBearQuestStarted;
	public bool foxQuestStarted;
	public bool beaverQuestStarted;
	public bool bearCubQuestStarted;

	public bool motherBearQuestCompleted;
	public bool foxQuestCompleted;
	public bool foxQuestCompletedTwo;
	public bool beaverQuestCompleted;
	public bool bearCubQuestCompleted;


	LevelScripter gameManager;
	PlayerScript playerController;

	SpriteRenderer mySprite;
	// Use this for initialization
	void Start () 
	{
		gameManager = GameObject.FindGameObjectWithTag ("LevelScripter").GetComponent<LevelScripter> ();
		playerController = GetComponentInParent<PlayerScript> ();
		mySprite = GetComponent<SpriteRenderer> ();
		mySprite.sprite = null;
		mySprite.enabled = false;
	}

	void Update()
	{

		checkProgress ();
		Debug.Log (questTracker);
		if (!foxQuestStarted && !motherBearQuestStarted) {
			questTracker = QuestTracker.findingTheFox;
		}
		if (foxQuestStarted && !motherBearQuestStarted) {
			questTracker = QuestTracker.findingTheHunter;
		}
		if (foxQuestStarted && motherBearQuestStarted) {
			questTracker = QuestTracker.findingBearCub;
		}
		if (beaverQuestStarted) {
			questTracker = QuestTracker.findingPerfectLog;
		}
		if (beaverQuestCompleted && bearCubQuestCompleted) {
			questTracker = QuestTracker.backToTheCave;
		}
		if (foxQuestCompleted) {
			questTracker = QuestTracker.nullState;
		}
		if (playerController.currentHeldItem == "Item_Key") {
			questTracker = QuestTracker.rescuingTheFox;
		}
		if (foxQuestCompletedTwo && foxQuestCompleted) {
			questTracker = QuestTracker.followingTheFox;	
		}

		if (Input.GetKey (KeyCode.LeftShift) && !playerController.currentlyInChat) {
			mySprite.enabled = true;
		} else {
			mySprite.enabled = false;
		}






		switch (questTracker) {
		
		case QuestTracker.findingTheFox:
				
			mySprite.sprite = maybeIShouldFollowThatPath;
			break;
		case QuestTracker.findingTheHunter:
			mySprite.sprite = iNeedToFindTheHunter;
			break;
		case QuestTracker.findingBearCub:
			mySprite.sprite = iShouldProbablyFindThatRiver;
			break;
		case QuestTracker.findingPerfectLog:
			mySprite.sprite = theBeaverSaidThatTheWoodsman;
			break;
		case QuestTracker.backToTheCave:
			mySprite.sprite = iShouldProbablyHeadBackToTheCave;
			break;
		case QuestTracker.rescuingTheFox:
			mySprite.sprite = nowICanFreeTheFox;
			break;
		case QuestTracker.followingTheFox:
			mySprite.sprite = theFoxSaidIShouldHeadSouth;
			break;
		case QuestTracker.nullState:
			mySprite.sprite = null;
			break;
			

				}





	}

	void checkProgress ()
	{
		motherBearQuestStarted = gameManager.motherBearChatScript.questStarted;
		motherBearQuestCompleted = gameManager.motherBearObjCompleted;
		foxQuestStarted = gameManager.foxChatScript.questStarted;
		foxQuestCompleted = gameManager.foxObjCompleted;
		beaverQuestStarted = gameManager.beaverChatScript.questStarted;
		beaverQuestCompleted = gameManager.beaverObjCompleted;
		bearCubQuestStarted = gameManager.motherBearChatScript.questStarted;
		bearCubQuestCompleted = gameManager.bearCubObjCompleted;
		foxQuestCompletedTwo = gameManager.foxChatScript.altObjectiveCompleted;

	}
}
