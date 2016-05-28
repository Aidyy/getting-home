using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventFadeScript : MonoBehaviour 
{
	public float alphaLevel = 1;			//set the parent gameobject's alpha value
	public Image fadeImg;					//the fade image's gameobject on the canvas

	public IEnumerator DecreaseAlphaCoroutine()
	{
		alphaLevel = Mathf.Clamp (alphaLevel, 0.5f, 1f);
		yield return alphaLevel -= 1f;
		fadeImg.color = new Color (1,1,1,alphaLevel);
	}
	
	public IEnumerator IncreaseAlphaCoroutine()
	{
		alphaLevel = Mathf.Clamp (alphaLevel, 0.5f, 1f);
		yield return alphaLevel += 1f;
		fadeImg.color = new Color (1,1,1,alphaLevel);
	}
}

















