using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPickedUp : MonoBehaviour {

	public Sprite Item_Axe;
	public Sprite Item_Key;
	public Sprite Item_PerfectLog;
	public Sprite Item_BadLog;
	string tempItem;

	public GameObject imagePanel;
	public Image image_Axe;
	public Image image_Key;
	public Image image_PerfectLog;
	public Image image_BadLog;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerScript parentScript = GetComponentInParent<PlayerScript> ();
		if (parentScript.currentHeldItem == "nothingHeld") 
		{
			spriteRenderer.sprite = null;

			imagePanel.SetActive(false);
			image_Axe.enabled = false;
			image_Key.enabled = false;
			image_PerfectLog.enabled = false;
			image_BadLog.enabled = false;
		} 
		else if (parentScript.currentHeldItem == "Item_BadLog") 
		{
			spriteRenderer.sprite = Item_BadLog;

			imagePanel.SetActive(true);
			image_Axe.enabled = false;
			image_Key.enabled = false;
			image_PerfectLog.enabled = false;
			image_BadLog.enabled = true;
		} 
		else if (parentScript.currentHeldItem == "Item_Key") 
		{
			spriteRenderer.sprite = Item_Key;

			imagePanel.SetActive(true);
			image_Axe.enabled = false;
			image_Key.enabled = true;
			image_PerfectLog.enabled = false;
			image_BadLog.enabled = false;
		} 
		else if (parentScript.currentHeldItem == "Item_PerfectLog") 
		{
			spriteRenderer.sprite = Item_PerfectLog;

			imagePanel.SetActive(true);			
			image_Axe.enabled = false;
			image_Key.enabled = false;
			image_PerfectLog.enabled = true;
			image_BadLog.enabled = false;
		} 
		else if (parentScript.currentHeldItem == "Item_Axe") 
		{
			spriteRenderer.sprite = Item_Axe;

			imagePanel.SetActive(true);
			image_Axe.enabled = true;
			image_Key.enabled = false;
			image_PerfectLog.enabled = false;
			image_BadLog.enabled = false;
		} 
		else if (parentScript.currentHeldItem == null) 
		{
			spriteRenderer.sprite = null;
		}
	}
}





