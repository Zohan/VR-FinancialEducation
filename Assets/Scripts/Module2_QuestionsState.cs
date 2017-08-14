using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module2_QuestionsState : StateMachineBehaviour {

	// Reference to module 2 main script
	public Module2_Main mainScript;

	// References to animators
	private Animator progressionAnimator;
	private Canvas headerDisplayCanvas;
	private Animator bodyDisplayAnimator;

	// References to buttons
	private Button nextButton;
	private Button backButton;

	// Fields for content text
	private string[] contentText;
	private int currentTextIndex;
	private const int TEXT_COUNT = 3;

	// Header text
	private const string h0 = "Questions";

	// Content text for the question state
	private const string t0 = "On a scale of 1 - 10, how comfortable are you thinking about your personal finances?";
	private const string t1 = "Do you have a formal budget somewhere that you try to follow?";
	private const string t2 = "What are some financial goals you would like to achieve in the next year?";

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// Setup string array of context text
		contentText = new string[TEXT_COUNT];
		contentText [0] = t0;
		contentText [1] = t1;
		contentText [2] = t2;

		// Set initial text index
		currentTextIndex = 0;

		// Get reference to module progression animator controller
		progressionAnimator = mainScript.GetProgressionAnimator();

		// Get reference to body display animator controller
		bodyDisplayAnimator = mainScript.GetBodyDisplayAnimator();

		// Set the header display text to the given text
		mainScript.SetHeaderText(h0);

		// Set the body display text to the starting text
		mainScript.SetBodyText(contentText[currentTextIndex]);

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
		// Set the body display text to the next text in the array
		if (currentTextIndex+1 < TEXT_COUNT) {
			mainScript.SetBodyText(contentText[++currentTextIndex]);
		}

		if (bodyDisplayAnimator != null) {
			bodyDisplayAnimator.ResetTrigger ("fadeIn");
			bodyDisplayAnimator.ResetTrigger ("fadeOut");
		}
	}

	void PrevContent() {
		if (bodyDisplayAnimator != null) {
			bodyDisplayAnimator.ResetTrigger ("fadeIn");
			bodyDisplayAnimator.ResetTrigger ("fadeOut");
		}

		// Set the body display text to the next text in the array
		if (currentTextIndex-1 >= 0) {
			mainScript.SetBodyText(contentText[--currentTextIndex]);
		} else {
			if (progressionAnimator != null) {
				progressionAnimator.ResetTrigger ("questions");
				progressionAnimator.SetTrigger ("intro");
			}
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//Debug.Log ("Exiting Introduction State...");
		// Remove event listeners from buttons
		nextButton.onClick.RemoveAllListeners ();
		backButton.onClick.RemoveAllListeners ();

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
