using UnityEngine;
using System.Collections;

public class FadingScript : MonoBehaviour 
{
	public Texture2D fadeOutTexture;		//The texture that will overlay the screen, this will probably just be a black image, but can be a loading screen
	public float fadeSpeed = 0.8f;			//The fading speed
	
	private float alpha = 1.0f;				//The texture's alpha value between 0 and 1
	private int drawDepth = -1000;			//The texture's draw order in the hierarchy; a low number means it renders on top
	private int fadeDir = -1;				//The direction to fade; in is -1, and out is 1
	
	//We should look at putting this into the level manager (formerly the enemy manager), it'll be cool, but it's polish, really
	
	void OnGUI()
	{
		//Fade out/in the alpha value using a direction, a speed, and Time.deltatime
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		
		//Clamp the value to be between 0 and 1. GUI.colour uses alpha values between 0 and 1
		alpha = Mathf.Clamp01(alpha);
		
		//Set colour of our GUI - the texture. All colour values remain the same and the Alpha is set to the alpha variable
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);					//Setting the alpha value
		GUI.depth = drawDepth;																	//Have the black texture render on top (last)
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);			//Draw the texture to fit the entire screen area
	}
	
	//Sets the fadeDir tot he direction parameter making the scene fade in if it's -1, and out if it's 1
	public float BeginFade(int direction)
	{
		fadeDir = direction;
		return (fadeSpeed);		//Returns the fadeSpeed variable so that it's easy to time the Application.LoadLevel();
	}
	
	//OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in certain scenes
	void OnlevelWasLoaded()
	{
		//alpha = 1;		//Use this if the alpha is not set to 1 by default
		BeginFade(-1);		//Call the fade in function
	}
}
