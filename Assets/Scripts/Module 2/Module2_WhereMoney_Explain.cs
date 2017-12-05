using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Module2_WhereMoney_Explain : StateMachineBehaviour
{
    // Reference to module 2 main script
    public Module2_Main mainScript;

    // References to animators
    private Animator progressionAnimator;
    private Animator mainDisplayAnimator;
    private Animator bodyDisplayAnimator;
    private string currentTrigger;

    // Video player fields
    private VideoPlayer videoPlayer;
    private string videoURL;

    // References to buttons
    private Button nextButton;
    private Button backButton;
    private Button videoButton;

    // Fields for content text
    private string[] headerText;
    private string[] contentText;
    private int[] contentTransitionIndices;
    private int currentTextIndex;
    private const int HEADER_COUNT = 6;
    private const int TEXT_COUNT = 22;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set player starting transform at the start of this state
        mainScript.SetPlayerPosition(new Vector3(85f, 179.6f, 90f));
        mainScript.SetPlayerRotation(Quaternion.Euler(0f, -180f, 0f));

        // Set the state trigger for this state
        currentTrigger = "whereToPutMoney";

        // Initialize references
        SetupReferences();

        // Initialize content
        SetupContent();

        // Set "fadeIn" trigger to active
        if (mainDisplayAnimator != null)
            mainDisplayAnimator.SetTrigger("fadeIn");

        // Set button event listeners
        if (nextButton != null)
            nextButton.onClick.AddListener(NextContent);

        if (backButton != null)
            backButton.onClick.AddListener(PrevContent);

        if (videoButton != null)
            videoButton.onClick.AddListener(PlayPauseVideo);
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

        // Get reference to the video player display object
        videoPlayer = mainScript.GetVideoPlayerDisplay();

        // Get references to buttons
        nextButton = mainScript.GetButton("Next");
        backButton = mainScript.GetButton("Back");
        videoButton = mainScript.GetButton("Video");
    }

    // Initialize the display content
    private void SetupContent()
    {
        // Setup string array of header text
        headerText = new string[HEADER_COUNT] {
            "Where to Put Your Money",
            "How to Choose a Bank",
            "Kinds of Financial Institutions",
            "Credit Unions",
            "Payday Lenders",
            "Check Cashing Stores"
        };

        // Setup string array of context text
        contentText = new string[TEXT_COUNT] {
            // Where to Put Your Money [0]
            "You have some options...",
            // How to Choose a Bank [1] Video
            "[VIDEO HERE]",
            // Kinds of Financial Institutions [2]
            "Banks are financial institutions that accept deposits and use the money for lending activites.",
            "A traditional bank issues stock and is therefore owned by its stockholders.",
            "Banks are for-profit businesses and serve customers from the general public.",
            "Most banks offer online services, and there are also banks that are only on the internet.",
            // Credit Unions [6]
            "Credit unions are community-based financial institutions that offer a wide range of services.",
            "They are owned and controlled by their members, who are also shareholders.",
            "Credit unions serve their members and membership is defined by a credit unions's charter.",
            "For example, a credit union may offer membership through certain employers or to certain professions.",
            "Another credit union may have a broader membership. Credit unions often offer lower interest rates on loans.",
            // Payday Lenders [11]
            "Payday lenders are companies that lend customers small amounts of money at very high interest rates.",
            "The borrower agrees that the loan will be repaid when the borrower's next paycheck arrives.",
            "Payday loans are small cash advances, usually $500 or less.",
            "To get a cash advance, a borrower typically gives the payday lender a postdated check or authorization to withdraw the funds from their bank account on an appointed date.",
            "While these types of loans may appear to be an easy option, expensive loan fees often push the borrower into deeper debt.",
            "This debt can be very difficult to get out of. Before taking this type of loan, explore all other options, including consulting your advocate or other support systems.",
            // Check Cashing Stores [17]
            "Check cashing stores are small businesses that cash checks for a fee.",
            "In general, the fee is about 4%. However, you can likely avoid these fees if you have a bank account or are a member of a credit union.",
            "If you have trouble keeping a minimum deposit in the bank, you may find the check cashing store a reasonable option in the short-term.",
            "You will avoid fees, but banks are the only places where you can save and earn interest (free money!) on your savings.",
            "It's best to open a bank account with a savings account as soon as you can."
        };

        // Setup int array to store indices of header transitions based on context text index
        contentTransitionIndices = new int[HEADER_COUNT] { 0, 1, 2, 6, 11, 17 };

        // Set initial text index
        currentTextIndex = 0;

        // Set the header text
        mainScript.SetHeaderText(headerText[0]);

        // Set the body display text to the starting text
        mainScript.SetBodyText(contentText[0]);

        // Video to load
        videoURL = "Assets/Video/5 Factors to Look at When Choosing a Bank by Rocky Clancy.mp4";
        videoPlayer.url = videoURL;
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

            // If we should play the video
            if (currentTextIndex == 1)
            {
                // Show the video player
                mainScript.videoPlayerObj.SetActive(true);
            }
            else
            {
                // Hide the video player
                mainScript.videoPlayerObj.SetActive(false);
            }
        }
        else
        {
            // Go to the next state
            // Hide the video player
            mainScript.videoPlayerObj.SetActive(false);

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

            // If we should play the video
            if (currentTextIndex == 1)
            {
                // Show the video player
                mainScript.videoPlayerObj.SetActive(true);
            }
            else
            {
                // Hide the video player
                mainScript.videoPlayerObj.SetActive(false);
            }
        }
        else
        {
            // Go to the previous state

            // Reset the progression animator's trigger for this state in case it's active
            if (progressionAnimator != null)
            {
                progressionAnimator.ResetTrigger(currentTrigger);
            }

            // Fade to previous section
            mainScript.GetMainDisplayAnimator().SetTrigger("hide");
            mainScript.GetCameraFadeObject().FadeToState("Base Layer.Budgeting and Saving.Thinking for Saving");
        }
    }

    void PlayPauseVideo()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            videoPlayer.Play();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Hide the video player
        mainScript.videoPlayerObj.SetActive(false);

        // Remove event listeners from buttons
        nextButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();
        videoButton.onClick.RemoveAllListeners();

        // Set initial text index
        currentTextIndex = 0;
    }
}
