using UnityEngine;
using System.Collections;

public class ItemPickedUp : MonoBehaviour {

	public Sprite Item_Axe;
	public Sprite Item_Key;
	public Sprite Item_PerfectLog;
	public Sprite Item_BadLog;
	string tempItem;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		PlayerScript parentScript = GetComponentInParent<PlayerScript> ();
		if (parentScript.currentHeldItem == "nothingHeld") {
			spriteRenderer.sprite = null;
		} else if (parentScript.currentHeldItem == "Item_BadLog") {
			spriteRenderer.sprite = Item_BadLog;
		} else if (parentScript.currentHeldItem == "Item_Key") {
			spriteRenderer.sprite = Item_Key;
		} else if (parentScript.currentHeldItem == "Item_PerfectLog") {
			spriteRenderer.sprite = Item_PerfectLog;
		} else if (parentScript.currentHeldItem == "Item_Axe") {
			spriteRenderer.sprite = Item_Axe;
		}
		
	}
}
