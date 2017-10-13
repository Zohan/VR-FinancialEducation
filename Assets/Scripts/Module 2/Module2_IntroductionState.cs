using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Module2_IntroductionState : StateMachineBehaviour {

	// Reference to module 2 main script
	public Module2_Main mainScript;

	// References to animators
	private Animator progressionAnimator;
	private Animator mainDisplayAnimator;
	private Animator bodyDisplayAnimator;

	// References to buttons
	private Button nextButton;
	private Button backButton;

	// Fields for content text
	private string[] introTexts;
	private int currentTextIndex;
	private const int numText = 3;

	// Header text
	private const string h0 = "Module 2:\nFinancial Fundamentals";

	// Content text for the introduction state
	private const string t0 = "Welcome!";
	private const string t1 = "You are seeking to build a solid financial future. This module outlines some important information you'll need to do this.";
	private const string t2 = "It will help you review your complete income, debt, budgeting, and finance picture.";

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		// Setup string array of context text
		introTexts = new string[numText];
		introTexts [0] = t0;
		introTexts [1] = t1;
		introTexts [2] = t2;

		// Set initial text index
		currentTextIndex = 0;

		// Set the header text
		mainScript.SetHeaderText(h0);

		// Get reference to module progression animator controller
		progressionAnimator = mainScript.GetProgressionAnimator();

		// Get reference to main display animator controller
		mainDisplayAnimator = mainScript.GetMainDisplayAnimator();
		// Set "fadeIn" trigger to active
		if (mainDisplayAnimator != null)
			mainDisplayAnimator.SetTrigger ("fadeIn");

		// Set the body display text to the starting text (t1)
		mainScript.SetBodyText(introTexts[currentTextIndex]);

		// Get reference to body display animator controller
		bodyDisplayAnimator = mainScript.GetBodyDisplayAnimator();

		// Set button event listeners
		nextButton = mainScript.GetButton("Next");
		if (nextButton != null)
			nextButton.onClick.AddListener (NextContent);
		backButton = mainScript.GetButton("Back");
		if (backButton != null)
			backButton.onClick.AddListener (PrevContent);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//	
	//}

	void NextContent() {
		if (bodyDisplayAnimator != null) {
			bodyDisplayAnimator.ResetTrigger ("fadeIn");
			bodyDisplayAnimator.ResetTrigger ("fadeOut");
		}

		// Set the body display text to the next text in the array
		if (currentTextIndex + 1 < numText) {
			mainScript.SetBodyText (introTexts [++currentTextIndex]);
		} else {
			if (progressionAnimator != null) {
				progressionAnimator.ResetTrigger ("intro");
				progressionAnimator.SetTrigger ("questions");
			}
		}
	}

	void PrevContent() {
		// Set the body display text to the next text in the array
		if (currentTextIndex-1 >= 0) {
			mainScript.SetBodyText(introTexts[--currentTextIndex]);
		}

		if (bodyDisplayAnimator != null) {
			bodyDisplayAnimator.ResetTrigger ("fadeIn");
			bodyDisplayAnimator.ResetTrigger ("fadeOut");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//Debug.Log ("Exiting Introduction State...");
		// Remove event listeners from buttons
		nextButton.onClick.RemoveAllListeners ();
		backButton.onClick.RemoveAllListeners ();

		if (mainDisplayAnimator != null)
			mainDisplayAnimator.ResetTrigger ("fadeIn");

		// Set initial text index
		currentTextIndex = 0;
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
