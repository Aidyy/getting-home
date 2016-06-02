using UnityEngine;
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
	public NpcScript motherBearScript;
	public NpcScript foxScript;
	public NpcScript bearCubScript;
	NewChatScript bearChatScript;
	NewChatScript foxChatScrupt;

	public bool beaverObjCompleted;
	public bool foxObjCompleted;
	public bool motherBearObjCompleted;
	public bool bearCubObjCompleted;

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

		if (foxChatScrupt.altObjectiveMet2)
		{
			StartCoroutine("FoxObjComplete");
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
		motherBearScript = motherBear.GetComponent<NpcScript> ();
		foxScript = fox.GetComponent<NpcScript> ();
		foxChatScrupt = fox.GetComponent<NewChatScript> ();
		bearCubScript = bearCub.GetComponent<NpcScript> ();
		bearChatScript = motherBear.GetComponent<NewChatScript> ();
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
		bearChatScript.objectiveCompleted = true;
	}

	//Controls the Fox objective competion scenario and then quits to menu
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













