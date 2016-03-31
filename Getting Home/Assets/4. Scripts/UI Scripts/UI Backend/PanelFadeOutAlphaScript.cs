using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelFadeOutAlphaScript : MonoBehaviour 
{
	public CanvasGroup myCanvasGroup;
	private bool fadeOut;
	
	void Start()
	{
		fadeOut = true;
		myCanvasGroup.alpha = 1f;
	}
	
	void Update()
	{
		StartCoroutine ("FadeOut");
	}
	
	public IEnumerator FadeOut()
	{
		if (fadeOut)
		{
			yield return new WaitForSeconds(3f);

			myCanvasGroup.alpha = myCanvasGroup.alpha + Time.deltaTime;
			if (myCanvasGroup.alpha >= 1)
			{
				myCanvasGroup.alpha = 0;
				fadeOut = false;
			}
		}

		yield return null;
	}
}
