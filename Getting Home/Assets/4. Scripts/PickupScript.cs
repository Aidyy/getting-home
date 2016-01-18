using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour 
{
	public float pickupDist = 1f;
	public Transform myTrans;

	void Start()
	{
		myTrans = transform;
	}

	public void Drop()
	{
		myTrans.parent = null;	//Reset the parent
//		carriedObj = null;		//PC hands are free once more
	}
	
	public void Pickup(Transform playerTrans)
	{
		myTrans.parent = playerTrans;
		myTrans.localPosition = new Vector3(0,1,1);
	}
}
