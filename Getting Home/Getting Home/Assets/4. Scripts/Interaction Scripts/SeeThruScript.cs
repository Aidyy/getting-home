using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeeThruScript : MonoBehaviour 
{
	float alphaLevel = 1;	//set the gameobject's alpha value

//	void Start()
//	{
//		alphaLevel = Mathf.Clamp (alphaLevel, 0.5f, 1f);	//clamp the minimum value to .5f and the maximum to 1f, to prevent and issues regarding over or under calculating
//	}

	void DecreaseAlpha()
	{	
		alphaLevel = Mathf.Clamp (alphaLevel, 0.5f, 1f);	//clamp the minimum value to .5f and the maximum to 1f, to prevent and issues regarding over or under calculating
		alphaLevel -= .5f;	//when called, this'll decrease the alphaLevel by .5f, bringing it from 1f down to .5f
		GetComponent<SpriteRenderer>().color = new Color (1,1,1,alphaLevel);
	}

	void IncreaseAlpha()
	{
		alphaLevel = Mathf.Clamp (alphaLevel, 0.5f, 1f);	//clamp the minimum value to .5f and the maximum to 1f, to prevent and issues regarding over or under calculating
		alphaLevel += .5f;	//when called, this'll increase the alphaLevel by .5f, bringing it from .5f up to 1f
		GetComponent<SpriteRenderer>().color = new Color (1,1,1,alphaLevel);
	}

	//whenever the player enters the trigger zone for the gameobject, then it'll fade out
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			DecreaseAlpha();
			Debug.Log ("done decreasing");
		}
	}

	//and then fade back in once the player exits it
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			IncreaseAlpha();
			Debug.Log ("done increasing");
		}
	}
}






















