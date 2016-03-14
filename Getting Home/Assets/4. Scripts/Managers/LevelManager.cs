using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	TestModalPanel modalPanel;
	public GameObject modalPanelObj;

	void Start()
	{
//		modalPanel = GetComponent<TestModalPanel>();

//		modalPanel.enabled = false;
		modalPanelObj.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.G)) 
		{
			NextLevel();
		}

		if (Input.GetKey (KeyCode.Escape)) 
		{
//			modalPanel.enabled = true;
			modalPanelObj.SetActive(true);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			NextLevel();
		}
	}

	public void NextLevel()
	{
		int i = Application.loadedLevel;

		Application.LoadLevel (i + 1);
	}

	public void QuitGame()
	{
		Debug.Log ("Quitting...");
		Application.Quit();
		Debug.Log ("Quit");
	}

	public void CancelQuitMenu()
	{
		modalPanelObj.SetActive (false);
//		modalPanel.enabled = false;
	}
}
