using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module2_BudgetSaving_MakeBudget : StateMachineBehaviour {
    // Reference to module 2 main script
    public Module2_Main mainScript;

    // References to animators
    private Animator progressionAnimator;
    private Animator mainDisplayAnimator;
    private Animator bodyDisplayAnimator;
    private string currentTrigger;

    // References to buttons
    private Button nextButton;
    private Button backButton;

    // Fields for content text
    private string[] headerText;
    private string[] contentText;
    private int[] contentTransitionIndices;
    private int currentTextIndex;
    private const int HEADER_COUNT = 6;
    private const int TEXT_COUNT = 9;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set the state trigger for this state
        currentTrigger = "makeBudget";

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
            "Make a Budget",
            "Step 1",
            "Step 2",
            "Step 3",
            "Budget Tools",
            "Spreadsheets"
        };

        // Setup string array of context text
        contentText = new string[TEXT_COUNT] {
            // Make a Budget [0]
            "Your next step is to make a budget. The following will guide you through the steps necessary for doing so.",
            // Step 1 [1]
            "Identify your net monthly income. This is the money that comes into your household, after deducting taxes, Social Security insurance, etc.",
            // Step 2 [2]
            "Identify your monthly expenses. Monthly expenses include rent and phone bills, as well as those that occur periodically, like car insurance and medical expenses.",
            // Step 3 [3]
            "Subtract your monthly expenses from your income. The difference between your income and expenses indicates whether or not you have any money to spare.",
            "Can you reduce expenses or earn more money to cover shortages?",
            // Budget Tools [5]
            "This is an online calculator that can help you calculate your budget.\nhttps://www.quicken.com/budget-calculator",
            "Just click on the boxes to enter the amounts you spend in each category, then click 'next' on the site. The app will calculate your budget and show you clearly what you have and what you spend.",
            // Spreadsheets [7]
            "Try the following budget template from Microsoft Excel.\nhttps://goo.gl/YqXi8v",
            "This is a document you can fill in and save on your computer to make adjustments and check whenever you want."
        };

        // Setup int array to store indices of header transitions based on context text index
        contentTransitionIndices = new int[HEADER_COUNT] { 0, 1, 2, 3, 5, 7 };

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
        // Store index of next content
        int nextIndex = currentTextIndex + 1;
        // If the previous state is not < 0, check for header transition
        if (nextIndex < TEXT_COUNT)
        {
            // Check if the next index should transition to the next header text
            for (int i = 0; i < HEADER_COUNT; i++)
            {
                // If the next index is the next header transition
                if (nextIndex == contentTransitionIndices[i])
                {
                    // Show the next header text
                    mainScript.SetHeaderText(headerText[i]);
                    break;
                }
            }

            // Set the body display text to the next text in the array
            mainScript.SetBodyText(contentText[++currentTextIndex]);
        }
        else
        {
            // Go to the next state

            // Reset the progression animator's trigger for this state in case it's active
            if (progressionAnimator != null)
                progressionAnimator.ResetTrigger(currentTrigger);

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
        // Store index of previous content
        int prevIndex = currentTextIndex - 1;
        // If the previous state is not < 0, check for header transition
        if (prevIndex >= 0)
        {
            // Check if the next index should transition to the next header text
            for (int i = HEADER_COUNT - 1; i >= 0; i--)
            {
                // If the previous index is the previous header transition
                if (prevIndex == contentTransitionIndices[i] - 1)
                {
                    // Show the previous header text
                    mainScript.SetHeaderText(headerText[i - 1]);
                    break;
                }
            }

            // Set the body display text to the previous text in the array
            mainScript.SetBodyText(contentText[--currentTextIndex]);
        }
        else
        {
            // Go to the previous state

            // Reset the progression animator's trigger for this state in case it's active
            if (progressionAnimator != null)
            {
                progressionAnimator.ResetTrigger(currentTrigger);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Remove event listeners from buttons
        nextButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();

        // Set initial text index
        currentTextIndex = 0;
    }
}
