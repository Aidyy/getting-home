using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalPanel : MonoBehaviour 
{
	private ModalPanel modalPanel;			//private reference to the ModalPanel
	private DisplayManager displayMan;		//private reference to the DisplayManager

	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;

	void Awake()
	{
		modalPanel = ModalPanel.Instance();
		displayMan = DisplayManager.Instance();

		myYesAction = new UnityAction(TestYesFunc);			//
		myNoAction = new UnityAction(TestNoFunc);			//unityactions are assigned to their respective functions
		myCancelAction = new UnityAction(TestCancelFunc);	//
	}

	public void TestYNC()
	{
		//this uses the constructor defined in the ModalPanel script, see there for more details - this just takes the actions declared in the functions below and executes them
		modalPanel.Choice("Do you want to do a thing?\n Are you sure?", myYesAction, myNoAction, myCancelAction);
	}

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
}
