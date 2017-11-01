using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mod1Script : MonoBehaviour {

	private Canvas Mod1_Intro_Canvas;
	private Canvas Mod1_Menu_Canvas;

	//-----------------------//

	//public GameObject stepOneHeader;
	//private Text stepOneHeaderText;
	//public GameObject stepOneBody;
	//private Text stepOneBodyText;
	//public GameObject s2Button;
	//private Text s2ButtonText;

	private Canvas campDoneButtonCanvas;
	private Canvas toQuizCanvas;


	// Use this for initialization ---------//
	void Start () {

		// First canvas will introduce Module 1
		Mod1_Intro_Canvas = GameObject.Find ("Mod1_Intro_Canvas").GetComponent<Canvas> ();
		Mod1_Intro_Canvas.enabled = true;

		// Mod1 Menu Canvas - here the player can select to go to one of the four sections
		Mod1_Menu_Canvas = GameObject.Find ("Mod1_Menu_Canvas").GetComponent<Canvas> ();
		Mod1_Menu_Canvas.enabled = false; // hide

		//--------------------------------------//

		campDoneButtonCanvas = GameObject.Find ("CampBackButton").GetComponent<Canvas> ();
		campDoneButtonCanvas.enabled = false;

		//stepOneHeaderText = GameObject.Find ("S1CHeader").GetComponent<Text> ();
		//stepOneBodyText = GameObject.Find ("S1CBody").GetComponent<Text> ();

		toQuizCanvas = GameObject.Find ("ToQuiz").GetComponent<Canvas> ();
		toQuizCanvas.enabled = false;
	
	} //EOF void Start


	// ACTIONS / ANIMATIONS ---------------------------//

	public void Mod1_Intro_Button_Pressed(){

		// Fetch the player object
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");

		// Fetch its animatior
		Animator playerAnimatior = player [0].GetComponent<Animator> ();

		Mod1_Intro_Canvas.enabled = false;
		Mod1_Menu_Canvas.enabled = true;

		//Make the animator go to next state
		playerAnimatior.SetTrigger ("Clicked_Mod1_Intro_Button");

	} // EOF Mod1_Intro_Button_Pressed

	//-----------------------------//

		//stepOneHeaderText.text = "Should I document anything else?";
		//stepOneBodyText.text = "Yes! Take pictures of any and all valuables in your home. To show these items were part of your home, include children, family, or friend sin the photos.";
		//stepOneBodyText.text = "These documents need to be kept somewhere safe. Hide them if you need to." +
		//"\nConsider using a fireproof safe box with a combination lock. This can be kept at a trusted friend or family member's house.";
		//Debug.Log ("Made it");

		// Step3 Credit Canvas contains the video - review code

		//	public void creditButtonPressed(){
		//		step3Canvas.enabled = false;
		//		step3CreditCanvas.enabled = true;
		//		stepThreeHeaderText.text = "Using a credit card";
		//		stepThreeBodyText.text = "Applying for a credit card is relatively easy-- you can go online and find many companies that are happy to lend you money--\"credit\"-- because they expect you to pay it back, onfen with very high rates of interest!" +
		//		"\nUsing it wisely can be tricky. Here's a few tips for \"smart\" credit card use:";
		//	}

		//	public void videoButtonPressed(){
		//		Application.OpenURL ("https://www.youtube.com/watch?v=4Gv01qrJvcY");
		//	}

		//	public void beforeButtonPressed(){
		//		sdcCanvas.enabled = false;
		//		sdcContinuedCanvas.enabled = true;
		//		sdcHeaderText.text = "Before you see a lawyer...";
		//		sdcBodyText.text = 
		//			"\n * Inventory and categorize possessions: yours, " +
		//			"\n   your partner's, both of yorus." +
		//			"\n * Determine living expenses, especially if there are " +
		//			"\n   children." +
		//			"\n * Research your insurance coverage: auto, home, " +
		//			"\n   health, life.";
		//	}

		//	public void docsButtonPressed(){
		//		sdcCanvas.enabled = false;
		//		sdcContinuedCanvas.enabled = true;
		//		sdcHeaderText.fontSize = 25;
		//		sdcHeaderText.text = "Bring these documents when you meet your lawyer";
		//		sdcBodyText.text = 
		//			"\n " +
		//			"\n * Past income tax returns" +
		//			"\n * Paycheck stubs" +
		//			"\n * Copies of employee benefit statement" +
		//			"\n * Wish list of assets you would like to retian";
		//	}

} // EOF class Mod1Script