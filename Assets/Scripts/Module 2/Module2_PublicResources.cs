using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module2_PublicResources : StateMachineBehaviour {
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
    private const int TEXT_COUNT = 9;

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
            "Find out about\nPublic Resources",
            "Benefits.gov",
            "TANF: Temporary Assistance for Needy Families",
            "Your local domestic voilence service program",
            "Social Security"
        };

        // Setup string array of context text
        contentText = new string[TEXT_COUNT] {
            "On the practical side, get access to all of the resources that are available to you in the present.",
            "An advocate from your local domestic violence program can help you locate the contact information.",
            "Here are some good starting points...",
            "This website can help you find state-based public assistance for you and/or your family:\nhttps://www.benefits.gov",
            "This is a federal program that helps get financial resources to families that need them while working to get back on their feet:\nhttps://www.tanfprogram.com",
            "An advocate from your local domestic violence program can help you locate the contact information for resources specific to your needs, your family and your location.",
            "If you are 62 or older, remember that you are eligible for Social Security benefits. These benefits are determined by the amount of income earned over your working life.",
            "Were you married for at least 10 years and have an ex-spouse who is also 62 or older? If so, you may also be eligible to obtain benefits based on the working life of your spouse.",
            "Drawing upon these benefits does not affect the benefits that an ex-spouse receives.\nwww.socialsecurity.gov"
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
        // Display correct header for subsection
        if (currentTextIndex + 1 < 3)
        {
            // Display the first header text for the first portion of content
            mainScript.SetHeaderText(headerText[0]);
        }
        else if (currentTextIndex + 1 < 4)
        {
            mainScript.SetHeaderText(headerText[1]);
        }
        else if (currentTextIndex + 1 < 5)
        {
            mainScript.SetHeaderText(headerText[2]);
        }
        else if (currentTextIndex + 1 < 6)
        {
            mainScript.SetHeaderText(headerText[3]);
        }
        else
        {
            mainScript.SetHeaderText(headerText[4]);
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
                progressionAnimator.ResetTrigger("pubResources");

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
        // Display correct header for subsection
        if (currentTextIndex - 1 < 3)
        {
            // Display the first header text for the first portion of content
            mainScript.SetHeaderText(headerText[0]);
        }
        else if (currentTextIndex - 1 < 4)
        {
            mainScript.SetHeaderText(headerText[1]);
        }
        else if (currentTextIndex - 1 < 5)
        {
            mainScript.SetHeaderText(headerText[2]);
        }
        else if (currentTextIndex - 1 < 6)
        {
            mainScript.SetHeaderText(headerText[3]);
        }
        else
        {
            mainScript.SetHeaderText(headerText[4]);
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
                progressionAnimator.ResetTrigger("pubResources");
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
