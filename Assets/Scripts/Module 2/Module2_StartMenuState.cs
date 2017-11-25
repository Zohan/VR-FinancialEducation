using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module2_StartMenuState : StateMachineBehaviour {

    // Reference to module 2 main script
    public Module2_Main mainScript;
    
    // Player position during this state machine
    public Vector3 playerPosition;
    public Vector3 playerRotation;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Show start menu
        mainScript.startMenuObj.SetActive(true);

        // Set the player's base position and rotation for this entire state
        mainScript.SetPlayerPosition(playerPosition);
        mainScript.SetPlayerRotation(Quaternion.Euler(playerRotation));

        // Fade in to the scene via the Main Camera's CameraFade script function "FadeIn()"
        mainScript.mainCameraFade.FadeIn(2);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Hide start menu
        mainScript.startMenuObj.SetActive(false);
    }
}
