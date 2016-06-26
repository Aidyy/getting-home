using UnityEngine;
using System.Collections;

public class QualitySettingsManager : MonoBehaviour 
{
	//VSync will syncronise rendering with the framerate to reduce visual tearing. There are three options for this setting in Unity, and we're allowing users to choose from all three.
	//VSync will affect the framerate by limiting it to the monitor's refresh rate, and can potentially delay player input as a result, however the FPS cost is minimal and unnoticeable.
	void VSyncSetting()
	{
		QualitySettings.vSyncCount = 0; //Vsync Off
		QualitySettings.vSyncCount = 1; //Every V-blank
		QualitySettings.vSyncCount = 2; //Every second V-blank
	}

	//Anti-Aliasing improves the edges of objects so that they appear much smoother on-screen, as well as the memory consumption of the GPU.
	//AA will affect the framerate more significantly than VSync, however modern GPUs can handle AA in a much better way, and the majority have AA enabled through their drivers by default.
	//This is a safety net for users who don't have AA enabled in their graphics drivers. 
	void AntiAliasSetting()
	{
		QualitySettings.antiAliasing = 0; //AA off
		QualitySettings.antiAliasing = 2; //AA x2
		QualitySettings.antiAliasing = 4; //AA x4
		QualitySettings.antiAliasing = 8; //AA x8
	}

	//Anisotropic Filtering will determine whether or not anisotropic textures will be used and how.
	void AnisotropicFilteringOptions()
	{
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;			//Anisotropic On
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;	//Anisotropic Forced On
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;		//Anisotropic Off
	}

	//The maxed queued framerate will allow users to decide whether or not they get a faster input at the potential loss of framerate. The setting is not guaranteed to work 100% of the time
	//and should really be used by users who are using multiple GPUs. 
	//It essentially boils down to the higher the setting, the highter the FPS but the slower the input. The lower the setting, the lower the FPS but the higher the input.
	void MaxedQueuedFramesSetting()
	{
		QualitySettings.maxQueuedFrames = 0; //No queued frames
		QualitySettings.maxQueuedFrames = 1; //1 queued frame
		QualitySettings.maxQueuedFrames = 2; //2 queued frames
	}
}
