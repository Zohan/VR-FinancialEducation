using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module2_BudgetSaving_Explain : StateMachineBehaviour {
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
    private const int HEADER_COUNT = 8;
    private const int TEXT_COUNT = 27;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set player starting transform at the start of this state
        mainScript.SetPlayerPosition(new Vector3(107f, 178.7f, 110f));
        mainScript.SetPlayerRotation(Quaternion.Euler(0f, -67.5f, 0f));

        // Set the state trigger for this state
        currentTrigger = "budgetSaving";

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
            "Budgeting and Saving",
            "Where To Start",
            "How to Track Spending",
            "Step 1",
            "Step 2",
            "Step 3",
            "Step 4",
            "Step 5"
        };

        // Setup string array of context text
        contentText = new string[TEXT_COUNT] {
            // Budgeting and Saving [0]
            "After looking into resources you may not have accessed before, now it's time to look more closely at your current money situation.",
            "How much money is coming in?",
            "How much is going out? Where is it going?",
            "How much is left at the end of the month?",
            "Can you reach your short- and long-term goals with these levels of saving and spending?",
            // Where to Start [5]
            "First, all you have to do is track your spending.",
            "It's as simple as keeping a list of what you do with your money on a daily basis. Then, at the end of the month, you take a look.",
            "What look like needs? What are things you can cut out to save money for your future?",
            // Hot to Track Spending [8]
            "It's easy to track your spending if you focus on a short timeframe, such as one week.",
            "When you see all of your expenses laid out, you may be able to identify some simple changes that could make a big difference in your finances--helping you stretch your paycheck or build your savings.",
            "Here is a worksheet to help you get started: https://www.saveandinvest.org/sites/default/files/Worksheet-Track-Your-Spending_o.pdf",
            // Step 1 [11]
            "First, list your regular monthly bills, such as your mortgage or rent, car loan, utilities, phone, Internet service, cable TV, credit card bills (and any interest you pay, too), insurance premiums and childcare expenses.",
            // Step 2 [12]
            "Next, track your out-of-pocket spending for a week. Keep track of all the money you spend for a week on groceries, gas, meals, clothes, entertainment, personal items, and even coffee and snacks.",
            "Keep a small notebook with you or just collect the receipts during the day and add them to the list in the evening.",
            "Keep track of all expenses for the week, whether you pay for them in cash or use a debit card, credit card, check or mobile app.",
            // Step 3 [15]
            "Now, review the numbers. Now that you can see how you've spent your money, look for ways to save.",
            "Some strategies may be simple, like cutting back on meals out or using in-network ATMs to avoid fees.",
            "You may also want to make bigger changes that can save more money, such as cutting back on your cell phone package or dropping cable TV.",
            // Step 4 [18]
            "Next, review your big-ticket expenses.",
            "After you've reviewed your regular expenses, it can also help to review your big-ticket bills for the past year--the special expenses such as home improvements, car repairs, travel, education, furniture and electronics.",
            "These bills don't crop up every month but can make a big difference in your finances--and can land you in debt if you aren't prepared.",
            "Go through your credit card statements, bank records and receipts to list the cost of these items.",
            "Looking at these irregular costs will help you plan better for emergencies and other unexpected bills.",
            // Step 5 [23]
            "Finally, create a plan.",
            "Review all of your expenses for ways to cut back, and then decide what to do with the extra money.",
            "Set specific goals, such as building an emergency fund, paying off your credit card bills, or increasing your retirement savings.",
            "Remember, if you want things to be different in the future, you have to start making changes in the present!"
        };

        // Setup int array to store indices of header transitions based on context text index
        contentTransitionIndices = new int[HEADER_COUNT] { 0, 5, 8, 11, 12, 15, 18, 23 };

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
