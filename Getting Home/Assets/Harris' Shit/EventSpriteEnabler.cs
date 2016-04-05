using UnityEngine;
using System.Collections;

public class EventSpriteEnabler : MonoBehaviour {

	// Use this for initialization

	SpriteRenderer sprite;
	BoxCollider collider;
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		
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
}
