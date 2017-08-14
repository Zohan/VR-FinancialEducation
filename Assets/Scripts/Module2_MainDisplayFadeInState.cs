using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module2_MainDisplayFadeInState : StateMachineBehaviour {

	// Reference to module 2 main script
	public Module2_Main mainScript;

	private Animator bodyDisplayAnimator;

	// Header text
	private const string h0 = "Module 2:\nFinancial Fundamentals";

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		// Set the header text
		mainScript.SetHeaderText(h0);

		bodyDisplayAnimator = mainScript.GetBodyDisplayAnimator ();
		if (bodyDisplayAnimator != null) {
			bodyDisplayAnimator.SetTrigger ("fadeIn");
		}
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
