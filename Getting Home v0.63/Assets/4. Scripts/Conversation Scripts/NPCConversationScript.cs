//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using System.Collections;
//using System.Collections.Generic;
//using System;
//
//public class NPCConversationScript : MonoBehaviour 
//{
//	enum ConversationState
//	{
//		Opening,
//		Waiting,
//		OnComplete,
//		AlreadyComplete
//	};
//
//	ConversationState currentConvoState;
//
//	public ConversationScript openingConvo;
//	public ConversationScript waitingForCompleteConvo;
//	public ConversationScript onCompleteConvo;
//	public ConversationScript alreadyCompletedConvo;
//
//	bool playerIn;
//	bool currentlyInDialogue;
//	int currentConversationIndex;
//
//	List<ConversationEntry> CurrentDialogueList
//	{
//		get
//		{
//			switch (currentConvoState) 
//			{
//			case ConversationState.Opening:
//				return openingConvo.conversationEntries;
//				break;
//			}
//
//			return null;
//		}
//	}
//
//	public PlayerScript player;
//
//	DialogueUIScript dialogueUI;
//
//	public void Start()
//	{
//		GameObject uiObj = GameObject.FindGameObjectWithTag ("UI");
//
//		if (uiObj != null)
//		{
//			dialogueUI = uiObj.GetComponent<DialogueUIScript> ();
//		}
//
//		player = player.GetComponent<PlayerScript>();
//
//		player.enabled = true;	
//	}
//
//	public void Update()
//	{
//		if (Input.GetButtonDown("Fire1") && currentlyInDialogue == false && playerIn == true)
//		{
//			currentlyInDialogue = true;
//			currentConversationIndex = 0;
//
//			ConversationEntry convoEntry = CurrentDialogueList[currentConversationIndex];
//
//			dialogueUI.NewNode(convoEntry.npcName, convoEntry.dialogue, convoEntry.npcIcon, convoEntry.playerIcon, convoEntry.rightFaded, NextButtonPressed);
//		}
//	}
//
//	void NextButtonPressed()
//	{
//		currentConversationIndex ++;
//
//		if (currentConversationIndex >= CurrentDialogueList.Count) 
//		{
//			//End the conversation
//		} 
//		else 
//		{
//			ConversationEntry convoEntry = CurrentDialogueList[currentConversationIndex];
//			
//			dialogueUI.NewNode(convoEntry.npcName, convoEntry.dialogue, convoEntry.npcIcon, convoEntry.playerIcon, convoEntry.rightFaded, NextButtonPressed);
//		}
//	}
//
//	void OnTriggerEnter(Collider other)
//	{
//		if (other.tag == "Player") 
//		{
//			playerIn = true;
//		}
//	}
//
//	void OnTriggerExit(Collider other)
//	{
//		if (other.tag == "Player") 
//		{
//			playerIn = false;
//		}
//	}
//
//	//This disables the player script. Player will not be able to move whilst this is active. Don't active it at the same time as EnablePlayerScript as this'll just be overrided.
//	//Also ensure that this isn't executed in the player script!
//	public void DisablePlayerScript()
//	{
//		if (player.isActiveAndEnabled == true) 
//		{
//			player.enabled = false;	
//			Debug.Log ("Is player active? " + player.enabled);
//		}		
//	}
//
//	//This enables the player script. Player will be able to control the character again when active. Don't active it at the same time as DisablePlayerScript as this'll just be overrided.
//	//Also ensure that this isn't executed in the player script!
//	public void EnablePlayerScript()
//	{
//		if (player.isActiveAndEnabled == false) 
//		{
//			player.enabled = true;	
//			Debug.Log ("Is player active? " + player.enabled);
//		}
//	}
//}
//
//
//
//
//
//
//
