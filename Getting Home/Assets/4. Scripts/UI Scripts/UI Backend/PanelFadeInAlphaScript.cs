using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelFadeInAlphaScript : MonoBehaviour 
{
	public CanvasGroup myCanvasGroup;
	private bool fadeIn;
	
	void Start()
	{
		fadeIn = true;
		myCanvasGroup.alpha = 0f;
	}
	
	void Update()
	{
		StartCoroutine ("FadeIn");
	}

	public IEnumerator FadeIn()
	{
		if (fadeIn)
		{
			myCanvasGroup.alpha = myCanvasGroup.alpha + Time.deltaTime;
			if (myCanvasGroup.alpha >= 1)
			{
				myCanvasGroup.alpha = 1;
				fadeIn = false;
			}
		}

		yield return null;
	}
}
