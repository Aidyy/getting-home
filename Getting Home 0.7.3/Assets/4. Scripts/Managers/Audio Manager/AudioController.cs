using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {
	public AudioMixerSnapshot ambiance;
	public AudioMixerSnapshot footsteps;
	public AudioMixerSnapshot dirtFootsteps;
	public AudioMixerSnapshot bridgeAmb;
	public AudioMixerSnapshot bridgeIdle;
	public AudioMixerSnapshot bridgeGrass;
	public AudioMixerSnapshot bridgeTorso;

	PlayerScript playerCheck;

	// Use this for initialization
	void Start () {
		playerCheck = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();
	}
	
	// Update is called once per frame
	void Update () {



		if (playerCheck.walkstate == false && playerCheck.bridgeTrigger != true) {
			Debug.Log ("play 2");
			
			PlaySound (2);
		} else if (playerCheck.walkstate && playerCheck.dirtTrigger == false && playerCheck.bridgeTrigger != true && playerCheck.bridgeTorsoTrigger != true) {
			PlaySound (1);
		} else if (playerCheck.walkstate && playerCheck.dirtTrigger == true && playerCheck.bridgeTrigger != true && playerCheck.bridgeTorsoTrigger != true) {
			Debug.Log ("play 3");
			
			PlaySound (3);
		} else if (playerCheck.walkstate && playerCheck.bridgeTrigger && playerCheck.dirtTrigger == false && playerCheck.bridgeTorsoTrigger != true) {
			PlaySound (6);
		} else if (playerCheck.bridgeTrigger == true && playerCheck.walkstate != true) {
			Debug.Log ("play 4");
			
			PlaySound (5);
		} else if (playerCheck.walkstate && playerCheck.bridgeTrigger && playerCheck.dirtTrigger == true && playerCheck.bridgeTorsoTrigger != true) {
			Debug.Log ("play 6");
			
			PlaySound (4);
		} else if (playerCheck.walkstate && playerCheck.bridgeTrigger && playerCheck.bridgeTorsoTrigger) {
			PlaySound (7);
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
		if (sound == 6) {
			bridgeGrass.TransitionTo (0f);
		}
		if (sound == 7) {
			bridgeTorso.TransitionTo (0f);
		}
	}

	}
