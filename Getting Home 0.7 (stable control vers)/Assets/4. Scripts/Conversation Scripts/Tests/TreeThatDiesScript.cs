using UnityEngine;
using System.Collections;

public class TreeThatDiesScript : MonoBehaviour 
{
	public ConversationScript whoShouldIListenToToDie;

	// Use this for initialization
	void Start () 
	{
		if (whoShouldIListenToToDie != null) 
		{
			whoShouldIListenToToDie.conversationFadedOut += DoDie;
		}
	}
	
	void DoDie()
	{
		GetComponent<SpriteRenderer> ().color = Color.red;
	}
}
