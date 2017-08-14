using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Module2_Main : MonoBehaviour {

	// Reference to the main display object (containing header + body + sides)
	public GameObject mainDisplayObj;

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
	private Module2_MainDisplayFadeInState mainDisplayFadeInScript;
	private Module2_IntroductionState introStateScript;
	private Module2_QuestionsState questionsStateScript;

	// Reference to the header and body display text
	private Text headerDisplayText;
	private Text bodyDisplayText;

	// Reference to the current state in the module progression animator controller
	//private AnimatorStateInfo currentProgressionState;

	// References to triggers within the animator controllers
	//private int resetTriggerHash = Animator.StringToHash("reset");
	//private int fadeInTriggerHash = Animator.StringToHash("fadeIn");

	// References to the module progression animator controller states
	//private int startMenuStateHash = Animator.StringToHash("Base Layer.Start Menu");
	//private int introStateHash = Animator.StringToHash("Base Layer.Intro");

	// Use this for initialization
	void Start () {
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

		// Get reference to Main Display Fade In State behavior script
		mainDisplayFadeInScript = mainDisplayAnimator.GetBehaviour<Module2_MainDisplayFadeInState>();
		mainDisplayFadeInScript.mainScript = this;

		// Get reference to Intro State behavior script
		introStateScript = moduleProgressionAnimator.GetBehaviour<Module2_IntroductionState>();
		introStateScript.mainScript = this;

		// Get reference to Questions State behavior script
		questionsStateScript = moduleProgressionAnimator.GetBehaviour<Module2_QuestionsState>();
		questionsStateScript.mainScript = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayNextContent() {
		// PSUEDOCODE:
		// Get reference to current state to know which content (text) 'pool' to pull from
		// Get reference to current content (text)
		// Queue next content to display
		// Trigger content transition
		// Check if this is the end of this current state and call NextState()

		// Get the current state of the main module progression
		//currentProgressionState = mainProgressionAnimator.GetCurrentAnimatorStateInfo(0);
		//if (currentProgressionState.fullPathHash == introStateHash) {
		//	centerDisplayAnimator.SetTrigger ("fadeIn");
		//}
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
}
