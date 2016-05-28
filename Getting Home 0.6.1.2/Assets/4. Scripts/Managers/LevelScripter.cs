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

		eventFadingScript.StartCoroutine("DecreaseAlphaCoroutine");
	}
	
	// Update is called once per frame
	void Update () 
	{
		bearCubObjCompleted = bearCubScript.objectiveMet;

		if (foxChatScrupt.altObjectiveMet2)
		{
			eventFadingScript.StartCoroutine("IncreaseAlphaCoroutine");			
			Application.LoadLevel("Menu");

		}
		if (beaverObjCompleted && trigger1 == false) 
		{
			Debug.Log ("Decreasing the alpha");
			eventFadingScript.StartCoroutine("IncreaseAlphaCoroutine");

			if (BarrenTree != null)
			{
				Destroy (BarrenTree);
			}

			if(barrenFallen != null)
			barrenFallen.SpriteEnable();

			if (barrenStump != null)
			barrenStump.SpriteEnable();

			StartCoroutine("FadeIn");
			beaverObjCompleted = false ;
			trigger1 = true;
		}
		if (bearCubObjCompleted) 
		{
			motherBearScript.objectiveMet = true;
			bearChatScript.objectiveCompleted = true;
		}
	}

	void FadeManager()
	{
		eventFadingScript.StartCoroutine("DecreaseAlphaCoroutine");
	}

	IEnumerator FadeIn()
	{
		yield return new WaitForSeconds(5);
		Debug.Log ("I'm increasing the alpha now");
		eventFadingScript.StartCoroutine("DecreaseAlphaCoroutine");
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
}
