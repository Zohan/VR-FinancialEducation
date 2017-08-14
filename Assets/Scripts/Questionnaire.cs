using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Questionnaire : MonoBehaviour {

	// Public fields
	public GameObject leftButton;
	public GameObject rightButton;
	//public float fadeTime = 3.0f;

	// Private fields
	//int questionNumber;
	//float genTimer;
	//float fadePerSecond;
	//float startDelay;
	//float startTimer;
	//float welcomeTime;
	//bool isDisplayTime;
	//bool isQuestionTime;
	Text displayText;
	GameObject displayCanvas;
	//Material displayMaterial;
	//Animator displayAnimator;

	// Use this for initialization
	void Start () {
		// Initialize private fields
		//fadePerSecond = fadeTime;
		//startDelay = 3.0f;
		//startTimer = startDelay;
		//welcomeTime = 4.0f;
		//genTimer = 0.0f;
		//questionNumber = 0; // Restart questionnaire
		//isDisplayTime = false;
		//isQuestionTime = false;

		// Get reference to child canvas gameobject
		displayCanvas = transform.GetChild(0).gameObject;
		// Get reference to canvas text
		displayText = displayCanvas.transform.GetChild(0).GetComponent<Text>();
		// Get reference to cube material
		//displayMaterial = GetComponent<Renderer>().material;
		// Get reference to Animator component
		//displayAnimator = GetComponent<Animator>();

		// Set the welcome text
		displayText.text = "Welcome to your Financial Education experience!";
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

	}
}