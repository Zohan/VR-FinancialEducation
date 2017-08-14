using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module2_StartMenuState : StateMachineBehaviour {
	Canvas startButton;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// Get reference to Start Button and enable it for the Start Menu
		//startButton = GameObject.Find ("Start Button").GetComponent<Canvas> ();
		//startButton.enabled = true;
		//Debug.Log ("startButton.enabled = " + startButton.enabled);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// Disable the Start Button when leaving the Start Menu state
		//startButton.enabled = false;
		//Debug.Log ("startButton.enabled = " + startButton.enabled);
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
