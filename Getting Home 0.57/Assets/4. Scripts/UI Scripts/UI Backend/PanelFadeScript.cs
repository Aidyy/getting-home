using UnityEngine;
using System.Collections;

public class PanelFadeScript : MonoBehaviour 
{
	public CanvasGroup myCanvasGroup;

	
	// Use this for initialization
	void Start () 
	{
	}
	
	public IEnumerator FadeIn()
	{
		while (myCanvasGroup.alpha < 1) 
		{
			Debug.Log(myCanvasGroup.alpha);
			myCanvasGroup.alpha = Mathf.MoveTowards(myCanvasGroup.alpha, 1, 1 * Time.deltaTime);
			yield return null;		
		}
		Debug.Log ("finished");
	}

	public IEnumerator FadeOut()
	{
		while (myCanvasGroup.alpha > 0) 
		{
			Debug.Log(myCanvasGroup.alpha);
			myCanvasGroup.alpha = Mathf.MoveTowards(myCanvasGroup.alpha, 0, 1 * Time.deltaTime);
			yield return null;		
		}	
		Debug.Log ("finished");
	}
}
