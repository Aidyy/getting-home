using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EventSpriteEnabler : MonoBehaviour {

	// Use this for initialization

	Image portraitImage;
	public Sprite motherBearPortrait;
	public Sprite bearCubPortrait;
	public Sprite foxPortrait;
	public Sprite beaverPortrait;
	SpriteRenderer sprite;
	BoxCollider collider;
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		portraitImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	public void DestroyObject()
	{
		Destroy (gameObject);
	}

	public void SpriteEnable()
	{
		sprite.enabled = true;
	}
	public void SpriteDisable()
	{
		sprite.enabled = false;
	}

	public void ImageLight()
	{
		GetComponent<UnityEngine.UI.Image>().color = Color.white;
	}

	public void ImageDarken()
	{
		GetComponent<UnityEngine.UI.Image>().color = Color.grey;
	}
	public void ImageEnable()
	{
		portraitImage.enabled = true;
	}
	public void imageDisable()
	{
		portraitImage.enabled = false;
	}
	public void loadSprite(string animal)
	{
		if (animal == "Fox")
			portraitImage.sprite = foxPortrait;

		if (animal == "beaver")
			portraitImage.sprite = beaverPortrait;

		if (animal == "bearCub")
			portraitImage.sprite = bearCubPortrait;

		if (animal == "motherBear")
			portraitImage.sprite = motherBearPortrait;
	}
}
