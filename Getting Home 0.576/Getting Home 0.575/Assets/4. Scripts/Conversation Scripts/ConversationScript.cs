using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class ConversationEntry
{
	public string npcName;		//The name of the NPC talking
	public string dialogue;		//The text that the NPC actually says
	public Sprite playerIcon;	//The icon of the player in the conversation panel
	public Sprite npcIcon;		//The icon of the NPC in the conversation panel
	public bool rightFaded;		//Checks whether or not the conversation has a fade-out-in ending
}

public class ConversationScript : MonoBehaviour 
{
	public List <ConversationEntry> conversationEntries = new List<ConversationEntry>();
	
	public Action conversationFadedOut;
	public Action conversationFininshed;
	
	public bool fadeOutConversation;
}
