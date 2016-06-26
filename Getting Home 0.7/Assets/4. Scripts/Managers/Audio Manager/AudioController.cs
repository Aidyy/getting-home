using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {
	public AudioMixerSnapshot ambiance;
	public AudioMixerSnapshot footsteps;
	public AudioMixerSnapshot dirtFootsteps;
	public AudioMixerSnapshot bridgeAmb;
	public AudioMixerSnapshot bridgeIdle;

	PlayerScript playerCheck;

	// Use this for initialization
	void Start () {
		playerCheck = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (playerCheck.walkstate == true && playerCheck.dirtTrigger == true) {
			PlaySound(3);
		}

		if (playerCheck.walkstate == false && playerCheck.bridgeTrigger != true) {
			PlaySound (2);
		} else if (playerCheck.walkstate && playerCheck.dirtTrigger != true) {
			PlaySound (1);
		} else if (playerCheck.bridgeTrigger == true && playerCheck.walkstate == false) {
			PlaySound(5);
		}
		else if (playerCheck.walkstate && playerCheck.bridgeTrigger) {
			PlaySound (4);
		} 



		

	}

	void PlaySound(int sound)
	{
		if (sound == 1) {
			footsteps.TransitionTo (0f);
		}
		if (sound == 2) {
			ambiance.TransitionTo (0f);
		}
		if (sound == 3) {
			dirtFootsteps.TransitionTo (0f);
		}
		if (sound == 4) {
			bridgeAmb.TransitionTo (0.05f);
		}
		if (sound == 5) {
			bridgeIdle.TransitionTo (0f);
		}
	}

	}
