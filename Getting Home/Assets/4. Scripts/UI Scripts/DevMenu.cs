using UnityEngine;
using System.Collections;

public class DevMenu : MonoBehaviour 
{

	public GameObject Trees;
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))
		{
			Trees.SetActive(false);
		}
		if(Input.GetKeyDown (KeyCode.P))
		{
			Trees.SetActive(true);
		}
	}
}
