using UnityEngine;
using System.Collections;

public class animalAnimController : MonoBehaviour {

	bool animSquirrelIdle;
	bool animSquirrelScurry;

	public Animator anim;
	// Use this for initialization
	void Start () {
		animSquirrelIdle = true;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("SquirrelIdle", animSquirrelIdle);
		anim.SetBool ("SquirrelScurry", animSquirrelScurry);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			animSquirrelScurry = true;
			Debug.Log("PlayerEntered");
		}
	}
}
