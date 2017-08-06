using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Questionnaire : MonoBehaviour {

	// Public fields
	public GameObject leftButton;
	public GameObject rightButton;
	public float fadeTime = 3.0f;

	// Private fields
	int questionNumber;
	float genTimer;
	float fadePerSecond;
	float startDelay;
	float startTimer;
	float welcomeTime;
	bool isDisplayTime;
	bool isQuestionTime;
	Text displayText;
	GameObject displayCanvas;
	Material displayMaterial;
	Animator displayAnimator;

	// Use this for initialization
	void Start () {
		// Initialize private fields
		fadePerSecond = fadeTime;
		startDelay = 3.0f;
		startTimer = startDelay;
		welcomeTime = 4.0f;
		genTimer = 0.0f;
		questionNumber = 0; // Restart questionnaire
		isDisplayTime = false;
		isQuestionTime = false;

		// Get reference to child canvas gameobject
		displayCanvas = transform.GetChild(0).gameObject;
		// Get reference to canvas text
		displayText = displayCanvas.transform.GetChild(0).GetComponent<Text>();
		// Get reference to cube material
		displayMaterial = GetComponent<Renderer>().material;
		// Get reference to Animator component
		displayAnimator = GetComponent<Animator>();

		//Debug.Log("startAlpha = " + displayMaterial.color.a);
		//displayMaterial.color = new Color(displayMaterial.color.r, displayMaterial.color.g, displayMaterial.color.b, 0.0f);

		// Set the welcome text
		displayText.text = "Welcome to your Financial Education experience!";
		// Hide display
		//displayCanvas.SetActive(false);

		// Disable input buttons at the start of the questionnaire
		//leftButton.SetActive(false);
		//rightButton.SetActive(false);
	}

	public void enableButtons (int value)
	{
		switch(value)
		{
		case 1:
			// Enable input buttons at the start of the questionnaire
			leftButton.SetActive(true);
			rightButton.SetActive(true);
			break;
		default:
			// Disable input buttons at the start of the questionnaire
			leftButton.SetActive(false);
			rightButton.SetActive(false);
			break;
		}
	}

	public void setText(string value)
	{
		displayText.text = value;
	}

	// Update is called once per frame
	void Update () {

		// Initial display timer
		if (!isDisplayTime)
		{
			//startTimer -= Time.deltaTime;
			genTimer += Time.deltaTime;
			if (genTimer >= startDelay)
			{
				isDisplayTime = true;
				genTimer = 0.0f;
			}
		}
		// If it's time to display the welcome text
		else
		{
			// Start timer
			fadePerSecond -= Time.deltaTime;
			genTimer += Time.deltaTime;

			if (!isQuestionTime)
			{
				// If we've reached the expected time
				if (genTimer >= fadeTime)
				{
					// Show display
					//displayMaterial.color = new Color(displayMaterial.color.r, displayMaterial.color.g, displayMaterial.color.b, 1f);
					displayCanvas.SetActive(true);
					genTimer = 0.0f;
					isQuestionTime = true;
				}
				else
				{
					// Gradually fade in the shape via alpha value
					float calcAlpha = (fadeTime - fadePerSecond) / fadeTime;
					//displayMaterial.color = new Color(displayMaterial.color.r, displayMaterial.color.g, displayMaterial.color.b, calcAlpha);
				}
			}
			else
			{
				// If we've reached the expected time
				if (genTimer >= welcomeTime)
				{
					/*switch (questionNumber) {
					case 0:
						displayText.text = "Does your partner control how your money is spent?";
						displayCanvas.SetActive(true);
						break;

					case 1:
						break;

					case 2:
						break;

					default: 
						break;
					}*/

					// Set first question text
					displayText.text = "Where would you like to start??";
					// Show display
					displayCanvas.SetActive(true);
					//AssetBundle myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes/");
					//string[] scenePaths;
					//scenePaths = myLoadedAssetBundle.GetAllScenePaths();
					SceneManager.LoadScene("Scenes/MountainLake");
					//Debug.Log("scene2 loading: " + scenePaths[0]);
					//SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);

					// Enable input buttons at the start of the questionnaire
					//leftButton.SetActive(true);
					//rightButton.SetActive(true);
				}
			}
		}
	}
}