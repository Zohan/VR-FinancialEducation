using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module2_StartMenuState : StateMachineBehaviour {

    // Reference to module 2 main script
    public Module2_Main mainScript;
    
    // Player position during this state machine
    public Vector3 playerStartingPosition = new Vector3(151f, 183.5f, 97f);
    public Vector3 playerStartingRotation = new Vector3(0f, -150f, 0f);

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set the player's base position and rotation for this entire state
        mainScript.SetPlayerPosition(playerStartingPosition);
        mainScript.SetPlayerRotation(Quaternion.Euler(playerStartingRotation));
        //Debug.Log("Entered Start Menu State");
        //mainScript.SetPlayerPosition(new Vector3(0, 0, 0));
        //mainScript.SetPlayerRotation(Quaternion.Euler(0, 0, 0));

        // Hide the video player object
        mainScript.videoPlayerObj.SetActive(false);

        // Show start menu
        mainScript.startMenuObj.SetActive(true);

        // Fade in to the scene via the Main Camera's CameraFade script function "FadeIn()"
        mainScript.GetCameraFadeObject().FadeIn(2);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Hide start menu
        mainScript.startMenuObj.SetActive(false);
    }
}
