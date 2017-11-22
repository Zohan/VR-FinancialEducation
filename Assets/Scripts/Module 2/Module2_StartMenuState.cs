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

    //// References to animators
    //private Animator progressionAnimator;
    //private Animator mainDisplayAnimator;
    //private Animator bodyDisplayAnimator;

    //// References to buttons
    //private Button nextButton;
    //private Button backButton;

    //// Fields for content text
    //private string[] headerText;
    //private string[] contentText;
    //private int[] contentTransitionIndices;
    //private int currentTextIndex;
    //private const int HEADER_COUNT = 1;
    //private const int TEXT_COUNT = 4;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set the player's base position and rotation for this entire state
        mainScript.SetPlayerPosition(playerPosition);
        mainScript.SetPlayerRotation(Quaternion.Euler(playerRotation));

        // Fade in to the scene via the Main Camera's CameraFade script function "FadeIn()"
        mainScript.mainCamera.GetComponent<CameraFade>().FadeIn(4);

        // Initialize content
        //SetupContent();

        //// Initialize references
        //SetupReferences();

        //// Set "fadeIn" trigger to active
        //if (mainDisplayAnimator != null)
        //    mainDisplayAnimator.SetTrigger("fadeIn");

        //// Set button event listeners
        //if (nextButton != null)
        //    nextButton.onClick.AddListener(NextContent);

        //if (backButton != null)
        //    backButton.onClick.AddListener(PrevContent);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Remove event listeners from buttons
        //nextButton.onClick.RemoveAllListeners();
        //backButton.onClick.RemoveAllListeners();

        // Set initial text index
        //currentTextIndex = 0;
    }
}
