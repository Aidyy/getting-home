using UnityEngine;
using System.Collections;

public class TargetCheck : MonoBehaviour {

	public Transform targetTransform;
	public Vector3 targetPosTransform;
	// Use this for initialization
	void Start () {
		targetTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		targetPosTransform = targetTransform.position;
	}
}
