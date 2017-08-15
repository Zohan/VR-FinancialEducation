using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module2_MainDisplayFadeOutState : StateMachineBehaviour {

    // Reference to Module 2 main script
    public Module2_Main mainScript;

    // References to animators
    private Animator progressionAnimator;

    // Hash of main progression states
    private int questionsState = Animator.StringToHash("Base Layer.Introduction.Questions");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // Reset this animator's "fadeIn" trigger
        animator.ResetTrigger("fadeIn");

        // Get reference to module progression animator controller
        progressionAnimator = mainScript.GetProgressionAnimator();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // Reset this animator's "fadeOut" trigger
        animator.ResetTrigger("fadeOut");

        if (progressionAnimator != null)
        {
            // If the main progression animator is in the "Questions" state
            if (progressionAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash == questionsState)
            {
                // Trigger the next state (firstSteps)
                progressionAnimator.SetTrigger("firstSteps");
            }
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
