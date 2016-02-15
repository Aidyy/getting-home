using UnityEngine;
using System.Collections;

public class DevMenu : MonoBehaviour 
{
	public PlayerScript player;

	float speedUp = 5;
	float speedDown = 1;
	float playerNormSpeed = 2;

	// Use this for initialization
	void Start () 
	{
		player = gameObject.GetComponent<PlayerScript>(); 
	}

	public void NormalPlayerSpeed()
	{
		player.speed = playerNormSpeed;
	}

	public void SuperSpeed()
	{
 		player.speed += speedUp * Time.deltaTime;
	}

	public void SuperSlow()
	{
		player.speed -= speedDown * Time.deltaTime;
	}

//	public void ForceNextLevel()
//	{
//
//	}
//
//	public void ForcePreviousLevel()
//	{
//
//	}

	public void ForceExit()
	{
		Application.Quit();
	}
}
