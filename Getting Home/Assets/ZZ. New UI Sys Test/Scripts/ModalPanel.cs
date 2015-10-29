using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ModalPanel : MonoBehaviour 
{
	public Text questionText;
	public Image iconImage;
	public Button yesButton;
	public Button noButton;
	public Button cancelButton;
	public GameObject modalPanelObj;
	
	private static ModalPanel staticModalPanel;		//a private and static reference to the ModalPanel

	//you'll reference this singleton when you want access to this script, this is an instance of the above variable
	public static ModalPanel Instance()
	{
		//if the modal panel exists in the game...
		if (!staticModalPanel)
		{
			//...then locate it
			staticModalPanel = FindObjectOfType(typeof (ModalPanel)) as ModalPanel;

			//and this checks again, there must be one, and only one
			if (!staticModalPanel)
			{
				Debug.LogError("There needs to be one active ModalPanel script on a GameObject in the scene"); 
			}
		}
		return staticModalPanel;
	}

	//this will:       ask a question   create event on yes    create event on no  & create event on cancel
	public void Choice(string question, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
	{
		modalPanelObj.SetActive(true);						//turns on the panel

		yesButton.onClick.RemoveAllListeners();				//this removes any possibility that the yesButton is 'listening' for a particular event, creates a safety net in case this function is re-used or another is used
		yesButton.onClick.AddListener(yesEvent);			//this adds a listener to activate the 'yesEvent' and activates it when used
		yesButton.onClick.AddListener(ClosePanel);			//closes the panel
			
		noButton.onClick.RemoveAllListeners();			
		noButton.onClick.AddListener(noEvent);				//same as above, but for the noEvent	
		noButton.onClick.AddListener(ClosePanel);		

		cancelButton.onClick.RemoveAllListeners();		
		cancelButton.onClick.AddListener(cancelEvent);		//same as above, but for the cancelEvent
		cancelButton.onClick.AddListener(ClosePanel);	

		this.questionText.text = question;					//sets the questionText in the UI to be equal to the question defined in the paramter, this will always be on in every instance, so don't change it's active


		this.iconImage.gameObject.SetActive(false);			//a reference to the icon image for the window
		yesButton.gameObject.SetActive(true);				//sets the yesButton's gameobject to be active
		noButton.gameObject.SetActive(true);				//ditto above, except for the noButton
		cancelButton.gameObject.SetActive(true);			//ditto above, except for the cancelButton
		
	}

    //this will:       ask a question   create an image   create event on yes    create event on no  & create event on cancel
    public void Choice(string question, Sprite iconImage, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
    {
        modalPanelObj.SetActive(true);                      //turns on the panel
        
        yesButton.onClick.RemoveAllListeners();             //this removes any possibility that the yesButton is 'listening' for a particular event, creates a safety net in case this function is re-used or another is used
        yesButton.onClick.AddListener(yesEvent);            //this adds a listener to activate the 'yesEvent' and activates it when used
        yesButton.onClick.AddListener(ClosePanel);          //closes the panel
        
        noButton.onClick.RemoveAllListeners();          
        noButton.onClick.AddListener(noEvent);              //same as above, but for the noEvent    
        noButton.onClick.AddListener(ClosePanel);       
        
        cancelButton.onClick.RemoveAllListeners();      
        cancelButton.onClick.AddListener(cancelEvent);      //same as above, but for the cancelEvent
        cancelButton.onClick.AddListener(ClosePanel);   
        
        this.questionText.text = question;                  //sets the questionText in the UI to be equal to the question defined in the paramter, this will always be on in every instance, so don't change it's active
		this.iconImage.sprite = iconImage;					//sets the icon int he UI to be equal to the iconImage definedi in the parameter

        this.iconImage.gameObject.SetActive(true);         //a reference to the icon image for the window
        yesButton.gameObject.SetActive(true);               //sets the yesButton's gameobject to be active
        noButton.gameObject.SetActive(true);                //ditto above, except for the noButton
        cancelButton.gameObject.SetActive(true);            //ditto above, except for the cancelButton
    }

	//an annoucement, works like the others above but only has a string and the cancel button
	public void Choice(string question, UnityAction cancelEvent)
	{
		modalPanelObj.SetActive(true);						//turns on the panel

		cancelButton.onClick.RemoveAllListeners();		
		cancelButton.onClick.AddListener(cancelEvent);		//same as above, but for the cancelEvent
		cancelButton.onClick.AddListener(ClosePanel);	
		
		this.questionText.text = question;					//sets the questionText in the UI to be equal to the question defined in the paramter, this will always be on in every instance, so don't change it's active

		this.iconImage.gameObject.SetActive(false);			//a reference to the icon image for the window
		yesButton.gameObject.SetActive(false);				//sets the yesButton's gameobject to be active
		noButton.gameObject.SetActive(false);				//ditto above, except for the noButton
		cancelButton.gameObject.SetActive(true);			//ditto above, except for the cancelButton
		
	}

	//a 2-choice question, no cancel button
	public void Choice(string question, UnityAction yesEvent, UnityAction noEvent)
	{
		modalPanelObj.SetActive(true);						//turns on the panel
		
		yesButton.onClick.RemoveAllListeners();				//this removes any possibility that the yesButton is 'listening' for a particular event, creates a safety net in case this function is re-used or another is used
		yesButton.onClick.AddListener(yesEvent);			//this adds a listener to activate the 'yesEvent' and activates it when used
		yesButton.onClick.AddListener(ClosePanel);			//closes the panel
		
		noButton.onClick.RemoveAllListeners();			
		noButton.onClick.AddListener(noEvent);				//same as above, but for the noEvent	
		noButton.onClick.AddListener(ClosePanel);			
		
		this.questionText.text = question;					//sets the questionText in the UI to be equal to the question defined in the paramter, this will always be on in every instance, so don't change it's active

		this.iconImage.gameObject.SetActive(false);			//a reference to the icon image for the window
		yesButton.gameObject.SetActive(true);				//sets the yesButton's gameobject to be active
		noButton.gameObject.SetActive(true);				//ditto above, except for the noButton
		cancelButton.gameObject.SetActive(false);			//ditto above, except for the cancelButton
		
	}


	void ClosePanel()
	{
		modalPanelObj.SetActive(false);		//closes the modal panel when called, can be used as a listener
	}
}



















