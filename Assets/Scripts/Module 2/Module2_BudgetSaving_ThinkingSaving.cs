using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Module2_BudgetSaving_ThinkingSaving : StateMachineBehaviour {
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
    private const int HEADER_COUNT = 2;
    private const int TEXT_COUNT = 4;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Set player starting transform at the start of this state
        mainScript.SetPlayerPosition(new Vector3(87f, 177f, 113.3f));
        mainScript.SetPlayerRotation(Quaternion.Euler(0f, -240.0f, 0f));

        // Set the state trigger for this state
        currentTrigger = "thinkingSaving";

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
            "Thinking for Saving",
            "Tips for Saving Money"
        };

        // Setup string array of context text
        contentText = new string[TEXT_COUNT] {
            // Thinking for Saving [0]
            "Why is it so hard to manage our money so we can save for the future?",
            "The future feels so far away. Today feels more important, more meaningful.",
            "But remember, savings is a gift to your future yourself!",
            // Tips for Saving Money [3] Video
            ""
        };

        // Setup int array to store indices of header transitions based on context text index
        contentTransitionIndices = new int[HEADER_COUNT] { 0, 3 };

        // Set initial text index
        currentTextIndex = 0;

        // Set the header text
        mainScript.SetHeaderText(headerText[0]);

        // Set the body display text to the starting text
        mainScript.SetBodyText(contentText[0]);

        // Video to load
        videoURL = "Assets/Video/How to Save Money Every Day.mp4";
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
            if (currentTextIndex == 3)
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
            if (currentTextIndex == 3)
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
            mainScript.GetCameraFadeObject().FadeToState("Base Layer.Budgeting and Saving.Make Budget");
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
