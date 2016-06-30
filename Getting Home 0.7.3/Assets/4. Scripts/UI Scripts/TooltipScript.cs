using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TooltipScript : MonoBehaviour 
{
	#region Variables

	#region vSync Tool Tip Variables
	public GameObject vsyncOffToolTip;
	public GameObject vsyncOn1ToolTip;
	public GameObject vsyncOn2ToolTip;
	#endregion

	#region AA Tool Tip Variables
	public GameObject antialiasOffToolTip;
	public GameObject antialiasx2ToolTip;
	public GameObject antialiasx4ToolTip;
	public GameObject antialiasx8ToolTip;
	#endregion

	#region Aniso Tool Tip Variables
//	public GameObject anisoOffToolTip;
//	public GameObject anisoEnableToolTip;
//	public GameObject anisoForceToolTip;
	#endregion

	#region Post-Processing Variables
	public GameObject vignettingToolTip;
	public GameObject colourCorrectionToolTip;
	#endregion

	#region Max Queued Frames Variables
	public GameObject maxQueuedFrames0;
	public GameObject maxQueuedFrames2;
	public GameObject maxQueuedFrames4;
	#endregion

	#endregion

	#region vSync Tool Tips
	public void vSyncTipEnable()
	{
		vsyncOffToolTip.SetActive (true);
	}
	public void vSyncTipDisable()
	{
		vsyncOffToolTip.SetActive (false);
	}
	public void vSync1BlankTipEnable()
	{
		vsyncOn1ToolTip.SetActive (true);
	}
	public void vSync1BlankTipDisable()
	{
		vsyncOn1ToolTip.SetActive (false);
	}
	public void vSync2BlankTipEnable()
	{
		vsyncOn2ToolTip.SetActive (true);
	}
	public void vSync2BlankTipDisable()
	{
		vsyncOn2ToolTip.SetActive (false);
	}
	#endregion

	#region FXAA Tool Tips
	public void antiAliasOffToolTipEnable()
	{
		antialiasOffToolTip.SetActive (true);
	}
	public void antiAliasOffToolTipDisable()
	{
		antialiasOffToolTip.SetActive (false);
	}
	public void antiAliasx2ToolTipEnable()
	{
		antialiasx2ToolTip.SetActive (true);
	}
	public void antiAliasx2ToolTipDisable()
	{
		antialiasx2ToolTip.SetActive (false);
	}
	public void antiAliasx4ToolTipEnable()
	{
		antialiasx4ToolTip.SetActive (true);
	}
	public void antiAliasx4ToolTipDisable()
	{
		antialiasx4ToolTip.SetActive (false);
	}
	public void antiAliasx8ToolTipEnable()
	{
		antialiasx8ToolTip.SetActive (true);
	}
	public void antiAliasx8ToolTipDisable()
	{
		antialiasx8ToolTip.SetActive (false);
	}
	#endregion

	#region Aniso Tool Tips
//	public void anisoOffToolTipEnable()
//	{
//		anisoOffToolTip.SetActive (true);
//	}
//	public void anisoOffToolTipDisable()
//	{
//		anisoOffToolTip.SetActive (false);
//	}
//	public void anisoEnableToolTipEnable()
//	{
//		anisoEnableToolTip.SetActive (true);
//	}
//	public void anisoEnableToolTipDisable()
//	{
//		anisoEnableToolTip.SetActive (false);
//	}
//	public void anisoForcedToolTipEnable()
//	{
//		anisoForceToolTip.SetActive (true);
//	}
//	public void anisoForcedToolTipDisable()
//	{
//		anisoForceToolTip.SetActive (false);
//	}
	#endregion

	#region Post Processing Tool Tips
	public void VignettingTipEnable()
	{
		vignettingToolTip.SetActive (true);
	}
	public void VignettingTipDisable()
	{
		vignettingToolTip.SetActive (false);
	}
	public void ColourCorrectTipEnable()
	{
		colourCorrectionToolTip.SetActive (true);
	}
	public void ColourCorrectTipDisable()
	{
		colourCorrectionToolTip.SetActive (false);
	}
	#endregion

	#region Max Queued Frames Tool Tips
	public void NoMaxQueuedFramesEnable()
	{
		maxQueuedFrames0.SetActive (true);
	}
	public void NoMaxQueuedFramesDisable()
	{
		maxQueuedFrames0.SetActive (false);
	}
	public void TwoMaxQueuedFramesEnable()
	{
		maxQueuedFrames2.SetActive (true);
	}
	public void TwoMaxQueuedFramesDisable()
	{
		maxQueuedFrames2.SetActive (false);
	}
	public void FourMaxQueuedFramesEnable()
	{
		maxQueuedFrames4.SetActive (true);
	}
	public void FourMaxQueuedFramesDisable()
	{
		maxQueuedFrames4.SetActive (false);
	}
	#endregion
}





























