using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewChatScript : MonoBehaviour {

	public GameObject textBox;
	public Text theText;
	bool active;
	bool mouseOver;

	public TextAsset idleDialogue; 
	public TextAsset questRequest;
	public TextAsset questReminder;
	public TextAsset questReminderAlt;
	public TextAsset unrequiredItemDialogue;
	public TextAsset objectiveCompletedDialogue;
	public TextAsset altObjectiveCompletedDialogue;
	public TextAsset altObjectiveCompletedDialogue2;

	

	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	
	public bool chatEnabled;
	public bool testingMode;
	public bool questStarted;
	public bool objectiveCompleted;
	public bool altObjectiveCompleted;
	public bool altObjectiveMet2;
	bool foxTalkedto;
	bool beaverTalkedto;
	bool motherBearTalkedto;
	bool bearCubTalkedto;
	private CharacterChatActive charActive;
	public GameObject motherBear;
	int checkNum;
	PanelController panelController;

	public PlayerScript playerScript;
	// Use this for initialization

	public enum CharacterChatActive
	{
		Fox,
		MotherBear,
		Beaver,
		BearCub
	}
	void Start () {
		checkNum = 0;
		questStarted = false;
		NpcScript npcScript = GetComponent<NpcScript> ();

		if (npcScript.charIdentifier == "Beaver") 
			charActive = CharacterChatActive.Beaver;
		if (npcScript.charIdentifier == "MotherBear")
			charActive = CharacterChatActive.MotherBear;
		if (npcScript.charIdentifier == "BearCub")
			charActive = CharacterChatActive.BearCub;
		if (npcScript.charIdentifier == "Fox")
			charActive = CharacterChatActive.Fox;

		panelController = textBox.GetComponent<PanelController> ();
		chatEnabled = false;

		playerScript = FindObjectOfType<PlayerScript> ();
		if (idleDialogue != null) {
			textLines = (idleDialogue.text.Split('\n'));
		}

		if (endAtLine == 0) {

			endAtLine = textLines.Length;
		}
	}
	
	// Update is called once per frame

	void ChatActive () {

		#region TestingArea
		if (testingMode) {
			if (Input.GetKeyDown(KeyCode.L))
				chatEnabled = false;
		}
		
		#endregion
		theText.enabled = chatEnabled;
		panelController.ImageEnabled (chatEnabled);
		if (chatEnabled) {
//			Debug.Log (charActive);
//			theText.enabled = chatEnabled;
//			panelController.ImageEnabled (chatEnabled);



			if (charActive == CharacterChatActive.MotherBear)
			{
				NpcScript currentNpcScript = gameObject.GetComponent<NpcScript>();


				endAtLine = textLines.Length;
				if (!questStarted)
				{
				if (!foxTalkedto)
					textLines = (idleDialogue.text.Split('\n'));
				if (foxTalkedto)
				{
					
					textLines = (questRequest.text.Split('\n'));
					
				}
			}
			if (questStarted){
				if (!objectiveCompleted && !bearCubTalkedto){
					textLines = (questReminder.text.Split('\n'));
				}
				else if ( !objectiveCompleted && bearCubTalkedto){
					textLines = (questReminderAlt.text.Split('\n'));
				}
					if (objectiveCompleted)
						textLines = (objectiveCompletedDialogue.text.Split('\n'));
			}


				

			if (Input.GetKeyDown (KeyCode.Return)) {
				if (currentLine < textLines.Length)
						currentLine += 1 ;

				if (currentLine == endAtLine) {
					theText.enabled = false;
						panelController.enabled = false;
					chatEnabled = false;
					currentLine = 0;
						if (!questStarted && foxTalkedto)
						{
							questStarted = true;
						}
				}

			
			}
			theText.text = textLines [currentLine];
			}
			else if (charActive == CharacterChatActive.Fox)
			{

				NpcScript currentNpcScript = GetComponent<NpcScript>();
				endAtLine = textLines.Length;
				if (questStarted)
					textLines = (questReminder.text.Split('\n'));

				if (questStarted)
					{
				 if (!currentNpcScript.doesCharHaveItemReq)
					{
							textLines = (questReminder.text.Split('\n'));

					}
				 if (currentNpcScript.doesCharHaveItemReq)
						{
							textLines = (objectiveCompletedDialogue.text.Split('\n'));
						if (objectiveCompleted && altObjectiveCompleted != true)
						{
							textLines = (altObjectiveCompletedDialogue.text.Split('\n'));
						}

						if (altObjectiveCompleted)
						{
							textLines = (altObjectiveCompletedDialogue2.text.Split('\n'));
						}

						}


					
					}

				theText.text = textLines [currentLine];
				if (Input.GetKeyDown (KeyCode.Return)) {
					if (currentLine < textLines.Length)
						currentLine += 1;
					
					if (currentLine == endAtLine) {
						theText.enabled = false;
						panelController.ImageEnabled (false);
						chatEnabled = false;
						currentLine = 0;
						if (!questStarted)
						questStarted = true;
						if (altObjectiveCompleted)
						{
							altObjectiveMet2 = true;

						}

						if (currentNpcScript.doesCharHaveItemReq)
							objectiveCompleted = true;

						if (currentNpcScript.objectiveMet)
						{
							altObjectiveCompleted = true;
							currentNpcScript.altObjectiveMet = true;
						}

						if (objectiveCompleted && questStarted)
						{
							currentNpcScript.objectiveMet = true;
						}

					}
				}
			}
			else if (charActive == CharacterChatActive.Beaver)
			{
				
				NewChatScript questReliantNpc = GameObject.FindGameObjectWithTag("NPC_MotherBear").GetComponent<NewChatScript>();
				NpcScript currentNpcScript = GetComponent<NpcScript>();
				theText.enabled = chatEnabled;
				panelController.ImageEnabled (chatEnabled);
				endAtLine = textLines.Length;

				if (questReliantNpc.questStarted && bearCubTalkedto)
				{
					
					if (checkNum == 0)
					{
						currentLine = 0;
						checkNum += 1;
					}
				 if (bearCubTalkedto)
					textLines = (questRequest.text.Split('\n'));

					if (questStarted)
					{
				 if (!currentNpcScript.doesCharHaveItemReq)
					{
							textLines = (questReminder.text.Split('\n'));
							objectiveCompleted = false;
					}
				 if (currentNpcScript.doesCharHaveItemReq)
						{
							textLines = (objectiveCompletedDialogue.text.Split('\n'));
							objectiveCompleted = true;
						}
					
					}
				
				if (Input.GetKeyDown (KeyCode.Return)) {
						
					if (currentLine < textLines.Length)
							currentLine += 1 ;
						
					if (currentLine == endAtLine) {
							theText.enabled = false;
							chatEnabled = false;
							currentLine = 0;
					if (objectiveCompleted && questStarted)
							{
								currentNpcScript.objectiveMet = true;
							}
					

					if (!questStarted && bearCubTalkedto)
						 {
								questStarted = true;
						 }
					if (questStarted && currentNpcScript.doesCharHaveItemReq)
							{
								objectiveCompleted = true;
							}
						}
					}


				}
				else
				{
					endAtLine = 1;

					
					
					if (Input.GetKeyDown (KeyCode.Return)) {
						
						if (!active){
							active = true;
							
							
						}
						
						if (active){
							chatEnabled = false;
							currentLine = Random.Range(0, textLines.Length);
							theText.enabled = false;

						}
				}





					
					
				}
				theText.text = textLines [currentLine];
			}

			else if (charActive == CharacterChatActive.BearCub)
			{

				NewChatScript questReliantNpc = GameObject.FindGameObjectWithTag("NPC_MotherBear").GetComponent<NewChatScript>();
				NpcScript currentNpcScript = GetComponent<NpcScript>();
				if (questReliantNpc.questStarted && beaverTalkedto)
					textLines = (questRequest.text.Split('\n'));
				if (currentNpcScript.questReliantScript.objectiveMet)
					textLines = (objectiveCompletedDialogue.text.Split('\n'));
				
				theText.text = textLines [currentLine];
				
				endAtLine = textLines.Length;
				
				if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.L)) {
					if (currentLine < textLines.Length)
						currentLine += 1;
					
					if (currentLine == endAtLine) {
						theText.enabled = false;
						chatEnabled = false;
						theText.enabled = chatEnabled;

						if (currentNpcScript.questReliantScript.objectiveMet && objectiveCompleted != true)
						{
							objectiveCompleted = true;
							currentNpcScript.objectiveMet = true;
							panelController.ImageEnabled(false);
						}

						currentLine = 0;
					}
				}
			}
		}
	}

//	void OnMouseOver()
//	{
//		if (Input.GetButton("Fire1")) {
//			chatEnabled = true;
////			activateChat();
//		}
//
//	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			PlayerScript playerConsole = other.GetComponent<PlayerScript>();
			motherBearTalkedto = playerConsole.npcsTalkedTo[0];
			bearCubTalkedto = playerConsole.npcsTalkedTo[1];
			beaverTalkedto = playerConsole.npcsTalkedTo[2];
			foxTalkedto = playerConsole.npcsTalkedTo[3];
			ChatActive ();
			if (Input.GetButtonDown ("Fire1") && mouseOver) {

				chatEnabled = true;

			}
		}

	}
	void OnMouseEnter()
	{
		mouseOver = true;
	}

	void OnMouseExit()
	{
		mouseOver = false;
	}

//	void OnTriggerExit(Collider other)
//	{
//		chatEnabled = false;
//	}


}
