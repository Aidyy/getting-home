﻿using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour 
{
	public float pickupDist = 1f;
	public Transform myTrans;
	public string itemSecondaryTag;
	public SpriteRenderer spriteRenderer;
	public Sprite badLogSprite;
	public Sprite axeSprite;
	public Sprite keySprite;
	public Sprite perfectLogSprite;
	public Sprite originalSprite;

	bool pickUpTrigger;

	EventSpriteEnabler pickUpKey ;

	string heldItem;
	string lastHeldItem;

	PlayerScript spriteReliant;

	void Start()
	{  
		pickUpKey = GetComponentInChildren<EventSpriteEnabler> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = originalSprite;
		spriteReliant = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();

	}

	void Update()
	{
		if (pickUpTrigger) {
			pickUpKey.SpriteEnable ();
			if (Input.GetKeyDown (KeyCode.E)) {
				pickUpKey.SpriteDisable ();				
			}

		}
	}

	public void checkRefresh()
	{
		heldItem = spriteReliant.currentHeldItem;
		lastHeldItem = spriteReliant.lastHeldItem;
	}

	public void Drop()
	{
		myTrans.parent = null;	//Reset the parent
//		carriedObj = null;		//PC hands are free once more
	}
	public void SpriteUpdate()
	{  
		checkRefresh ();

		if (heldItem == "nothingHeld"|| heldItem == "null" || heldItem == null) {
			spriteRenderer.sprite = null;
//			itemSecondaryTag = null;
		} else if (heldItem == "Item_BadLog") {
			spriteRenderer.sprite = badLogSprite;
		} else if (heldItem == "Item_Key") {
			spriteRenderer.sprite = keySprite;
		} else if (heldItem == "Item_PerfectLog") {
			spriteRenderer.sprite = perfectLogSprite;
		} else if (heldItem == "Item_Axe") {
			spriteRenderer.sprite = axeSprite;
		}

	}
	public void SpriteDisable()
	{
		spriteRenderer.enabled = false;
	}
	
	public void Pickup(Transform playerTrans)
	{
		myTrans.parent = playerTrans;
		myTrans.localPosition = new Vector3(0,1,1);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && itemSecondaryTag != null)
		pickUpTrigger = true;					
	}
	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") {
			pickUpKey.SpriteDisable();
			pickUpTrigger = false;
		}

	}
}
