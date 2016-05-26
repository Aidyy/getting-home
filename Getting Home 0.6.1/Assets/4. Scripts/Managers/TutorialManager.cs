using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour 
{
	public PanelFadeScript moveTutorialPanel;
	public PanelFadeScript talkTutorialPanel;
	

	void Start()
	{
		StartCoroutine("FadeMoveTut");
		StartCoroutine("FadeTalkTut");
		
	}

	public IEnumerator FadeMoveTut()
	{
		yield return new WaitForSeconds(3f);
		moveTutorialPanel.StartCoroutine("FadeIn");
		yield return new WaitForSeconds(7f);
		moveTutorialPanel.StartCoroutine("FadeOut");
	}

	public IEnumerator FadeTalkTut()
	{
		yield return new WaitForSeconds(11f);
		talkTutorialPanel.StartCoroutine("FadeIn");
		yield return new WaitForSeconds(7f);
		talkTutorialPanel.StartCoroutine("FadeOut");
	}
}
