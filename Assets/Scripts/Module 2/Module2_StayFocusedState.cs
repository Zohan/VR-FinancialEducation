using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module2_StayFocusedState : StateMachineBehaviour {
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
    private const int HEADER_COUNT = 4;
    private const int TEXT_COUNT = 7;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Initialize content
        SetupContent();

        // Initialize references
        SetupReferences();

        // Set "fadeIn" trigger to active
        if (mainDisplayAnimator != null)
            mainDisplayAnimator.SetTrigger("fadeIn");

        // Set button event listeners
        if (nextButton != null)
            nextButton.onClick.AddListener(NextContent);

        if (backButton != null)
            backButton.onClick.AddListener(PrevContent);
    }

    // Initialize the display content
    private void SetupContent()
    {
        // Setup string array of header text
        headerText = new string[HEADER_COUNT] {
            "Stay Focused",
            "Stay Focused:\nStep 1",
            "Stay Focused:\nStep 2",
            "Stay Focused:\nStep 3"
        };

        // Setup string array of context text
        contentText = new string[TEXT_COUNT] {
            "You have the power to build a stable, comfortable future for yourself and your family.",
            "Write down your life goals, and then your financial goals.",
            "Estimate how much time and money it will take to get there.",
            "Keep your written goals in a place where you'll see them. Read them often to remind yourself of your goals.",
            "Consider setting electronic reminders or even words of encouragements on your smart phone or other electronic devices. This may help keep you on track if your emotions start to take over.",
            "Examine your feelings and notice when you are being tempted to overspend based on emotion in the present.",
            "When you do, remind yourself of the future you who needs you to stay on track today, this minute, to get that big prize you set as your goal."
        };

        // Set initial text index
        currentTextIndex = 0;

        // Set the header text
        mainScript.SetHeaderText(headerText[0]);

        // Set the body display text to the starting text
        mainScript.SetBodyText(contentText[0]);
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
        if (currentTextIndex + 1 < 3)
        {
            // Display the first header text for the first portion of content
            mainScript.SetHeaderText(headerText[1]);
        }
        else if (currentTextIndex + 1 < 5)
        {
            // Display the second header text for the second portion of content
            mainScript.SetHeaderText(headerText[2]);
        }
        else
        {
            // Display the second header text for the second portion of content
            mainScript.SetHeaderText(headerText[3]);
        }

        // Set the body display text to the next text in the array or go to the next state
        if (currentTextIndex + 1 < TEXT_COUNT)
        {
            mainScript.SetBodyText(contentText[++currentTextIndex]);
        }
        else
        {
            // Go to the next state

            // Reset the progression animator's trigger for this state in case it's active
            if (progressionAnimator != null)
                progressionAnimator.ResetTrigger("moveToStayFocused");

            // Set main display animator's "fadeOut" trigger
            if (mainDisplayAnimator != null)
            {
                mainDisplayAnimator.SetTrigger("fadeOut");
            }
        }
    }

    // Called when the "Back" button is clicked
    void PrevContent()
    {
        // Check which display stage we're in (i.e., first portion of content, or second portion)
        if (currentTextIndex - 1 < 1)
        {
            // Display the first header text for the first portion of content
            mainScript.SetHeaderText(headerText[0]);
        }
        else if (currentTextIndex - 1 < 3)
        {
            // Display the second header text for the second portion of content
            mainScript.SetHeaderText(headerText[1]);
        }
        else if (currentTextIndex - 1 < 5)
        {
            // Display the second header text for the second portion of content
            mainScript.SetHeaderText(headerText[2]);
        }
        else
        {
            // Display the second header text for the second portion of content
            mainScript.SetHeaderText(headerText[3]);
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
                progressionAnimator.ResetTrigger("moveToStayFocused");
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
