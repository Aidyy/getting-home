using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventFadeScript : MonoBehaviour 
{
	public CanvasGroup fadeImg;

	public IEnumerator DecreaseAlphaCoroutine()
	{
		while (fadeImg.alpha < 1) 
		{
			Debug.Log("new fade in script alpha is " + fadeImg.alpha);
			fadeImg.alpha = Mathf.MoveTowards(fadeImg.alpha, 1, 1 * Time.deltaTime);
			yield return null;		
		}

		Debug.Log ("finished decreasing alpha");
	}

	public IEnumerator IncreaseAlphaCoroutine()
	{
		while (fadeImg.alpha > 0) 
		{
			Debug.Log("new fade in script alpha is " + fadeImg.alpha);
			fadeImg.alpha = Mathf.MoveTowards(fadeImg.alpha, 0, 1 * Time.deltaTime);
			yield return null;		
		}	

		Debug.Log ("finished increasing alpha");
	}
}


















