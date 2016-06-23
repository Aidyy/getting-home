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
		followingTheFox
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


	LevelScripter gameManager;

	SpriteRenderer mySprite;
	// Use this for initialization
	void Start () 
	{
		gameManager = GameObject.FindGameObjectWithTag ("LevelScripter").GetComponent<LevelScripter> ();
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

		if (Input.GetKey (KeyCode.LeftShift)) {
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

				}





	}

	void checkProgress ()
	{
		motherBearQuestStarted = gameManager.motherBearChatScript.questStarted;
		foxQuestStarted = gameManager.foxChatScript.questStarted;
		beaverQuestStarted = gameManager.beaverChatScript.questStarted;
		bearCubQuestStarted = gameManager.motherBearChatScript.questStarted;
	}
}
