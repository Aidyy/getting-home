using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeeThruScript : MonoBehaviour 
{
	public float stumpAlphaLevel = 1;		//set the child gameobject's alpha value
	public float alphaLevel = 1;			//set the parent gameobject's alpha value
	public GameObject treeStump;			//the child's gameobject

	void Start()
	{
		alphaLevel = Mathf.Clamp (alphaLevel, 0.5f, 1f);
		stumpAlphaLevel = Mathf.Clamp (stumpAlphaLevel, 0.5f, 1f);
	}

	IEnumerator DecreaseAlphaCoroutine()
	{
		yield return alphaLevel -= .5f;
		yield return stumpAlphaLevel -= .5f;
		GetComponent<SpriteRenderer> ().color = new Color (1,1,1,alphaLevel);
		treeStump.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1,1,1,stumpAlphaLevel);
	}

	IEnumerator IncreaseAlphaCoroutine()
	{
		yield return alphaLevel += .5f;
		yield return stumpAlphaLevel += .5f;
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alphaLevel);
		treeStump.gameObject.GetComponent<SpriteRenderer>().color = new Color (1,1,1,stumpAlphaLevel);
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






















