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
		barren = BarrenTree.GetComponent<EventSpriteEnabler> ();
		stump = barrenTreeStump.GetComponent<EventSpriteEnabler>();
		barrenFallen = barrenTreeFallen.GetComponent<EventSpriteEnabler> ();
		barrenStump = barrenTreeStump2.GetComponent<EventSpriteEnabler> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (beaverObjCompleted) {

			if (BarrenTree != null)
			{
			barren.DestroyObject ();
			}
			if (barrenTreeStump != null)
			stump.DestroyObject();
			barrenFallen.SpriteEnable();
			barrenStump.SpriteEnable();


		}
	}
}
