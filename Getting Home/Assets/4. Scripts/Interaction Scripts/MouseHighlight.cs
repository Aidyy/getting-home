using UnityEngine;
using System.Collections;

public class MouseHighlight : MonoBehaviour 
{
	//This script manages the mouse highlighting, currently unfinished.

	private float blueMultiply = 3.50f;				
	private float redGreenMultiply = 0.50f;			
	
	private Color originalColor;					//A reference to the object's original colour.
	private Renderer rend;							//A reference to the object's renderer.
	
	private void Start()
	{
		rend = gameObject.GetComponent<Renderer>();
		originalColor = rend.material.color;
	}
	
	void OnMouseEnter()
	{
		AddHighlight();
	}
	
	void OnMouseExit()
	{
		RemoveHighlight();
	}
	
	private void  AddHighlight()
	{
		float red = originalColor.r * redGreenMultiply;
		float blue = originalColor.b * blueMultiply;
		float green = originalColor.g * redGreenMultiply;
		
		rend.material.color = new Color(red, green, blue);
	}
	
	private void RemoveHighlight()
	{
		rend.material.color = originalColor;
	}
}