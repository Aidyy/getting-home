using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class TestModalPanel : MonoBehaviour 
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

	public void TestYNC()
	{
		//this uses the constructor defined in the ModalPanel script, see there for more details - this just takes the actions declared in the functions below and executes them
		modalPanel.Choice("Do you want to do a thing?\nAre you sure?", myYesAction, myNoAction, myCancelAction);
	}

	public void TestIconYNC()
	{
		//this uses the constructor defined in the ModalPanel script, see there for more details - this just takes the actions declared in the functions below and executes them
//		modalPanel.Choice("Do you like the iocn?", icon, myYesAction, myNoAction, myCancelAction);

		ModalPanelDetails modalPanelDetails = new ModalPanelDetails {title = "Important!", question = "Do you like this icon?", iconImage = icon};

		modalPanelDetails.button1Details = new EventButtonDetails {buttonTitle = "Hell yeah!", action = TestYesFunc};
		modalPanelDetails.button2Details = new EventButtonDetails {buttonTitle = "Hell no!", action = TestNoFunc};
		modalPanelDetails.button3Details = new EventButtonDetails {buttonTitle = "Cancel, go away!", action = TestCancelFunc};

		modalPanel.NewChoice (modalPanelDetails);
		
	}

	//testing initialisers
	public void TestIC()
	{
		//this initialiser deals with the elements that will appear on the panel
		ModalPanelDetails modalPanelDetails = new ModalPanelDetails {iconImage = icon, question = "This is an announcement about my lovely new icon"};
		//this initialiser deals with the elemtsn that will appear on the button
		modalPanelDetails.button1Details = new EventButtonDetails {buttonTitle = "Attention!", action = TestCancelFunc};

		modalPanel.NewChoice(modalPanelDetails);
//		modalPanel.Choice ("This is an announcement", myCancelAction, icon);
	}

	//this is a lambda, lambdas essentially make a function into a variable, allowing us to create objects through the UI as demonstrated below (this isn't the only way, it's just a way I was shown)
	public void TestLambda()
	{
		modalPanel.Choice("Do you want to create this rock?", () => {InstantiateObject (spriteToSpawn);}, myNoAction); 

		//lambda syntax: () => {Function (argument);}
	}

	//a test lambda to spawn 2 objects at once
	public void TestLambda2()
	{
		modalPanel.Choice("Do you want to create two things?", () => {InstantiateObject (spriteToSpawn, spriteToSpawn);}, myNoAction); 
	}

	//this lambda utilises the same functions used in the Lambdas above, rather than creating a new function which takes 3 arguments (saves space)
	public void TestLambda3()
	{
		modalPanel.Choice("Do you want to create three things?", () => {InstantiateObject (spriteToSpawn); InstantiateObject (spriteToSpawn, spriteToSpawn);}, myNoAction); 
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

	//this links to the lambda, this is where the object is spawned
	void InstantiateObject(GameObject instantiatedSprite)
	{
		displayMan.DisplayMessage("Here you go, have the thing");
		Instantiate(instantiatedSprite, spawnPoint.position, spawnPoint.rotation);
	}

	//and again, this is for the lambda that spawns 2 objects
	void InstantiateObject(GameObject instantiatedSprite, GameObject instantiatedSprite2)
	{
		displayMan.DisplayMessage("Here you go, have the thing");
		Instantiate(instantiatedSprite, spawnPoint.position - Vector3.one, spawnPoint.rotation);
		Instantiate(instantiatedSprite2, spawnPoint.position + Vector3.one, spawnPoint.rotation);
	}
}
