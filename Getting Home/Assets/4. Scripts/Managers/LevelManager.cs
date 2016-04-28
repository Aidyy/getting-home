using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	TestModalPanel modalPanel;

	public GameObject modalPanelObj;
    public bool isPanelActive;

	void Start()
	{
		modalPanelObj.SetActive (false);
        isPanelActive = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.G)) 
		{
			NextLevel();
		}

		if (Input.GetKeyDown (KeyCode.T))
		{
			StartCoroutine("CallFade");
		}

		if (Input.GetKeyDown(KeyCode.Escape) && isPanelActive == false) 
		{
			isPanelActive = true;
			modalPanelObj.SetActive(true);
		}
        else if (Input.GetKeyDown(KeyCode.Escape) && isPanelActive == true)
        {
			isPanelActive = false;
            modalPanelObj.SetActive (false);
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
	}
}














