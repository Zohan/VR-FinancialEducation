using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class Module2_Main : MonoBehaviour {

    // PUBLIC FIELDS
	public GameObject mainDisplayObj;       // Reference to the main display object (containing header + body + buttons)
    public GameObject startMenuObj;         // Reference to start menu object
    public Camera mainCamera;               // Reference to main camera object
    public GameObject headerDisplayObj;     // Reference to header display object in main display
    public GameObject bodyDisplayObj;       // Reference to body display object in main display
    public GameObject footerDisplayObj;     // Reference to footer display object in main display
    public GameObject videoPlayerObj;      // Reference to the video player game child object of Main Display


    // PRIVATE FIELDS
    private Transform playerTransform;      // Reference to player's transform
    private VR_CameraFade mainCameraFade;   // Reference to VR camera fade object + canvas panel

    // References to the corresponding children of the main display object
    //private Canvas headerDisplayCanvas;
    //private Canvas bodyDisplayCanvas;
    //private Canvas buttonsDisplayCanvas;

    // References to the sides display buttons
    private Button nextButton;
	private Button backButton;
    private Button videoButton;

	// References to the animator controllers (module progression + main display + body display)
	private Animator moduleProgressionAnimator;
	private Animator mainDisplayAnimator;
	private Animator bodyDisplayAnimator;

    // Reference to the state scripts
    private Module2_StartMenuState startMenuStateScript;
    private Module2_MainDisplaySign_FadeIn mainDisplayFadeInScript;
    private Module2_MainDisplaySign_FadeOut mainDisplayFadeOutScript;
    private Module2_IntroductionState introStateScript;
	//private Module2_QuestionsState questionsStateScript;
    private Module2_NeedsWantsStateMachine needsWantsStateMachineScript;
    private Module2_NeedsWants_ExplainState needsWantsExplainStateScript;
    private Module2_NeedsWants_ExamplesState needsWantsExamplesStateScript;
    private Module2_WantsExamplesState wantsExamplesStateScript;
    private Module2_StayFocusedState stayFocusedStateScript;
    private Module2_PublicResources publicResourcesStateScript;
    private Module2_BudgetSaving_Explain budgetSavingsStateScript;
    private Module2_BudgetSaving_MakeBudget makeBudgetStateScript;
    private Module2_BudgetSaving_ThinkingSaving thinkingSavingStateScript;
    private Module2_WhereMoney_Explain whereMoneyExplainStateScript;
    private Module2_CheckLearning checkLearningStateScript;

    // Reference to the header and body display text
    private Text headerDisplayText;
	private Text bodyDisplayText;

    // References to Needs and Wants examples displays
    private GameObject needsDisplay;
    private GameObject wantsDisplay;

    // Use this for initialization
    void Start () {

        // Get reference to the main camera's fade object
        mainCameraFade = mainCamera.GetComponent<VR_CameraFade>();
        mainCameraFade.mainScript = this;
        
        // Get reference to the player's transform
        playerTransform = gameObject.transform;

        // Get references to display objects
        //headerDisplayCanvas = mainDisplayObj.transform.Find("Header Display").GetComponent<Canvas>();
        //bodyDisplayCanvas = mainDisplayObj.transform.Find("Body Display").GetComponent<Canvas>();
        //buttonsDisplayCanvas = mainDisplayObj.transform.Find("Buttons Display").GetComponent<Canvas>();
        //headerDisplayCanvas = headerDisplayObj.get

        // Get references to the sides display buttons
        //nextButton = buttonsDisplayCanvas.transform.Find("Next Button").GetComponent<Button>();
        //      backButton = buttonsDisplayCanvas.transform.Find("Back Button").GetComponent<Button>();
        nextButton = footerDisplayObj.transform.Find("Next Button").GetComponent<Button>();
        backButton = footerDisplayObj.transform.Find("Back Button").GetComponent<Button>();
        videoButton = videoPlayerObj.GetComponent<Button>();

        // Get reference to module progression animator controller component
        moduleProgressionAnimator = this.GetComponent<Animator> ();
		mainDisplayAnimator = mainDisplayObj.GetComponent<Animator> ();
        bodyDisplayAnimator = bodyDisplayObj.GetComponent<Animator> ();

        // Get reference to text component of the header and body
        headerDisplayText = headerDisplayObj.GetComponentInChildren<Text>(); //headerDisplayObj.FindWithTag("Header Text").GetComponent<Text>();
		bodyDisplayText = bodyDisplayObj.GetComponentInChildren<Text>(); //bodyDisplayObj.transform.Find("Body Text").GetComponent<Text>();

        //videoPlayerObj = mainDisplayObj.transform.Find("Video Player Display").GetComponent<GameObject>();

        // Initialize the links to the states
        SetupStateScripts();

        // Get references to Needs and Wants examples display controllers and hide them initially
        needsDisplay = GameObject.Find("Needs Display Controller");
        wantsDisplay = GameObject.Find("Wants Display Controller");
        HideNeedsDisplay();
        HideWantsDisplay();
    }

    void SetupStateScripts()
    {
        // Get reference to Main Display Fade In State behavior script and pass reference to this Module 2 Main script
        mainDisplayFadeInScript = mainDisplayAnimator.GetBehaviour<Module2_MainDisplaySign_FadeIn>();
        mainDisplayFadeInScript.mainScript = this;

        //// Get reference to Main Display Fade Out State behavior script and pass reference to this Module 2 Main script
        mainDisplayFadeOutScript = mainDisplayAnimator.GetBehaviour<Module2_MainDisplaySign_FadeOut>();
        mainDisplayFadeOutScript.mainScript = this;

        // Get reference to Start Menu State behavior script and pass reference to this Module 2 Main script
        startMenuStateScript = moduleProgressionAnimator.GetBehaviour<Module2_StartMenuState>();
        startMenuStateScript.mainScript = this;
        
        // Get reference to Intro State behavior script and pass reference to this Module 2 Main script
        introStateScript = moduleProgressionAnimator.GetBehaviour<Module2_IntroductionState>();
        introStateScript.mainScript = this;

        // Get reference to Questions State behavior script and pass reference to this Module 2 Main script
        //questionsStateScript = moduleProgressionAnimator.GetBehaviour<Module2_QuestionsState>();
        //questionsStateScript.mainScript = this;

        // Get reference to Needs and Wants State Machine behavior script and pass reference to this Module 2 Main script
        needsWantsStateMachineScript = moduleProgressionAnimator.GetBehaviour<Module2_NeedsWantsStateMachine>();
        needsWantsStateMachineScript.mainScript = this;

        // Get reference to Needs and Wants Explain State behavior script and pass reference to this Module 2 Main script
        needsWantsExplainStateScript = moduleProgressionAnimator.GetBehaviour<Module2_NeedsWants_ExplainState>();
        needsWantsExplainStateScript.mainScript = this;

        // Get reference to Needs and Wants Examples State behavior script and pass reference to this Module 2 Main script
        needsWantsExamplesStateScript = moduleProgressionAnimator.GetBehaviour<Module2_NeedsWants_ExamplesState>();
        needsWantsExamplesStateScript.mainScript = this;

        // Get reference to Needs and Wants Examples State behavior script and pass reference to this Module 2 Main script
        wantsExamplesStateScript = moduleProgressionAnimator.GetBehaviour<Module2_WantsExamplesState>();
        wantsExamplesStateScript.mainScript = this;

        // Get reference to Stay Focused State behavior script and pass reference to this Module 2 Main script
        stayFocusedStateScript = moduleProgressionAnimator.GetBehaviour<Module2_StayFocusedState>();
        stayFocusedStateScript.mainScript = this;

        // Get reference to Public Resources State behavior script and pass reference to this Module 2 Main script
        publicResourcesStateScript = moduleProgressionAnimator.GetBehaviour<Module2_PublicResources>();
        publicResourcesStateScript.mainScript = this;

        // Get reference to Budget and Saving State behavior script and pass reference to this Module 2 Main script
        budgetSavingsStateScript = moduleProgressionAnimator.GetBehaviour<Module2_BudgetSaving_Explain>();
        budgetSavingsStateScript.mainScript = this;

        // Get reference to Budget and Saving Make Budget State behavior script and pass reference to this Module 2 Main script
        makeBudgetStateScript = moduleProgressionAnimator.GetBehaviour<Module2_BudgetSaving_MakeBudget>();
        makeBudgetStateScript.mainScript = this;

        // Get reference to Budget and Saving Thinking for Saving State behavior script and pass reference to this Module 2 Main script
        thinkingSavingStateScript = moduleProgressionAnimator.GetBehaviour<Module2_BudgetSaving_ThinkingSaving>();
        thinkingSavingStateScript.mainScript = this;

        // Get reference to Budget and Saving Thinking for Saving State behavior script and pass reference to this Module 2 Main script
        whereMoneyExplainStateScript = moduleProgressionAnimator.GetBehaviour<Module2_WhereMoney_Explain>();
        whereMoneyExplainStateScript.mainScript = this;

        // Get reference to Check Learning State behavior script and pass reference to this Module 2 Main script
        checkLearningStateScript = moduleProgressionAnimator.GetBehaviour<Module2_CheckLearning>();
        checkLearningStateScript.mainScript = this;
    }
    
	// Update is called once per frame
	void Update () {
        //playerTransform.Translate(Vector3.forward * Time.deltaTime);
	}

	// Getter functions
	public Animator GetProgressionAnimator() {
		return moduleProgressionAnimator;
	}
	public Animator GetMainDisplayAnimator() {
		return mainDisplayAnimator;
	}
	public Animator GetBodyDisplayAnimator() {
		return bodyDisplayAnimator;
	}
    public VideoPlayer GetVideoPlayerDisplay()
    {
        return videoPlayerObj.GetComponent<VideoPlayer>();
    }
	public Button GetButton(string button) {
		switch (button) {
			case "Next":
				return nextButton;
			case "Back":
				return backButton;
            case "Video":
                return videoButton;
			default:
				return null;
		}
	}

	// Setter functions
	public void SetHeaderText(string text) {
		// Make sure the body display text object is not null
		if (headerDisplayText == null)
			return;
		// Set the body display text to the passed text
		headerDisplayText.text = text;
	}
	public void SetBodyText(string text) {
		// Make sure the body display text object is not null
		if (bodyDisplayText == null)
			return;
		// Set the body display text to the passed text
		bodyDisplayText.text = text;
	}
    public void SetPlayerPosition(Vector3 position)
    {
        //if (position == null || transform == null)
        //    return;
        
        // Set the position of the player
        playerTransform.position = position;
    }
    public void SetPlayerRotation(Quaternion rotation)
    {
        //if (rotation == null || transform == null)
        //    return;

        // Set the rotation of the player
        playerTransform.rotation = rotation;
    }

    public void ActivateTrigger(string trigger)
    {
        if (trigger == null || trigger == "")
            return;
        
        // Activate the given animator state trigger
        moduleProgressionAnimator.SetTrigger(trigger);
    }
    public void ShowNeedsDisplay()
    {
        needsDisplay.SetActive(true);
    }
    public void HideNeedsDisplay()
    {
        needsDisplay.SetActive(false);
    }
    public void ShowWantsDisplay()
    {
        wantsDisplay.SetActive(true);
    }
    public void HideWantsDisplay()
    {
        wantsDisplay.SetActive(false);
    }
    public void GoToState(string state)
    {
        if (state == null || state == "")
            return;

        // Go to the state in the state manager
        moduleProgressionAnimator.Play(state);
    }
    public VR_CameraFade GetCameraFadeObject()
    {
        return mainCameraFade;
    }
    public void RecenterVRCamera()
    {
        GvrCardboardHelpers.Recenter();
    }
}