using UnityEngine;
using System.Collections;

public class DevMenu : MonoBehaviour 
{

	public GameObject treesGroup1;
	public GameObject treesGroup2;
	public GameObject rocksGroup1;
	public GameObject rocksGroup2;
	public GameObject bushesGroup1;
	public GameObject bushesGroup2;
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))
		{
			treesGroup1.SetActive(false);
			treesGroup2.SetActive(false);
			rocksGroup1.SetActive(false);
			rocksGroup2.SetActive(false);
			bushesGroup1.SetActive(false);
			bushesGroup2.SetActive(false);
			
		}

		if(Input.GetKeyDown (KeyCode.P))
		{
			treesGroup1.SetActive(true);
			treesGroup2.SetActive(false);
			rocksGroup1.SetActive(true);
			rocksGroup2.SetActive(true);
			bushesGroup1.SetActive(true);
			bushesGroup2.SetActive(false);
		}
	}
}
