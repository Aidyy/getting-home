using UnityEngine;
using System.Collections;

public class BringToFront : MonoBehaviour 
{
	//this makes the attached script to be on the very top - it'll be rendered last, just in case something happens with the UI

	void OnEnable()
	{
		transform.SetAsLastSibling();	//draws the attached gameobject last
	}
}
