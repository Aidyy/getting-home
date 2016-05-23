using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewChatScript : MonoBehaviour {

	public GameObject textBox;
	public Text theText;
	public Text charIdentifier;
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


	EventSpriteEnabler pcImage;
	EventSpriteEnabler npcImage;

	

	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	EventSpriteEnabler npcPortrait;
	
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


		pcImage = GameObject.FindGameObjectWithTag ("CharacterPortrait").GetComponent<EventSpriteEnabler> ();
		npcImage = GameObject.FindGameObjectWithTag ("NPCPortrait").GetComponent<EventSpriteEnabler> ();
		npcPortrait = GameObject.FindGameObjectWithTag ("NPCPortrait").GetComponent<EventSpriteEnabler> ();
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
		charIdentifier.enabled = chatEnabled;
		panelController.ImageEnabled (chatEnabled);

		if (chatEnabled) {
//			Debug.Log (charActive);
//			theText.enabled = chatEnabled;
//			panelController.ImageEnabled (chatEnabled);



			if (charActive == CharacterChatActive.MotherBear) {
				npcPortrait.loadSprite ("motherBear");
				NpcScript currentNpcScript = gameObject.GetComponent<NpcScript> ();



				endAtLine = textLines.Length;
				if (!questStarted) {
					if (!foxTalkedto)
						textLines = (idleDialogue.text.Split ('\n'));
					if (currentLine == 0 || currentLine == 2) {
						SwitchToNpc ("Mother Bear");

					} else {
						SwitchToPc ();

					}
						
						
					if (foxTalkedto) {
					
						textLines = (questRequest.text.Split ('\n'));
						if (currentLine == 1 || currentLine == 3 || currentLine == 4 || currentLine == 6 || currentLine == 8 || currentLine == 9) {
							SwitchToNpc ("Mother Bear");

						} else {
							SwitchToPc ();

						}
							
					
					}
				}
				if (questStarted) {
					if (!objectiveCompleted && !bearCubTalkedto) {
						textLines = (questReminder.text.Split ('\n'));
						if (currentLine == 0 || currentLine == 2) {
							SwitchToNpc ("Mother Bear");

						} else {
							
							SwitchToPc ();
						}
							
					} else if (!objectiveCompleted && bearCubTalkedto) {
						textLines = (questReminderAlt.text.Split ('\n'));
						if (currentLine == 0 || currentLine == 2 || currentLine == 3) {
							SwitchToNpc ("Mother Bear");
						} else
							SwitchToPc ();
					}
					if (objectiveCompleted) {
						textLines = (objectiveCompletedDialogue.text.Split ('\n'));
						SwitchToNpc ("Mother Bear"); 	
					}
					
				}


				

				if (Input.GetKeyDown (KeyCode.Return)) {
					if (currentLine < textLines.Length)
						currentLine += 1;

					if (currentLine == endAtLine) {
						theText.enabled = false;
						panelController.enabled = false;
						chatEnabled = false;
						currentLine = 0;
						if (!questStarted && foxTalkedto) {
							questStarted = true;
						}
					}


			
				}
				theText.text = textLines [currentLine];
			} else if (charActive == CharacterChatActive.Fox) {
				SwitchToNpc ("Fox");
				npcPortrait.loadSprite ("Fox");
				NpcScript currentNpcScript = GetComponent<NpcScript> ();
				endAtLine = textLines.Length;
				if (!questStarted) {
					textLines = (idleDialogue.text.Split ('\n'));
					if (currentLine == 0 || currentLine == 2 || currentLine == 4 || currentLine == 6 || currentLine == 8 || currentLine == 10 || currentLine == 12 || currentLine == 13) {
						SwitchToNpc ("Fox");


					} else {

						SwitchToPc ();


					}
						
				}
				if (questStarted) {
					if (!currentNpcScript.doesCharHaveItemReq) {
						textLines = (questReminder.text.Split ('\n'));
						SwitchToNpc ("Fox");




					}
					if (currentNpcScript.doesCharHaveItemReq) {
						textLines = (objectiveCompletedDialogue.text.Split ('\n'));
						SwitchToNpc ("Fox");

						if (objectiveCompleted && altObjectiveCompleted != true) {
							textLines = (altObjectiveCompletedDialogue.text.Split ('\n'));
							if (currentLine == 1) {
								SwitchToNpc ("Fox");

							} else {
								SwitchToPc ();

							}
								
						}

						if (altObjectiveCompleted) {
							textLines = (altObjectiveCompletedDialogue2.text.Split ('\n'));
							if (currentLine == 0 || currentLine == 2 || currentLine == 4 || currentLine == 6)
								SwitchToNpc ("Fox");
							else
								SwitchToPc ();
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
						if (altObjectiveCompleted) {
							altObjectiveMet2 = true;

						}

						if (currentNpcScript.doesCharHaveItemReq)
							objectiveCompleted = true;
						playerScript.currentHeldItem = null;

						if (currentNpcScript.objectiveMet) {
							altObjectiveCompleted = true;
							currentNpcScript.altObjectiveMet = true;
						}

						if (objectiveCompleted && questStarted) {
							currentNpcScript.objectiveMet = true;
						}

					}
				}
			} else if (charActive == CharacterChatActive.Beaver) {
				npcPortrait.loadSprite ("beaver");
				NewChatScript questReliantNpc = GameObject.FindGameObjectWithTag ("NPC_MotherBear").GetComponent<NewChatScript> ();
				NpcScript currentNpcScript = GetComponent<NpcScript> ();
				theText.enabled = chatEnabled;
				panelController.ImageEnabled (chatEnabled);
				endAtLine = textLines.Length;

				if (questReliantNpc.questStarted != true || objectiveCompleted)
					SwitchToNpc ("Beaver");

				if (questReliantNpc.questStarted && bearCubTalkedto) {
					
					if (checkNum == 0) {
						currentLine = 0;
						checkNum += 1;
					}

					if (bearCubTalkedto) {
						textLines = (questRequest.text.Split ('\n'));
						if (currentLine == 1 || currentLine == 2 || currentLine == 4 || currentLine == 5 || currentLine == 6)
							SwitchToNpc ("Beaver");
						else 
							SwitchToPc ();
					}
					if (questStarted) {
						if (!currentNpcScript.doesCharHaveItemReq) {
							textLines = (questReminder.text.Split ('\n'));
							objectiveCompleted = false;
							if (currentLine == 1 || currentLine == 2)
								SwitchToNpc ("Beaver");
							else
								SwitchToPc ();
						}
						if (currentNpcScript.doesCharHaveSpecialItem)
						{
							textLines = (questReminderAlt.text.Split ('\n'));
							SwitchToNpc ("Beaver");
						}
						
						if (currentNpcScript.doesCharHaveItemReq) {
							textLines = (objectiveCompletedDialogue.text.Split ('\n'));
							objectiveCompleted = true;

							
						}
					
					}
				
					if (Input.GetKeyDown (KeyCode.Return)) {
						
						if (currentLine < textLines.Length)
							currentLine += 1;
						
						if (currentLine == endAtLine) {
							theText.enabled = false;
							chatEnabled = false;
							currentLine = 0;
							if (objectiveCompleted && questStarted) {
								currentNpcScript.objectiveMet = true;
							}
					

							if (!questStarted && bearCubTalkedto) {
								questStarted = true;
							}
							if (questStarted && currentNpcScript.doesCharHaveItemReq) {
								objectiveCompleted = true;
								playerScript.currentHeldItem = null;
							}
						}
					}


				} else {
					endAtLine = 1;

					
					
					if (Input.GetKeyDown (KeyCode.Return)) {
						
						if (!active) {
							active = true;
							
							
						}
						
						if (active) {
							chatEnabled = false;
							currentLine = Random.Range (0, textLines.Length);
							theText.enabled = false;

						}
					}





					
					
				}
				theText.text = textLines [currentLine];
			} else if (charActive == CharacterChatActive.BearCub) {
				npcPortrait.loadSprite ("bearCub");
				NewChatScript questReliantNpc = GameObject.FindGameObjectWithTag ("NPC_MotherBear").GetComponent<NewChatScript> ();
				NpcScript currentNpcScript = GetComponent<NpcScript> ();
				if (questReliantNpc.questStarted != true || questReliantNpc.questStarted == true && beaverTalkedto != true) {
					textLines = (idleDialogue.text.Split ('\n'));
					if (currentLine == 0)
						SwitchToNpc ("Bear Cub");
					else
						SwitchToPc ();
				}
				if (questReliantNpc.questStarted && beaverTalkedto) {
					textLines = (questRequest.text.Split ('\n'));
					if (currentLine == 0 || currentLine == 2)
						SwitchToNpc ("Bear Cub");
					else
						SwitchToPc ();
				}
				if (currentNpcScript.questReliantScript.objectiveMet) {
					textLines = (objectiveCompletedDialogue.text.Split ('\n'));
					SwitchToNpc ("Bear Cub");
				}
				theText.text = textLines [currentLine];
				
				endAtLine = textLines.Length;
				
				if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.L)) {
					if (currentLine < textLines.Length)
						currentLine += 1;
					
					if (currentLine == endAtLine) {
						theText.enabled = false;
						chatEnabled = false;
						theText.enabled = chatEnabled;
						charIdentifier.enabled = chatEnabled;

						if (currentNpcScript.questReliantScript.objectiveMet && objectiveCompleted != true) {
							objectiveCompleted = true;
							currentNpcScript.objectiveMet = true;
							panelController.ImageEnabled (false);
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



			PlayerScript playerConsole = other.GetComponent<PlayerScript> ();
			motherBearTalkedto = playerConsole.npcsTalkedTo [0];
			bearCubTalkedto = playerConsole.npcsTalkedTo [1];
			beaverTalkedto = playerConsole.npcsTalkedTo [2];
			foxTalkedto = playerConsole.npcsTalkedTo [3];
			ChatActive ();
			if (Input.GetButtonDown ("Interact")) {

				chatEnabled = true;


			}
		} 

	}
	void NPCLight()
	{
		npcImage.ImageLight();
		pcImage.ImageDarken();
	}
	void PCLight()
	{
		npcImage.ImageDarken();
		pcImage.ImageLight();
	}
	void SwitchToPc ()
	{
		charIdentifier.text = "Dylan";
		PCLight ();
	}
	void SwitchToNpc(string npcName)
	{
		charIdentifier.text = npcName;
		NPCLight ();
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
