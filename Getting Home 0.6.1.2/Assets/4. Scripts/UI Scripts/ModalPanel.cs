using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class EventButtonDetails
{
	public string buttonTitle;		//
	public Sprite backgroundImage;	//not yet implemented
	public UnityAction action;		//
}

public class ModalPanelDetails
{
	public string title;
	public string question;
	public Sprite iconImage;
	public Sprite panelBackgroundImage;
	public EventButtonDetails button1Details;
	public EventButtonDetails button2Details;
	public EventButtonDetails button3Details;	
}

public class ModalPanel : MonoBehaviour 
{
	public Text questionText;
	public Image iconImage;

	public Button button1;
	public Button button2;
	public Button button3;

	public Text button1Text;
	public Text button2Text;
	public Text button3Text;

	public ConversationScript convoScript;

	public GameObject modalPanelObj;
	
	private static ModalPanel staticModalPanel;				//a private and static reference to the ModalPanel

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

		button1.onClick.RemoveAllListeners();				//this removes any possibility that the yesButton is 'listening' for a particular event, creates a safety net in case this function is re-used or another is used
		button1.onClick.AddListener(yesEvent);				//this adds a listener to activate the 'yesEvent' and activates it when used
		button1.onClick.AddListener(ClosePanel);			//closes the panel
			
		button2.onClick.RemoveAllListeners();			
		button2.onClick.AddListener(noEvent);				//same as above, but for the noEvent	
		button2.onClick.AddListener(ClosePanel);		

		button3.onClick.RemoveAllListeners();		
		button3.onClick.AddListener(cancelEvent);			//same as above, but for the cancelEvent
		button3.onClick.AddListener(ClosePanel);	

		this.questionText.text = question;					//sets the questionText in the UI to be equal to the question defined in the paramter, this will always be on in every instance, so don't change it's active


		this.iconImage.gameObject.SetActive(false);			//a reference to the icon image for the window
		button1.gameObject.SetActive(true);					//sets the yesButton's gameobject to be active
		button2.gameObject.SetActive(true);					//ditto above, except for the noButton
		button3.gameObject.SetActive(true);					//ditto above, except for the cancelButton
		
	}

    //this will:       ask a question   create an image   create event on yes    create event on no  & create event on cancel
    public void Choice(string question, Sprite iconImage, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
    {
        modalPanelObj.SetActive(true);                      //turns on the panel
        
        button1.onClick.RemoveAllListeners();               //this removes any possibility that the yesButton is 'listening' for a particular event, creates a safety net in case this function is re-used or another is used
        button1.onClick.AddListener(yesEvent);              //this adds a listener to activate the 'yesEvent' and activates it when used
        button1.onClick.AddListener(ClosePanel);            //closes the panel
        
        button2.onClick.RemoveAllListeners();          
        button2.onClick.AddListener(noEvent);               //same as above, but for the noEvent    
        button2.onClick.AddListener(ClosePanel);       
        
        button3.onClick.RemoveAllListeners();      
        button3.onClick.AddListener(cancelEvent);     		//same as above, but for the cancelEvent
        button3.onClick.AddListener(ClosePanel);   
        
        this.questionText.text = question;                  //sets the questionText in the UI to be equal to the question defined in the paramter, this will always be on in every instance, so don't change it's active
		this.iconImage.sprite = iconImage;					//sets the icon int he UI to be equal to the iconImage definedi in the parameter

        this.iconImage.gameObject.SetActive(true);          //a reference to the icon image for the window
        button1.gameObject.SetActive(true);              	//sets the yesButton's gameobject to be active
        button2.gameObject.SetActive(true);					//sets the noButton's gameobject to be active
        button3.gameObject.SetActive(true);           		//ditto above, except for the cancelButton
    }

	//an annoucement, works like the others above but only has a string and the cancel button
	public void Choice(string question, UnityAction cancelEvent, Sprite iconImage = null)
	{
		modalPanelObj.SetActive(true);						//turns on the panel

		button3.onClick.RemoveAllListeners();		
		button3.onClick.AddListener(cancelEvent);			//same as above, but for the cancelEvent
		button3.onClick.AddListener(ClosePanel);	
		
		this.questionText.text = question;					//sets the questionText in the UI to be equal to the question defined in the paramter, this will always be on in every instance, so don't change it's active
		
		if (iconImage)
		{
			this.iconImage.sprite = iconImage;
		}

		if (iconImage)
		{
			this.iconImage.gameObject.SetActive(true);		//a reference to the icon image for the window		
		}
		else 
		{
			this.iconImage.gameObject.SetActive(true);		//a reference to the icon image for the window					
		}

		button1.gameObject.SetActive(false);				//sets the yesButton's gameobject to be active
		button2.gameObject.SetActive(false);				//ditto above, except for the noButton
		button3.gameObject.SetActive(true);					//ditto above, except for the cancelButton
		
	}

	//a 2-choice question, no cancel button
	public void Choice(string question, UnityAction yesEvent, UnityAction noEvent)
	{
		modalPanelObj.SetActive(true);						//turns on the panel
		
		button1.onClick.RemoveAllListeners();				//this removes any possibility that the yesButton is 'listening' for a particular event, creates a safety net in case this function is re-used or another is used
		button1.onClick.AddListener(yesEvent);				//this adds a listener to activate the 'yesEvent' and activates it when used
		button1.onClick.AddListener(ClosePanel);			//closes the panel
		
		button2.onClick.RemoveAllListeners();			
		button2.onClick.AddListener(noEvent);				//same as above, but for the noEvent	
		button2.onClick.AddListener(ClosePanel);			
		
		this.questionText.text = question;					//sets the questionText in the UI to be equal to the question defined in the paramter, this will always be on in every instance, so don't change it's active
			
		this.iconImage.gameObject.SetActive(false);			//a reference to the icon image for the window
		button1.gameObject.SetActive(true);					//sets the yesButton's gameobject to be active
		button2.gameObject.SetActive(true);					//ditto above, except for the noButton
		button3.gameObject.SetActive(false);				//ditto above, except for the cancelButton
		
	}

	public void NewChoice(ModalPanelDetails details)
	{
		modalPanelObj.SetActive(true);						//turns on the panel

		if (details.iconImage)
		{
			this.iconImage.sprite = details.iconImage;
		}
		
		if (details.iconImage)
		{
			this.iconImage.gameObject.SetActive(true);					//a reference to the icon image for the window		
		}
		else 
		{
			this.iconImage.gameObject.SetActive(false);					//a reference to the icon image for the window		
		}

		this.questionText.text = details.question;						//sets the questionText in the UI to be equal to the question defined in the paramter, this will always be on in every instance, so don't change it's active
		
		button1.gameObject.SetActive(false);							//sets the yesButton's gameobject to be active
		button2.gameObject.SetActive(false);							//ditto above, except for the noButton
		button3.gameObject.SetActive(false);							//ditto above, except for the cancelButton
		
		button1.onClick.RemoveAllListeners();							//this removes any possibility that the yesButton is 'listening' for a particular event, creates a safety net in case this function is re-used or another is used
		button1.onClick.AddListener(details.button1Details.action);		//this adds a listener to activate the 'yesEvent' and activates it when used
		button1.onClick.AddListener(ClosePanel);						//closes the panel
		button1Text.text = details.button1Details.buttonTitle;
		button1.gameObject.SetActive(true);	

		if (details.button2Details != null)
		{
			button2.onClick.RemoveAllListeners();					
			button2.onClick.AddListener(details.button2Details.action);	
			button2.onClick.AddListener(ClosePanel);				
			button2Text.text = details.button2Details.buttonTitle;
			button2.gameObject.SetActive(true);	
		}

		if (details.button3Details != null)
		{
			button3.onClick.RemoveAllListeners();					
			button3.onClick.AddListener(details.button3Details.action);	
			button3.onClick.AddListener(ClosePanel);				
			button3Text.text = details.button3Details.buttonTitle;
			button3.gameObject.SetActive(true);	
		}
	}

	void ClosePanel()
	{
		modalPanelObj.SetActive(false);						//closes the modal panel when called, can be used as a listener
	}
}



















