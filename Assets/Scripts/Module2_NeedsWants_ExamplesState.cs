using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module2_NeedsWants_ExamplesState : StateMachineBehaviour {

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
    private string[] headerText;
    private string[] contentText;
    private int currentTextIndex;
    private const int HEADER_COUNT = 5;
    private const int TEXT_COUNT = 5;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Initialize content
        SetupContent();

        // Initialize references
        SetupReferences();

        // Set "fadeIn" trigger to active
        //if (mainDisplayAnimator != null)
        //    mainDisplayAnimator.SetTrigger("fadeIn");

        // Set button event listeners
        //if (nextButton != null)
        //    nextButton.onClick.AddListener(NextContent);

        //if (backButton != null)
        //    backButton.onClick.AddListener(PrevContent);
    }

    // Initialize the display content
    private void SetupContent()
    {
        // Setup string array of header text
        headerText = new string[HEADER_COUNT] {
            "Healthy food",
            "Shelter",
            "Clothing",
            "Heat and utilities",
            "Car and gas"
        };

        // Setup string array of context text
        //contentText = new string[TEXT_COUNT] {
        //    "Healthy food",
        //    "Shelter",
        //    "Clothing",
        //    "Heat and utilities",
        //    "Car and gas"
        //};

        // Set initial text index
        currentTextIndex = 0;

        // Set the header text
        mainScript.SetHeaderText(headerText[0]);

        // Set the body display text to the starting text
        mainScript.SetBodyText("");
    }

    // Setup references to objects
    private void SetupReferences()
    {
        // Get reference to module progression animator controller
        progressionAnimator = mainScript.GetProgressionAnimator();

        // Get reference to main display animator controller
        mainDisplayAnimator = mainScript.GetMainDisplayAnimator();

        // Get reference to body display animator controller
        bodyDisplayAnimator = mainScript.GetBodyDisplayAnimator();

        // Get references to buttons
        nextButton = mainScript.GetButton("Next");
        backButton = mainScript.GetButton("Back");
    }

    // Called when the "Next" button is clicked
    void NextContent()
    {
        // Check which display stage we're in (i.e., first portion of content, or second portion)
        if (currentTextIndex + 1 < 2)
        {
            // Display the first header text for the first portion of content
            mainScript.SetHeaderText(headerText[0]);
        }
        else
        {
            // Display the second header text for the second portion of content
            mainScript.SetHeaderText(headerText[1]);
        }

        // Set the body display text to the next text in the array or go to the next state
        if (currentTextIndex + 1 < TEXT_COUNT)
        {
            mainScript.SetBodyText(contentText[++currentTextIndex]);
        }
        else
        {
            // Reset the progression animator's trigger for this state in case it's active
            if (progressionAnimator != null)
                progressionAnimator.ResetTrigger("firstSteps");

            // Set main display animator's "fadeOut" trigger
            if (mainDisplayAnimator != null)
                mainDisplayAnimator.SetTrigger("fadeOut");
        }
    }

    // Called when the "Back" button is clicked
    void PrevContent()
    {
        // Check which display stage we're in (i.e., first portion of content, or second portion)
        if (currentTextIndex - 1 < 2)
        {
            // Display the first header text for the first portion of content
            mainScript.SetHeaderText(headerText[0]);
        }
        else
        {
            // Display the second header text for the second portion of content
            mainScript.SetHeaderText(headerText[1]);
        }

        // Set the body display text to the previous text in the array or go to the previous state
        if (currentTextIndex - 1 >= 0)
        {
            mainScript.SetBodyText(contentText[--currentTextIndex]);
        }
        else
        {
            // Go to the previous state

            // Reset the progression animator's trigger for this state in case it's active
            if (progressionAnimator != null)
            {
                progressionAnimator.ResetTrigger("firstSteps");
                //progressionAnimator.SetTrigger("questions");
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Remove event listeners from buttons
        nextButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();

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
