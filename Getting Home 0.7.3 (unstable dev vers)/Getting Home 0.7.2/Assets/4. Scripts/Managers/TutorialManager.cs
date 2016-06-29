using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour 
{
	public PanelFadeScript moveTutorialPanel;
	public PanelFadeScript talkTutorialPanel;
	public PanelFadeScript hintTutorialPanel;
	

	void Start()
	{
		StartCoroutine("FadeMoveTut");
		StartCoroutine("FadeTalkTut");
		StartCoroutine("FadeHintTut");
	}

	public IEnumerator FadeMoveTut()
	{
		yield return new WaitForSeconds(3f);
		moveTutorialPanel.StartCoroutine("FadeIn");
		yield return new WaitForSeconds(5f);
		moveTutorialPanel.StartCoroutine("FadeOut");
	}

	public IEnumerator FadeTalkTut()
	{
		yield return new WaitForSeconds(9f);
		talkTutorialPanel.StartCoroutine("FadeIn");
		yield return new WaitForSeconds(5f);
		talkTutorialPanel.StartCoroutine("FadeOut");
	}

	public IEnumerator FadeHintTut()
	{
		yield return new WaitForSeconds(15f);
		hintTutorialPanel.StartCoroutine("FadeIn");
		yield return new WaitForSeconds(5f);
		hintTutorialPanel.StartCoroutine("FadeOut");
	}
}
