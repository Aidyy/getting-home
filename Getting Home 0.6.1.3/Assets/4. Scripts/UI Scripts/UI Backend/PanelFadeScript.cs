using UnityEngine;
using System.Collections;

public class PanelFadeScript : MonoBehaviour 
{
	public CanvasGroup myCanvasGroup;

	public IEnumerator FadeIn()
	{
		while (myCanvasGroup.alpha < 1) 
		{
			myCanvasGroup.alpha = Mathf.MoveTowards(myCanvasGroup.alpha, 1, 1 * Time.deltaTime);
			yield return null;		
		}
	}

	public IEnumerator FadeOut()
	{
		while (myCanvasGroup.alpha > 0) 
		{
			myCanvasGroup.alpha = Mathf.MoveTowards(myCanvasGroup.alpha, 0, 1 * Time.deltaTime);
			yield return null;		
		}	
	}
}
