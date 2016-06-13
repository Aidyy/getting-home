using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Events;
using System.Collections;

public class ItemPickedUp : MonoBehaviour 
{
	public Sprite Item_Axe;
	public Sprite Item_Key;
	public Sprite Item_PerfectLog;
	public Sprite Item_BadLog;
	string tempItem;

	SpriteRenderer spriteRenderer;

	public Image image_axe;
	public Image image_key;
	public Image image_perfectlog;
	public Image image_badlog;


//	public PlayerScript playerScript;
	
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	//Aidan 13/06/16 - Updated this code to take the new way of showing the player that they picked something up. Everything else works exactly as it did before.
	//                 There are still ways we can optimise this, but it works for now so we should leave it until we do optimisation passes

	void Update () 
	{
		PlayerScript parentScript = GetComponentInParent<PlayerScript> ();

		if (parentScript.currentHeldItem == "nothingHeld") 
		{
			spriteRenderer.sprite = null;

			image_axe.enabled = false;
			image_key.enabled = false;
			image_perfectlog.enabled = false;
			image_badlog.enabled = false;
		} 
		else if (parentScript.currentHeldItem == "Item_BadLog") 
		{
			spriteRenderer.sprite = Item_BadLog;

			image_axe.enabled = false;
			image_key.enabled = false;
			image_perfectlog.enabled = false;
			image_badlog.enabled = true;
		} 
		else if (parentScript.currentHeldItem == "Item_Key") 
		{
			spriteRenderer.sprite = Item_Key;

			image_axe.enabled = false;
			image_key.enabled = true;
			image_perfectlog.enabled = false;
			image_badlog.enabled = false;
		} 
		else if (parentScript.currentHeldItem == "Item_PerfectLog") 
		{
			spriteRenderer.sprite = Item_PerfectLog;

			image_axe.enabled = false;
			image_key.enabled = false;
			image_perfectlog.enabled = true;
			image_badlog.enabled = false;
		} 
		else if (parentScript.currentHeldItem == "Item_Axe") 
		{
			spriteRenderer.sprite = Item_Axe;

			image_axe.enabled = true;
			image_key.enabled = false;
			image_perfectlog.enabled = false;
			image_badlog.enabled = false;
		} 
		else if (parentScript.currentHeldItem == null) 
		{
			spriteRenderer.sprite = null;
		}
	}
}
