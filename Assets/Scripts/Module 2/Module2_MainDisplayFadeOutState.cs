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
    private int explanationState = Animator.StringToHash("Base Layer.First Steps.Needs vs Wants.Explanation");
    private int needsExamplesState = Animator.StringToHash("Base Layer.First Steps.Needs vs Wants.Needs Examples");
    private int wantsExamplesState = Animator.StringToHash("Base Layer.First Steps.Needs vs Wants.Wants Examples");
    private int stayFocusedState = Animator.StringToHash("Base Layer.First Steps.Needs vs Wants.Stay Focused");
    private int publicResourcesState = Animator.StringToHash("Base Layer.First Steps.Public Resources");
    private int budgetExplainState = Animator.StringToHash("Base Layer.Budgeting and Saving.Explanation");
    private int makeBudgetState = Animator.StringToHash("Base Layer.Budgeting and Saving.Make Budget");
    private int thinkingSavingState = Animator.StringToHash("Base Layer.Budgeting and Saving.Thinking for Saving");

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

        // Perform a state transition to the next desired state
        // TODO: Make functionality to pass state from calling state (e.g., questions) to this animator/state script
        if (progressionAnimator != null)
        {
            int currentStateHash = progressionAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash;

            // If the main progression animator is in the "Questions" state
            if (currentStateHash == questionsState)
            {
                // Trigger the next state (firstSteps)
                progressionAnimator.SetTrigger("firstSteps");
            }
            else if (currentStateHash == explanationState)
            {
                // Trigger the next state (needs examples)
                progressionAnimator.SetTrigger("needsWants_examples");
            }
            else if (currentStateHash == needsExamplesState)
            {
                // Trigger the next state (wants examples)
                progressionAnimator.SetTrigger("moveToWants");
            }
            else if (currentStateHash == wantsExamplesState)
            {
                // Trigger the next state (stay focused)
                progressionAnimator.SetTrigger("moveToStayFocused");
            }
            else if (currentStateHash == stayFocusedState)
            {
                // Trigger the next state (stay focused)
                progressionAnimator.SetTrigger("pubResources");
            }
            else if (currentStateHash == publicResourcesState)
            {
                // Trigger the next state (budget and saving)
                progressionAnimator.SetTrigger("budgetSaving");
            }
            else if (currentStateHash == budgetExplainState)
            {
                // Trigger the next state (make a budget)
                progressionAnimator.SetTrigger("makeBudget");
            }
            else if (currentStateHash == makeBudgetState)
            {
                // Trigger the next state (thinking for saving)
                progressionAnimator.SetTrigger("thinkingSaving");
            }
            else if (currentStateHash == thinkingSavingState)
            {
                // Trigger the next state (thinking for saving)
                progressionAnimator.SetTrigger("whereToPutMoney");
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
