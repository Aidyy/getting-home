using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventFadeScript : MonoBehaviour
{
	public Image fadeImg;
	public float fadeSpeed = 0f;	

	public void FadeToClear()
	{
		// Lerp the colour of the image between itself and transparent.
		fadeImg.color = Color.Lerp(fadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	public void FadeToBlack()
	{
		// Lerp the colour of the image between itself and black.
		fadeImg.color = Color.Lerp(fadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
	}
}