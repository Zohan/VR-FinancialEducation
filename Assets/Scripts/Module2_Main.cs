using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Module2_Main : MonoBehaviour {

	// Reference to the main display object (containing header + body + sides)
	public GameObject mainDisplayObj;

    // Reference to player's transform
    private Transform playerTransform;

	// References to the corresponding children of the main display object
	private Canvas headerDisplayObj;
	private Canvas bodyDisplayObj;
	private Canvas sidesDisplayObj;

	// References to the sides display buttons
	private Button nextButton;
	private Button backButton;

	// References to the animator controllers (module progression + main display + body display)
	private Animator moduleProgressionAnimator;
	private Animator mainDisplayAnimator;
	private Animator bodyDisplayAnimator;

    // Reference to the state scripts
    private Module2_StartMenuState startMenuStateScript;
    private Module2_MainDisplayFadeInState mainDisplayFadeInScript;
    private Module2_MainDisplayFadeOutState mainDisplayFadeOutScript;
    private Module2_IntroductionState introStateScript;
	private Module2_QuestionsState questionsStateScript;
    private Module2_NeedsWantsStateMachine needsWantsStateMachineScript;
    private Module2_NeedsWants_ExplainState needsWantsExplainStateScript;
    private Module2_NeedsWants_ExamplesState needsWantsExamplesStateScript;
    private Module2_WantsExamplesState wantsExamplesStateScript;
    private Module2_StayFocusedState stayFocusedStateScript;

    // Reference to the header and body display text
    private Text headerDisplayText;
	private Text bodyDisplayText;

	// Use this for initialization
	void Start () {

        // Get reference to the player's transform
        playerTransform = gameObject.transform;

		// Get references to display objects
		headerDisplayObj = mainDisplayObj.transform.Find("Header Display").GetComponent<Canvas>();
		bodyDisplayObj = mainDisplayObj.transform.Find("Body Display").GetComponent<Canvas>();
		sidesDisplayObj = mainDisplayObj.transform.Find("Sides Display").GetComponent<Canvas>();

		// Get references to the sides display buttons
		nextButton = sidesDisplayObj.transform.Find("Next Button").GetComponent<Button>();
		backButton = sidesDisplayObj.transform.Find("Back Button").GetComponent<Button>();

		// Get reference to module progression animator controller component
		moduleProgressionAnimator = this.GetComponent<Animator> ();
		mainDisplayAnimator = mainDisplayObj.GetComponent<Animator> ();
		bodyDisplayAnimator = bodyDisplayObj.GetComponent<Animator> ();

		// Get reference to text component of the header and body
		headerDisplayText = headerDisplayObj.transform.Find("Header Text").GetComponent<Text>();
		bodyDisplayText = bodyDisplayObj.transform.Find("Body Text").GetComponent<Text>();

        // Initialize the links to the states
        SetupStateScripts();
    }

    void SetupStateScripts()
    {
        // Get reference to Main Display Fade In State behavior script and pass reference to this Module 2 Main script
        mainDisplayFadeInScript = mainDisplayAnimator.GetBehaviour<Module2_MainDisplayFadeInState>();
        mainDisplayFadeInScript.mainScript = this;

        // Get reference to Main Display Fade Out State behavior script and pass reference to this Module 2 Main script
        mainDisplayFadeOutScript = mainDisplayAnimator.GetBehaviour<Module2_MainDisplayFadeOutState>();
        mainDisplayFadeOutScript.mainScript = this;

        // Get reference to Start Menu State behavior script and pass reference to this Module 2 Main script
        startMenuStateScript = moduleProgressionAnimator.GetBehaviour<Module2_StartMenuState>();
        startMenuStateScript.mainScript = this;
        
        // Get reference to Intro State behavior script and pass reference to this Module 2 Main script
        introStateScript = moduleProgressionAnimator.GetBehaviour<Module2_IntroductionState>();
        introStateScript.mainScript = this;

        // Get reference to Questions State behavior script and pass reference to this Module 2 Main script
        questionsStateScript = moduleProgressionAnimator.GetBehaviour<Module2_QuestionsState>();
        questionsStateScript.mainScript = this;

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
	public Button GetButton(string button) {
		switch (button) {
			case "Next":
				return nextButton;
			case "Back":
				return backButton;
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
        if (position == null || transform == null)
            return;
        
        // Set the position of the player
        playerTransform.position = position;
    }
    public void SetPlayerRotation(Quaternion rotation)
    {
        if (rotation == null || transform == null)
            return;

        // Set the rotation of the player
        playerTransform.rotation = rotation;
    }
}
