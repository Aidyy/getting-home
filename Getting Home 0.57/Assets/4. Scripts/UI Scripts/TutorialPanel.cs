using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TutorialPanel : MonoBehaviour 
{
	#region Variables
	private ModalPanel modalPanel;			//private reference to the ModalPanel
	private DisplayManager displayMan;		//private reference to the DisplayManager

	public Sprite icon;						//a reference to the panel icon
	public Transform spawnPoint;			//a spawnpoint for the item in question
	public GameObject spriteToSpawn;		//the actual game object that'll be spawned

	private UnityAction myYesAction;		//
	private UnityAction myNoAction;			//the declaration of the yes/no/cancel variables, which will call what will happen when the buttons are pressed (see below for example)
	private UnityAction myCancelAction;		//
	#endregion

	void Awake()
	{
		modalPanel = ModalPanel.Instance();
		displayMan = DisplayManager.Instance();

		myYesAction = new UnityAction(TestYesFunc);			//
		myNoAction = new UnityAction(TestNoFunc);			//unityactions are assigned to their respective functions
		myCancelAction = new UnityAction(TestCancelFunc);	//
	}

	#region WrappedVariables
	//these are all 'wrapped', they're sent to the ModalPanelWindow in the inspector, also see in Awake
	void TestYesFunc()
	{
		displayMan.DisplayMessage("Yeah!");
	}
	
	void TestNoFunc()
	{
		displayMan.DisplayMessage("Nope!");
	}
	
	void TestCancelFunc()
	{
		displayMan.DisplayMessage("I don't know, cancel!");
	}
	#endregion

	#region Panels
	public void TestQuitPanel()
	{
		modalPanel.Choice ("Are you sure you want to quit?", myYesAction, myNoAction);
	}
	#endregion
}







