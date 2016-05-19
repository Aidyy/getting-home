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

	EventSpriteEnabler barren;
	EventSpriteEnabler stump;
	EventSpriteEnabler barrenFallen;
	EventSpriteEnabler barrenStump;


	// Use this for initialization
	void Start () {
		ScriptAttacher ();
		barren = BarrenTree.GetComponent<EventSpriteEnabler> ();
		stump = barrenTreeStump.GetComponent<EventSpriteEnabler>();
		barrenFallen = barrenTreeFallen.GetComponent<EventSpriteEnabler> ();
		barrenStump = barrenTreeStump2.GetComponent<EventSpriteEnabler> ();
	}
	
	// Update is called once per frame
	void Update () {

//		if (foxScript.altObjectiveMet2) {
//			Application.LoadLevel("Menu");
//		}
		bearCubObjCompleted = bearCubScript.objectiveMet;
		if (foxChatScrupt.altObjectiveMet2)
		{
			Application.LoadLevel("Menu");
		}
		if (beaverObjCompleted) {


			if (BarrenTree != null)
			{
			barren.DestroyObject ();
			}
			if (barrenTreeStump != null)
			stump.DestroyObject();

			if(barrenFallen != null)
			barrenFallen.SpriteEnable();

			if (barrenStump != null)
			barrenStump.SpriteEnable();


		}

		if (bearCubObjCompleted) {
			motherBearScript.objectiveMet = true;
			bearChatScript.objectiveCompleted = true;
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
}
