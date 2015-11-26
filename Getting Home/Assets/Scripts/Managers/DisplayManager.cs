using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayManager : MonoBehaviour 
{
	//this script is from unity, it's not going to be vital to the actual project as it's only temporary for now whilst I sort out the UI - aidan 23/10/15
	//all this does is display text on-screen after an event happens, it's then called and displays the text that it's assigned to, which will then fade after a short while

	public Text displayText;
	public float displayTime;
	public float fadeTime;
	
	private IEnumerator fadeAlpha;
	
	private static DisplayManager displayManager;
	
	public static DisplayManager Instance () 
	{
		if (!displayManager) 
		{
			displayManager = FindObjectOfType(typeof (DisplayManager)) as DisplayManager;
			if (!displayManager)
			{
				Debug.LogError ("There needs to be one active DisplayManager script on a GameObject in your scene.");
			}
		}
		
		return displayManager;
	}
	
	public void DisplayMessage (string message) 
	{
		displayText.text = message;
		SetAlpha ();
	}
	
	void SetAlpha () 
	{
		if (fadeAlpha != null) 
		{
			StopCoroutine (fadeAlpha);
		}
		fadeAlpha = FadeAlpha ();
		StartCoroutine (fadeAlpha);
	}
	
	IEnumerator FadeAlpha () 
	{
		Color resetColor = displayText.color;
		resetColor.a = 1;
		displayText.color = resetColor;
		
		yield return new WaitForSeconds (displayTime);
		
		while (displayText.color.a > 0) 
		{
			Color displayColor = displayText.color;
			displayColor.a -= Time.deltaTime / fadeTime;
			displayText.color = displayColor;
			yield return null;
		}
		yield return null;
	}
}