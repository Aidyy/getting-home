using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class DialogueUIScript : MonoBehaviour 
{
	public Image npcImage;
	public Image playerImage;
	public Text titleText;
	public Text bodyText;
	bool rightFaded;

	Action NextPressed;

	void Start()
	{
		if (npcImage == null) {
			npcImage = transform.FindChild("DialoguePanel/ModalDialoguePanel/NPCImage").GetComponent<Image>();
		}

		if (playerImage == null) {
			playerImage = transform.FindChild("DialoguePanel/ModalDialoguePanel/PlayerImage").GetComponent<Image>();
		}

		if (titleText == null) {
			titleText = transform.FindChild("DialoguePanel/ModalDialoguePanel/TitleText").GetComponent<Text>();
		}

		if (bodyText == null) {
			bodyText = transform.FindChild("DialoguePanel/ModalDialoguePanel/BodyText").GetComponent<Text>();
		}
	}

	public void NewNode(string newTitle, string newBody, Sprite newNPCImage, Sprite newPlayerImage, bool isRightFaded, Action nextPressed)
	{
		titleText.text = newTitle;
		bodyText.text = newBody;
		npcImage.sprite = newNPCImage;
		playerImage.sprite = newPlayerImage;

		if (nextPressed != null) 
		{
			NextPressed += nextPressed;
		}
	}

	void NextButtonPressed()
	{
		if (NextPressed != null) 
		{
			NextPressed();
		}
	}
}
