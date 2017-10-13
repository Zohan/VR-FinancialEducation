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

    // References to buttons
    private Button nextButton;
    private Button backButton;

    // Fields for content text
    private string[] headerText;
    private string[] contentText;
    private int currentTextIndex;
    private const int HEADER_COUNT = 8;
    private const int TEXT_COUNT = 27;

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
            // Budgeting and Saving
            "After looking into resources you may not have accessed before, now it's time to look more closely at your current money situation.",
            "How much money is coming in?",
            "How much is going out? Where is it going?",
            "How much is left at the end of the month?",
            "Can you reach your short- and long-term goals with these levels of saving and spending?",
            // Where to Start
            "First, all you have to do is track your spending.",
            "It's as simple as keeping a list of what you do with your money on a daily basis. Then, at the end of the month, you take a look.",
            "What look like needs? What are things you can cut out to save money for your future?",
            // Hot to Track Spending
            "It's easy to track your spending if you focus on a short timeframe, such as one week.",
            "When you see all of your expenses laid out, you may be able to identify some simple changes that could make a big difference in your finances--helping you stretch your paycheck or build your savings.",
            "Here is a worksheet to help you get started: https://www.saveandinvest.org/sites/default/files/Worksheet-Track-Your-Spending_o.pdf",
            // Step 1
            "First, list your regular monthly bills, such as your mortgage or rent, car loan, utilities, phone, Internet service, cable TV, credit card bills (and any interest you pay, too), insurance premiums and childcare expenses.",
            // Step 2
            "Next, track your out-of-pocket spending for a week. Keep track of all the money you spend for a week on groceries, gas, meals, clothes, entertainment, personal items, and even coffee and snacks.",
            "Keep a small notebook with you or just collect the receipts during the day and add them to the list in the evening.",
            "Keep track of all expenses for the week, whether you pay for them in cash or use a debit card, credit card, check or mobile app.",
            // Step 3
            "Now, review the numbers. Now that you can see how you've spent your money, look for ways to save.",
            "Some strategies may be simple, like cutting back on meals out or using in-network ATMs to avoid fees.",
            "You may also want to make bigger changes that can save more money, such as cutting back on your cell phone package or dropping cable TV.",
            // Step 4
            "Next, review your big-ticket expenses.",
            "After you've reviewed your regular expenses, it can also help to review your big-ticket bills for the past year--the special expenses such as home improvements, car repairs, travel, education, furniture and electronics.",
            "These bills don't crop up every month but can make a big difference in your finances--and can land you in debt if you aren't prepared.",
            "Go through your credit card statements, bank records and receipts to list the cost of these items.",
            "Looking at these irregular costs will help you plan better for emergencies and other unexpected bills.",
            // Step 5
            "Finally, create a plan.",
            "Review all of your expenses for ways to cut back, and then decide what to do with the extra money.",
            "Set specific goals, such as building an emergency fund, paying off your credit card bills, or increasing your retirement savings.",
            "Remember, if you want things to be different in the future, you have to start making changes in the present!"
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
        if (currentTextIndex + 1 < 5)
        {
            // Display the first header text for the first portion of content
            mainScript.SetHeaderText(headerText[0]);
        }
        else if (currentTextIndex + 1 < 8)
        {
            mainScript.SetHeaderText(headerText[1]);
        }
        else if (currentTextIndex + 1 < 11)
        {
            mainScript.SetHeaderText(headerText[2]);
        }
        else if (currentTextIndex + 1 < 12)
        {
            mainScript.SetHeaderText(headerText[3]);
        }
        else if (currentTextIndex + 1 < 15)
        {
            mainScript.SetHeaderText(headerText[4]);
        }
        else if (currentTextIndex + 1 < 18)
        {
            mainScript.SetHeaderText(headerText[5]);
        }
        else if (currentTextIndex + 1 < 23)
        {
            mainScript.SetHeaderText(headerText[6]);
        }
        else
        {
            mainScript.SetHeaderText(headerText[7]);
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
        if (currentTextIndex - 1 < 5)
        {
            // Display the first header text for the first portion of content
            mainScript.SetHeaderText(headerText[0]);
        }
        else if (currentTextIndex - 1 < 8)
        {
            mainScript.SetHeaderText(headerText[1]);
        }
        else if (currentTextIndex - 1 < 11)
        {
            mainScript.SetHeaderText(headerText[2]);
        }
        else if (currentTextIndex - 1 < 12)
        {
            mainScript.SetHeaderText(headerText[3]);
        }
        else if (currentTextIndex - 1 < 15)
        {
            mainScript.SetHeaderText(headerText[4]);
        }
        else if (currentTextIndex - 1 < 18)
        {
            mainScript.SetHeaderText(headerText[5]);
        }
        else if (currentTextIndex - 1 < 23)
        {
            mainScript.SetHeaderText(headerText[6]);
        }
        else
        {
            mainScript.SetHeaderText(headerText[7]);
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
}
