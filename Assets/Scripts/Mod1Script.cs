using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mod1Script : MonoBehaviour {

	private Canvas Mod1Canvas;
	private Canvas beginCanvas;
	private Canvas safetyPlanningCanvas;
	private Canvas f1ButtonCanvas;
	private Canvas step1Prompt;
	private Canvas step1Canvas;
	private Canvas step1ContinuedCanvas;

	private Canvas step1DocsCanvas;
	private Canvas campDoneButtonCanvas;

	private Canvas f2ButtonCanvas;
	private Canvas step2Prompt;
	private Canvas step2Canvas;
	private Canvas step2HowCanvas;
	private Canvas step2AssetsCanvas;
	private Canvas step2ImportantCanvas;
	private Canvas f3ButtonCanvas;
	private Canvas step3Prompt;
	private Canvas step3Canvas;
	private Canvas step3BankCanvas;
	private Canvas step3CreditCanvas;
	private Canvas step3WhyCanvas;
	private Canvas step3BasicsCanvas;

	public GameObject stepOneHeader;
	private Text stepOneHeaderText;
	public GameObject stepOneBody;
	private Text stepOneBodyText;

	public GameObject stepTwoHeader;
	private Text stepTwoHeaderText;
	public GameObject stepTwoBody;
	private Text stepTwoBodyText;
	public GameObject s2Button;
	private Text s2ButtonText;

	public GameObject stepThreeHeader;
	private Text stepThreeHeaderText;
	public GameObject stepThreeBody;
	private Text stepThreeBodyText;

	private Canvas return1Canvas;
	private Canvas f4ButtonCanvas;
	private Canvas sdcCanvasPrompt;
	private Canvas sdcCanvas;
	private Canvas sdcContinuedCanvas;

	public GameObject sdcHeader;
	private Text sdcHeaderText;
	public GameObject sdcBody;
	private Text sdcBodyText;

	private Canvas f5ButtonCanvas;
	private Canvas return2Canvas;
	private Canvas privacyCanvasPrompt;
	private Canvas privacyCanvas;

	private Canvas toQuizCanvas;
	private Canvas return3Canvas;


	static bool text = false;


	// Use this for initialization
	void Start () {

		// First canvas will introduce Mod1
		Mod1Canvas = GameObject.Find ("Mod1Canvas").GetComponent<Canvas> ();
		Mod1Canvas.enabled = true;

		// Begin Mod1 Canvas - here player may select to go to one of the three topics or the quiz
		beginCanvas = GameObject.Find ("Begin").GetComponent<Canvas> ();
		beginCanvas.enabled = false;

		//--------------------------------------//

		// 1st Canvas for Safety Planning topic
		safetyPlanningCanvas = GameObject.Find ("SPCanvas").GetComponent<Canvas> ();
		safetyPlanningCanvas.enabled = false;

		// f1 : forward 1
		f1ButtonCanvas = GameObject.Find ("Forward1").GetComponent<Canvas> ();
		f1ButtonCanvas.enabled = false;

		step1Prompt = GameObject.Find ("S1Prompt").GetComponent<Canvas> ();
		step1Prompt.enabled = false;

		step1Canvas = GameObject.Find ("Step1Canvas").GetComponent<Canvas> ();
		step1Canvas.enabled = false;

		step1ContinuedCanvas = GameObject.Find ("Step1Continued").GetComponent<Canvas> ();
		step1ContinuedCanvas.enabled = false;

		step1DocsCanvas = GameObject.Find ("Step1Docs").GetComponent<Canvas>();
		step1DocsCanvas.enabled = false;

		campDoneButtonCanvas = GameObject.Find ("CampBackButton").GetComponent<Canvas> ();
		campDoneButtonCanvas.enabled = false;

		f2ButtonCanvas = GameObject.Find ("Forward2").GetComponent<Canvas> ();
		f2ButtonCanvas.enabled = false;

		step2Prompt = GameObject.Find ("S2Prompt").GetComponent<Canvas> ();
		step2Prompt.enabled = false;

		step2Canvas = GameObject.Find ("Step2Canvas").GetComponent<Canvas> ();
		step2Canvas.enabled = false;

		step2HowCanvas = GameObject.Find ("Step2How").GetComponent<Canvas> ();
		step2HowCanvas.enabled = false;

		step2AssetsCanvas = GameObject.Find ("Step2Assets").GetComponent<Canvas> ();
		step2AssetsCanvas.enabled = false;

		step2ImportantCanvas = GameObject.Find ("Step2Important").GetComponent<Canvas> ();
		step2ImportantCanvas.enabled = false;

		f3ButtonCanvas = GameObject.Find ("Forward3").GetComponent<Canvas> ();
		f3ButtonCanvas.enabled = false;

		step3Prompt = GameObject.Find ("S3Prompt").GetComponent<Canvas> ();
		step3Prompt.enabled = false;

		step3Canvas = GameObject.Find ("Step3Canvas").GetComponent<Canvas> ();
		step3Canvas.enabled = false;
		step3BankCanvas = GameObject.Find ("Step3BankCanvas").GetComponent<Canvas> ();
		step3BankCanvas.enabled = false;
		step3CreditCanvas = GameObject.Find ("Step3CreditCanvas").GetComponent<Canvas> ();
		step3CreditCanvas.enabled = false;

		step3WhyCanvas = GameObject.Find ("Step3WhyCanvas").GetComponent<Canvas> ();
		step3WhyCanvas.enabled = false;

		step3BasicsCanvas = GameObject.Find ("Step3BasicsCanvas").GetComponent<Canvas> ();
		step3BasicsCanvas.enabled = false;

		stepOneHeaderText = GameObject.Find ("S1CHeader").GetComponent<Text> ();
		stepOneBodyText = GameObject.Find ("S1CBody").GetComponent<Text> ();
		/*stepTwoHeaderText = GameObject.Find ("S2CHeader").GetComponent<Text> ();
		stepTwoBodyText = GameObject.Find ("S2CBody").GetComponent<Text> ();
		//s2ButtonText = GameObject.Find ("ButtonText2").GetComponent<Text> ();
		s2ButtonText = GameObject.Find ("ButtonText").GetComponent<Text> ();*/
		stepThreeHeaderText = GameObject.Find ("S3CHeader").GetComponent<Text> ();
		stepThreeBodyText = GameObject.Find ("S3CBody").GetComponent<Text> ();

		return1Canvas = GameObject.Find ("Return1").GetComponent<Canvas> ();
		return1Canvas.enabled = false;

		f4ButtonCanvas = GameObject.Find ("Forward4").GetComponent<Canvas> ();
		f4ButtonCanvas.enabled = false;

		sdcCanvasPrompt = GameObject.Find ("SDCCanvasPrompt").GetComponent<Canvas> ();
		sdcCanvasPrompt.enabled = false;

		sdcCanvas = GameObject.Find ("SDCCanvas").GetComponent<Canvas> ();
		sdcCanvas.enabled = false;

		sdcContinuedCanvas = GameObject.Find ("SDCcontinuedCanvas").GetComponent<Canvas> ();
		sdcContinuedCanvas.enabled = false;

		sdcHeaderText = GameObject.Find ("CHeader").GetComponent<Text> ();
		sdcBodyText = GameObject.Find ("CBody").GetComponent<Text> ();

		
		return2Canvas = GameObject.Find ("Return2").GetComponent<Canvas> ();
		return2Canvas.enabled = false;

		f5ButtonCanvas = GameObject.Find ("Forward5").GetComponent<Canvas> ();
		f5ButtonCanvas.enabled = false;

		privacyCanvasPrompt = GameObject.Find ("PCanvasPrompt").GetComponent<Canvas> ();
		privacyCanvasPrompt.enabled = false;

		privacyCanvas = GameObject.Find ("PCanvas").GetComponent<Canvas> ();
		privacyCanvas.enabled = false;

		return3Canvas = GameObject.Find ("Return3").GetComponent<Canvas> ();
		return3Canvas.enabled = false;

		toQuizCanvas = GameObject.Find ("ToQuiz").GetComponent<Canvas> ();
		toQuizCanvas.enabled = false;
	}


	// ACTIONS / ANIMATIONS ---------------------------//

	public void Mod1ButtonPressed(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		//GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");

		//var BeginCanvasPos = GameObject.Find ("Begin");
		//Vector3 movementVector = BeginCanvasPos.transform.position;
	
		//var forward = -5f;
		//var left = 2f;
		// Vector( -left / + right , -down / +up , -back / +forward )
		Vector3 movementVector = new Vector3 (-4f, 3f, 1f);
		//Vector3 movementVector = new Vector3 (-1f, 0, 7f);
		player [0].transform.Translate (movementVector);
		player [0].transform.rotation = Quaternion.Euler(new Vector3(-15, -456, 720));
		beginCanvas.enabled = true;
	}

	//-----------------------------//

	public void sPButtonPressed(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		//GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (-1f, 0, 7f);
		player [0].transform.Translate (movementVector);
		safetyPlanningCanvas.enabled = true;
		beginCanvas.enabled = false;
		step3BasicsCanvas.enabled = false;
	}

	// Commented the following while reorganizing first two canvas
	// safety planning canvas done pressed
	//public void showF1Button(){
	//	f1ButtonCanvas.enabled = true;
	//	safetyPlanningCanvas.enabled = false;
	//}

	// f1button pressed 
	public void forwardToStepOne(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (-3f, -.7f, 9f);
		player [0].transform.Translate (movementVector);
		step1Prompt.enabled = true;
		f1ButtonCanvas.enabled = false;
	}

	public void showStep1(){
		step1Prompt.enabled = false;
		step1Canvas.enabled = true;
	}

	public void docsPressed(){
		step1Canvas.enabled = false;
		step1DocsCanvas.enabled = true;
	}

	public void docsBackButtonPressed(){
		step1Canvas.enabled = true;
		step1DocsCanvas.enabled = false;
	}

	public void seeButtonPressed(){
		step1DocsCanvas.enabled = false;
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (85f,182.8f,90f);
		player [0].transform.position = movementVector;
		campDoneButtonCanvas.enabled = true;
	}

	public void campDoneButtonPressed(){
		step1DocsCanvas.enabled = true;
		campDoneButtonCanvas.enabled = false;
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		//Vector3 movementVector = new Vector3 (132.5f,182.8f,100f);
		Vector3 movementVector = new Vector3 (131f,182.8f,100f);
		player [0].transform.position = movementVector;
	}

	public void otherPressed(){
		step1Canvas.enabled = false;
		step1ContinuedCanvas.enabled = true;
		stepOneHeaderText.text = "Should I document anything else?";
		stepOneBodyText.text = "Yes! Take pictures of any and all valuables in your home. To show these items were part of your home, include children, family, or friend sin the photos.";
	}

	public void doPressed(){
		step1Canvas.enabled = false;
		step1ContinuedCanvas.enabled = true;
		stepOneHeaderText.text = "What should I do with these documents?";
		stepOneBodyText.text = "These documents need to be kept somewhere safe. Hide them if you need to." +
		"\nConsider using a fireproof safe box with a combination lock. This can be kept at a trusted friend or family member's house.";
	}

	public void s1BackPressed(){
		step1ContinuedCanvas.enabled = false;
		step1Canvas.enabled = true;
	}

	public void stepOneNextPressed(){
		step1Canvas.enabled = false;
		step1ContinuedCanvas.enabled = false;
		f2ButtonCanvas.enabled = true;
	}

	public void forwardToStepTwo(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		//Vector3 movementVector = new Vector3 (-2f, -.7f, 4f);
		Vector3 movementVector = new Vector3 (-2f, -.7f, 10.5f);
		player [0].transform.Translate (movementVector);
		step2Prompt.enabled = true;
		f2ButtonCanvas.enabled = false;
	}

	public void showStep2(){
		step2Prompt.enabled = false;
		step2Canvas.enabled = true;
	}

	public void howButtonPressed(){
		step2Canvas.enabled = false;
		step2HowCanvas.enabled = true;
	}

	public void assetsButtonPressed(){
		step2Canvas.enabled = false;
		step2AssetsCanvas.enabled = true;
	}

	public void s2BackButtonPressed(){
		step2HowCanvas.enabled = false;
		step2AssetsCanvas.enabled = false;
		step2Canvas.enabled = true;
	}

	public void s2ContinueButtonPressed(){
		step2AssetsCanvas.enabled = false;
		step2ImportantCanvas.enabled = true;
	}

	public void s2ImportantBackButtonPressed(){
		step2ImportantCanvas.enabled = false;
		step2AssetsCanvas.enabled = true;
	}

	public void s2NextPressed(){
		step2Canvas.enabled = false;
		step2HowCanvas.enabled = false;
		f3ButtonCanvas.enabled = true;
	}

	public void forwardToStepThree(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (5f, -.7f, 14f);
		player [0].transform.Translate (movementVector);
		step3Prompt.enabled = true;
		f3ButtonCanvas.enabled = false;
		//Debug.Log ("Made it");
	}

	public void showStep3(){
		step3Prompt.enabled = false;
		step3Canvas.enabled = true;
	}
				
	public void accountButtonPressed(){
		step3Canvas.enabled = false;
		step3BankCanvas.enabled = true;
	}
	
	public void urlButtonPressed(){
		Application.OpenURL ("www.wikihow.com/Open-a-Bank-Account");
	}

	public void s3BackPressed(){
		step3BankCanvas.enabled = false;
		step3CreditCanvas.enabled = false;
		step3Canvas.enabled = true;
	}

	public void creditButtonPressed(){
		step3Canvas.enabled = false;
		step3CreditCanvas.enabled = true;
		stepThreeHeaderText.text = "Using a credit card";
		stepThreeBodyText.text = "Applying for a credit card is relatively easy-- you can go online and find many companies that are happy to lend you money--\"credit\"-- because they expect you to pay it back, onfen with very high rates of interest!" +
		"\nUsing it wisely can be tricky. Here's a few tips for \"smart\" credit card use:";
	}

	public void whyButtonPressed(){
		step3CreditCanvas.enabled = false;
		step3WhyCanvas.enabled = true;
	}

	public void whyBackButtonPressed(){
		step3WhyCanvas.enabled = false;
		step3CreditCanvas.enabled = true;
	}

	public void basicsButtonPressed(){
		step3CreditCanvas.enabled = false;
		step3WhyCanvas.enabled = false;
		step3BasicsCanvas.enabled = true;
	}

	public void basicsURLButtonPressed(){
		Application.OpenURL ("https://www.thebalance.com/tips-for-starting-out-with-credit-960187");
	}

	public void basicsBackButtonPressed(){
		step3BasicsCanvas.enabled = false;
		step3CreditCanvas.enabled = true;
	}

	public void videoButtonPressed(){
		Application.OpenURL ("https://www.youtube.com/watch?v=4Gv01qrJvcY");
	}

	public void s3VidBackButtonPressed(){
		step3CreditCanvas.enabled = true;
	}

	public void s3NextPressed(){
		step3Canvas.enabled = false;
		f4ButtonCanvas.enabled = true;
		return1Canvas.enabled = true;
	}

	public void returnPressed(){
		sdcCanvas.enabled = false;
		privacyCanvas.enabled = false;
		step3Canvas.enabled = false;
		beginCanvas.enabled = true;
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (148f,182.8f,98f);
		player [0].transform.position = movementVector;
		return1Canvas.enabled = false;
		return2Canvas.enabled = false;
		return3Canvas.enabled = false;
	}

	public void sDCButtonPressed(){
		sdcCanvasPrompt.enabled = true;
		beginCanvas.enabled = false;
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		//Vector3 movementVector = new Vector3 (123f,180f,100f);
		Vector3 movementVector = new Vector3 (90f,182f,114f);
		player [0].transform.position = movementVector;
	}

	public void forwardToSDCCavnas(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		//Vector3 movementVector = new Vector3 (1f, -.7f, 3.5f);
		Vector3 movementVector = new Vector3 (-2f, -.7f, 19f);
		player [0].transform.Translate (movementVector);
		f2ButtonCanvas.enabled = false;
		f3ButtonCanvas.enabled = false;
		f4ButtonCanvas.enabled = false;
		step3Canvas.enabled = false;
		sdcCanvasPrompt.enabled = true;
		return1Canvas.enabled = false;
	}

	public void sDCPromptPressed(){
		sdcCanvasPrompt.enabled = false;
		sdcCanvas.enabled = true;
	}

	public void beforeButtonPressed(){
		sdcCanvas.enabled = false;
		sdcContinuedCanvas.enabled = true;
		sdcHeaderText.text = "Before you see a lawyer...";
		sdcBodyText.text = 
			"\n * Inventory and categorize possessions: yours, " +
			"\n   your partner's, both of yorus." +
			"\n * Determine living expenses, especially if there are " +
			"\n   children." +
			"\n * Research your insurance coverage: auto, home, " +
			"\n   health, life.";
	}

	public void docsButtonPressed(){
		sdcCanvas.enabled = false;
		sdcContinuedCanvas.enabled = true;
		sdcHeaderText.fontSize = 25;
		sdcHeaderText.text = "Bring these documents when you meet your lawyer";
		sdcBodyText.text = 
			"\n " +
			"\n * Past income tax returns" +
			"\n * Paycheck stubs" +
			"\n * Copies of employee benefit statement" +
			"\n * Wish list of assets you would like to retian";
	}

	public void csButtonPressed(){
		sdcCanvas.enabled = false;
		sdcContinuedCanvas.enabled = true;
		sdcHeaderText.text = "Child Support";
		sdcBodyText.text = "You may be able to collect child support if there is at least one child who is under eighteen." +
			"\nYou can pursue child support enforcement in several ways by working with local child support enforcement agencies or going to court" +
			"\nPeople who have received assistance under TANF(Temporary Assistance for Needy Families), Medicaid, and federally-assisted foster care programs are automatically referred for child-support enforcement services.";
	}

	public void sdcBackPressed(){
		sdcContinuedCanvas.enabled = false;
		sdcCanvas.enabled = true;
	}

	public void sdcNextPressed(){
		sdcCanvas.enabled = false;
		f5ButtonCanvas.enabled = true;
		return2Canvas.enabled = true;
	}

	public void privacyButtonPressed(){
		privacyCanvasPrompt.enabled = true;
		beginCanvas.enabled = false;
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		//Vector3 movementVector = new Vector3 (119f,178.8f,101f);
		Vector3 movementVector = new Vector3 (72f,179.8f,118f);
		player [0].transform.position = movementVector;
	}
		
	public void forwardToPrivacyCavnas(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (-2f, 5f, 19f);
		player [0].transform.Translate (movementVector);
		f5ButtonCanvas.enabled = false;
		privacyCanvasPrompt.enabled = true;
		return2Canvas.enabled = false;
	}

	public void privacyCanvasPromptPressed(){
		privacyCanvasPrompt.enabled = false;
		privacyCanvas.enabled = true;
	}

	public void privacyURLButtonPressed(){
		Application.OpenURL ("http://nnedv.org/downloads/SafetyNet/NNEDV_IdentityChange_MythsAndRealities.pdf");
	}

	public void privacyNextPressed(){
		toQuizCanvas.enabled = true;
		return3Canvas.enabled = true;
		privacyCanvas.enabled = false;
	}

	// check knowledge at starting canvas pressed OR toQuiz button on privacy canvas pressed
	public void checkButtonPressed(){
		//transition to quiz scene
		toQuizCanvas.enabled = false;
		return3Canvas.enabled = false;
	}
}
