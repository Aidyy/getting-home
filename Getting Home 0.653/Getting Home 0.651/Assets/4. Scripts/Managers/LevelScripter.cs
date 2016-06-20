﻿using UnityEngine;
using System.Collections;

public class LevelScripter : MonoBehaviour {

//	public GameObject Beaver;
//	public GameObject Fox;
//	public GameObject MotherBear;
//	public GameObject BearCub;
	public GameObject barrenTreeStump;
	public GameObject BarrenTree;
	public GameObject barrenTreeFallen;
	public GameObject barrenTreeStump2;

	public GameObject beaver;
	public GameObject motherBear;
	public GameObject fox;
	public GameObject bearCub;

	public EventFadeScript eventFadingScript;

	public NpcScript beaverScript;
	public NewChatScript beaverChatScript;
	public NpcScript motherBearScript;
	public NewChatScript motherBearChatScript;
	public NpcScript foxScript;
	public NpcScript bearCubScript;
	public NewChatScript bearCubChatScript;
	public NewChatScript foxChatScript;

	public bool beaverObjCompleted;
	public bool foxObjCompleted;
	public bool motherBearObjCompleted;
	public bool bearCubObjCompleted;
	public bool runOnceTrigger;
	public bool runOnceTriggerDeus;

	bool trigger1;

	EventSpriteEnabler barrenFallen;
	EventSpriteEnabler barrenStump;

	// Use this for initialization
	void Start () 
	{
		ScriptAttacher ();
		bool trigger = false;
		barrenFallen = barrenTreeFallen.GetComponent<EventSpriteEnabler> ();
		barrenStump = barrenTreeStump2.GetComponent<EventSpriteEnabler> ();
		eventFadingScript = eventFadingScript.GetComponent <EventFadeScript>();

		StartCoroutine("FadeToNormal");
	}

	void Update () 
	{
		bearCubObjCompleted = bearCubScript.objectiveMet;

		if (foxChatScript.altObjectiveMet2)
		{
			StartCoroutine("FoxObjComplete");
		}
		if (foxChatScript.altObjectiveCompleted && runOnceTriggerDeus != true)
		{
			StartCoroutine ("FoxObjCompleteInital");
		}
		if (foxChatScript.objectiveCompleted && runOnceTrigger != true )
		{
			StartCoroutine ("FoxObjCompleteInital");
		}
		if (beaverObjCompleted && trigger1 == false) 
		{
			StartCoroutine("BeaverObjComplete");
		}
		if (bearCubObjCompleted) 
		{
			StartCoroutine("BearObjComplete");
		}
	}

	void ScriptAttacher()
	{
		beaverScript = beaver.GetComponent<NpcScript> ();
		beaverChatScript = beaver.GetComponent <NewChatScript> ();
		motherBearScript = motherBear.GetComponent<NpcScript> ();
		motherBearChatScript = motherBear.GetComponent<NewChatScript> ();
		foxScript = fox.GetComponent<NpcScript> ();
		foxChatScript = fox.GetComponent<NewChatScript> ();
		bearCubScript = bearCub.GetComponent<NpcScript> ();
		bearCubChatScript = bearCub.GetComponent<NewChatScript>();
		motherBearChatScript = motherBear.GetComponent<NewChatScript> ();
		
	}

	//IEnumerators - Everything here is by Aidan on 02/06/16 unless otherwise stated

	//Controls the Beaver objective completion scenario
	IEnumerator BeaverObjComplete()
	{
		StartCoroutine ("FadeToBlack");

		yield return new WaitForSeconds(0.5f);
		if (BarrenTree != null)
		{
			Destroy (BarrenTree);
		}
		if (barrenFallen != null) 
		{
			barrenFallen.SpriteEnable ();
		}
		if (barrenStump != null) 
		{
			barrenStump.SpriteEnable ();
		}
		beaverObjCompleted = false ;
		trigger1 = true;
		yield return new WaitForSeconds(0.5f);

		StartCoroutine("FadeToNormal");
	}

	IEnumerator BearObjComplete()
	{
		yield return new WaitForSeconds(0.5f);
		motherBearScript.objectiveMet = true;
		motherBearChatScript.objectiveCompleted = true;
	}

	//Controls the Fox objective competion scenario and then quits to menu
	IEnumerator FoxObjCompleteInital()
	{Debug.Log ("running");
		StartCoroutine ("FadeToBlack");
		yield return new WaitForSeconds (2f);
		StartCoroutine("FadeToNormal");
		runOnceTrigger = true;
		if (foxChatScript.altObjectiveCompleted)
			runOnceTriggerDeus = true;

	}

	IEnumerator FoxObjComplete()
	{
		StartCoroutine("FadeToBlack");	
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevel("Menu");
	}

	//Controls the fade to black
	public IEnumerator FadeToBlack()
	{
		yield return new WaitForSeconds(0.1f);
		eventFadingScript.StartCoroutine("DecreaseAlphaCoroutine");
	}

	//Controls the fade to normal
	public IEnumerator FadeToNormal()
	{
		yield return new WaitForSeconds(0.1f);
		eventFadingScript.StartCoroutine("IncreaseAlphaCoroutine");
	}
}













