using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CaveFadeScript : MonoBehaviour 
{
	public float alphaLevel = 1;			//set the parent gameobject's alpha value

	void Start()
	{
		alphaLevel = Mathf.Clamp (alphaLevel, 0.5f, 1f);
	}

	IEnumerator DecreaseAlphaCoroutine()
	{
		yield return alphaLevel -= .8f;
		GetComponent<SpriteRenderer> ().color = new Color (1,1,1,alphaLevel);
	}

	IEnumerator IncreaseAlphaCoroutine()
	{
		yield return alphaLevel += .8f;
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alphaLevel);
	}

	//whenever the player enters the trigger zone for the gameobject, then it'll fade out
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			StartCoroutine("DecreaseAlphaCoroutine");
			Debug.Log ("Run coroutine");
		}
	}

	//and then fade back in once the player exits it
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine("IncreaseAlphaCoroutine");
			Debug.Log ("Run coroutine");
		}
	}
}






















