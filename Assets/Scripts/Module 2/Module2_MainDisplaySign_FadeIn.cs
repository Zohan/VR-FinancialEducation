using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module2_MainDisplaySign_FadeIn : StateMachineBehaviour {
    // Reference to module 2 main script
    public Module2_Main mainScript;

    private Animator bodyDisplayAnimator;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Reset this animator "fadeIn" trigger
        animator.ResetTrigger("fadeIn");

        // Trigger the body text "fadeIn" animation/state
        //bodyDisplayAnimator = mainScript.GetBodyDisplayAnimator();
        //if (bodyDisplayAnimator != null)
        //{
        //    bodyDisplayAnimator.SetTrigger("fadeIn");
        //}
    }
}
