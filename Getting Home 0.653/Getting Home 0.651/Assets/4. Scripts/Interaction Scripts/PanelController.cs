using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {
	Image panelEnabled;
	public bool testMode;
	// Use this for initialization
	void Start () {
		panelEnabled = gameObject.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	public void ImageEnabled(bool condition)
	{
		panelEnabled.enabled = condition;
	}
	

}
