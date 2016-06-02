using UnityEngine;
using System.Collections;

public class FadeCaller : MonoBehaviour 
{
	EventFadeScript fadeManager;
	
	void Start () 
	{
		fadeManager = GetComponent<EventFadeScript>();
	}

	void Update () 
	{
		fadeManager.StartCoroutine("DecreaseAlphaCoroutine");
	}
}
