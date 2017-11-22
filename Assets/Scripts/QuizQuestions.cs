using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class QuizQuestions : MonoBehaviour {

	// The player object will be used to fetch its animatior for movement transitions
	private GameObject[] player;

	// Variable to hold the player's animatior
	private Animator playerAnimatior;

	GameObject startSign;
	private Canvas startCanvas;

	GameObject q1Sign;
	private Canvas q1Canvas;
	public static bool q1O1Pressed;
	public static bool q1O2Pressed;

	GameObject q2Sign;
	private Canvas q2Canvas;
	public static bool q2SSButton;
	public static bool q2MCButton;
	public static bool q2BCButton;
	public static bool q2PIButton;
	public static bool q2PBButton;
	public static bool q2PicButton;

	GameObject q3Sign;
	private Canvas q3Canvas;
	public static bool q3IDButton;
	public static bool q3ChangeButton;
	public static bool q3UIButton;
	public static bool q3VIButton;

	GameObject q4Sign;
	private Canvas q4Canvas;
	public static bool q4true;
	public static bool q4false;

	GameObject q5Sign;
	private Canvas q5Canvas;
	public static bool q5IDButton;
	public static bool q5SSButton;
	public static bool q5MinButton;
	public static bool q5AllButton;

	GameObject q6Sign;
	private Canvas q6Canvas;
	public static bool q6SpendButton;
	public static bool q6DebtButton;
	public static bool q6BorrowButton;
	public static bool q6CHButton;
	public static bool q6AllButton;

	GameObject q7Sign;
	private Canvas q7Canvas;
	public static bool q7LawyerButton;
	public static bool q7DocsButton;
	public static bool q7BothButton;

	GameObject q8Sign;
	private Canvas q8Canvas;
	public static bool q8SimpleButton;
	public static bool q8SSButton;
	public static bool q8StatesButton;
	public static bool q8ChangeButton;

	private Canvas resultsCanvas;
	private Canvas reviewCanvas;
	public GameObject qNumHeader;
	private Text headerText;
	public GameObject questionBox;
	private Text questionText;
	public GameObject scoreBoard;
	private Text quizScore;

	int score;
	static int questionNum;

	Color color;
	Color green = new Color(90,70,10);


	// Use this for initialization
	void Start () {

		// Fetch the player object (to fetch its animatior for movement transitions)
		player = GameObject.FindGameObjectsWithTag ("Player");

		// Fetch the player's animator
		playerAnimatior = player [0].GetComponent<Animator> ();
		
		// initializations for Start Sign
		startSign = GameObject.Find("squareSignStart");
		startCanvas = GameObject.Find ("StartCanvas").GetComponent<Canvas> ();
		startCanvas.enabled = true;

		// initializatin for Q1 Sign
		q1Canvas = GameObject.Find ("Q1Canvas").GetComponent<Canvas> ();
		q1Sign = GameObject.Find ("squareSignQ1");
		q1Canvas.enabled = false;
		q1O1Pressed = false;
		q1O2Pressed = false;

		// initializatin for Q2 Sign
		q2Canvas = GameObject.Find ("Q2Canvas").GetComponent<Canvas> ();
		q2Sign = GameObject.Find ("squareSignQ2");
		q2Canvas.enabled = false;
		q2SSButton = false;
		q2MCButton = false;
		q2BCButton = false;
		q2PIButton = false;
		q2PBButton = false;
		q2PicButton = false;

		// initializatin for Q3 Sign
		q3Canvas = GameObject.Find ("Q3Canvas").GetComponent<Canvas> ();
		q3Sign = GameObject.Find ("squareSignQ3");
		q3Canvas.enabled = false;
		q3IDButton = false;
		q3ChangeButton = false;
		q3UIButton = false;
		q3VIButton = false;

		// initializatin for Q4 Sign
		q4Canvas = GameObject.Find ("Q4Canvas").GetComponent<Canvas> ();
		q4Sign = GameObject.Find ("squareSignQ4");
		q4Canvas.enabled = false;
		q4true = false;
		q4false = false;

		// initializatin for Q5 Sign
		q5Canvas = GameObject.Find ("Q5Canvas").GetComponent<Canvas> ();
		q5Sign = GameObject.Find ("squareSignQ5");
		q5Canvas.enabled = false;
		q5IDButton = false;
		q5SSButton = false;
		q5MinButton = false;
		q5AllButton = false;

		// initializatin for Q6
		q6Canvas = GameObject.Find ("Q6Canvas").GetComponent<Canvas> ();
		q6Sign = GameObject.Find ("squareSignQ6");
		q6Canvas.enabled = false;
		q6SpendButton = false;
		q6DebtButton = false;
		q6BorrowButton = false;
		q6CHButton = false;
		q6AllButton = false;

		// initializatin for Q7
		q7Canvas = GameObject.Find ("Q7Canvas").GetComponent<Canvas> ();
		q7Sign = GameObject.Find ("squareSignQ7");
		q7Canvas.enabled = false;
		q7LawyerButton = false;
		q7DocsButton = false;
		q7BothButton = false;

		// initializatin for Q8
		q8Canvas = GameObject.Find ("Q8Canvas").GetComponent<Canvas> ();
		q8Sign = GameObject.Find ("squareSignQ8");
		q8Canvas.enabled = false;
		q8SimpleButton = false;
		q8SSButton = false;
		q8StatesButton = false;
		q8ChangeButton = false;

		// initializatin for results canvas  
		resultsCanvas = GameObject.Find ("ResultsCanvas").GetComponent<Canvas> ();
		reviewCanvas = GameObject.Find ("ReviewCanvas").GetComponent<Canvas> ();
		headerText = GameObject.Find("QuestionNumber").GetComponent<Text> ();
		questionText = GameObject.Find ("QuestionBox").GetComponent<Text> ();
		quizScore = GameObject.Find ("ScoreBox").GetComponent<Text> ();
		resultsCanvas.enabled = false;
		reviewCanvas.enabled = false;
		score = 0;
		questionNum = 0;
		
	}

	// if yes is pressed, proceed with the quiz
	public void yesButtonPressed(){
		startCanvas.enabled = false;
		q1Canvas.enabled = true;
		resultsCanvas.enabled = false;
		reviewCanvas.enabled = false;

		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q1");
	}

	// if no is pressed go back to Module 1 ---------------------------------------- //
	public void noButtonPressed(){
		startSign.SetActive(false);
		startCanvas.enabled = false;
		// go back to Module 1
	}

	// q1 first choice selected
	public void q1O1ButtonPressed(){
		q1O1Pressed = true;
		GameObject button = GameObject.Find ("Option1");
		button.GetComponent<Image> ().color = green;
	}

	// q2 second choice selected
	public void q1O2ButtonPressed(){
		q1O2Pressed = true;
		GameObject button = GameObject.Find ("Option2");
		button.GetComponent<Image> ().color = Color.green;
	}

	// hide canvas for q1 and show canvas for q2
	public void q1NextPressed(){
		q1Canvas.enabled = false;
		q2Canvas.enabled = true;
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q2");
	}

	public void q2SSButtonPressed(){
		q2SSButton = true;
		color = Color.green;
		GameObject button = GameObject.Find ("SSCButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q2MCButtonPressed(){
		q2MCButton = true;
		GameObject button = GameObject.Find ("MCButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q2BCButtonPressed(){
		q2BCButton = true;
		GameObject button = GameObject.Find ("BCButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q2PIButtonPressed(){
		q2PIButton = true;
		GameObject button = GameObject.Find ("POIButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q2PBButtonPressed(){
		q2PBButton = true;
		GameObject button = GameObject.Find ("POBButton");
		button.GetComponent<Image> ().color = Color.green;
	}
		
	public void q2PicButtonPressed(){
		q2PicButton = true;
		GameObject button = GameObject.Find ("PicsButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	// hide canvas for q2 and show canvas for q3
	public void q2NextPressed(){
		q2Canvas.enabled = false;
		q3Canvas.enabled = true;
		Debug.Log("q2 next pressed");
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q3");
	}

	public void q3IDButtonPressed(){
		q3IDButton = true;
		GameObject button = GameObject.Find ("IdentityButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q3ChangeButtonPressed(){
		q3ChangeButton = true;
		GameObject button = GameObject.Find ("ChangeButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q3UIButtonPressed(){
		q3UIButton = true;
		GameObject button = GameObject.Find ("UIButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q3VIButtonPressed(){
		q3VIButton = true;
		GameObject button = GameObject.Find ("VIButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	// hide canvas for q3 and show canvas for q4
	public void q3NextPressed(){
		q3Canvas.enabled = false;
		q4Canvas.enabled = true;
		Debug.Log("q3 next pressed");
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q4");
	}

	public void q4truePressed(){
		q4true = true;
		GameObject button = GameObject.Find ("TButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q4falsePressed(){
		q4false = true;
		GameObject button = GameObject.Find ("FButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	// hide canvas for q4 and show canvas for q5
	public void q4NextPressed(){
		q4Canvas.enabled = false;
		q5Canvas.enabled = true;
		Debug.Log("q4 next pressed");
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q5");
	}

	public void q5IDButtonPressed(){
		q5IDButton = true;
		GameObject button = GameObject.Find ("IDButton");
		button.GetComponent<Image> ().color = Color.green;
	}
		
	public void q5SSButtonPressed(){
		q5SSButton = true;
		GameObject button = GameObject.Find ("SSButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q5MinButtonPressed(){
		q5MinButton = true;
		GameObject button = GameObject.Find ("MinButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q5AllButtonPressed(){
		q5AllButton = true;GameObject 
		button = GameObject.Find ("AllButton");
		button.GetComponent<Image> ().color = Color.green;

	}

	// hide canvas for q5 and show canvas for q6
	public void q5NextPressed(){
		q5Canvas.enabled = false;
		q6Canvas.enabled = true;
		Debug.Log("q5 next pressed");
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q6");
	}

	public void q6SpendButtonPressed(){
		q6SpendButton = true;
		GameObject button = GameObject.Find ("SpendButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q6DebtButtonPressed(){
		q6DebtButton = true;
		GameObject button = GameObject.Find ("DebtButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q6BorrowButtonPressed(){
		q6BorrowButton = true;
		GameObject button = GameObject.Find ("BorrowButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q6CHButtonPressed(){
		q6CHButton = true;
		GameObject button = GameObject.Find ("HistoryButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	// hide canvas for q6 and show canvas for q7
	public void q6NextPressed(){
		q6Canvas.enabled = false;
		q7Canvas.enabled = true;
		Debug.Log("q6 next pressed");
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q7");
	}

	public void q7LawyerButtonPressed(){
		q7LawyerButton = true;
		GameObject button = GameObject.Find ("LawyerButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q7DocsButtonPressed(){
		q7DocsButton = true;
		GameObject button = GameObject.Find ("KeyButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q7BothButtonPressed(){
		q7BothButton = true;
		GameObject button = GameObject.Find ("BothButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	// hide canvas for q7 and show canvas for q8
	public void q7NextPressed(){
		q7Canvas.enabled = false;
		q8Canvas.enabled = true;
		Debug.Log("q7 next pressed");
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q8");
	}

	public void q8SimpleButtonPressed(){
		q8SimpleButton = true;
		GameObject button = GameObject.Find ("SimpleButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q8SSButtonPressed(){
		q8SSButton = true;
		GameObject button = GameObject.Find ("SSButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q8StatesButtonPressed(){
		q8StatesButton = true;
		GameObject button = GameObject.Find ("StateButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void q8ChangeButtonPressed(){
		q8ChangeButton = true;
		GameObject button = GameObject.Find ("OtherButton");
		button.GetComponent<Image> ().color = Color.green;
	}
		
	public void q8FinishPressed(){
		q8Canvas.enabled = false;
		int playerScore = calculateScore ();
		resultsCanvas.enabled = true;
		reviewCanvas.enabled = false;

		// Set Trigger
		playerAnimatior.SetTrigger ("To_Quiz_Results");

		quizScore.text = "You answered " + playerScore + " out of 18 questions correctly";
		GameObject button = GameObject.Find ("FinishedButton");
		button.GetComponent<Image> ().color = Color.green;
	}
		
	public int calculateScore(){
		// question 1
		if (q1O1Pressed == true) {
			score++;
		}
		if (q1O2Pressed == true) {
				score++;
		}
		// question 2
		if(q2SSButton == true){
			score++;
		}
		if(q2MCButton == true){
			score++;
		}
		if(q2BCButton == true){
			score++;
		}
		if(q2PIButton == true){
			score++;
		}
		if( q2PBButton == true){
			score++;
		}		
		if(q2PicButton == true){
			score++;
		}
		// question 3
		if(q3ChangeButton == true){
			score++;
		}
		if(q3UIButton == true){
			score++;
		}
		// question 4
		if (q4true == true) {
			score++;
		}
		// question 5
		if(q5AllButton == true){
			score++;
		}
		// question 6
		if(q6BorrowButton == true){
			score++;
		}
		if(q6CHButton == true){
			score++;
		}
		//question 7
		if(q7BothButton == true){
			score++;
		}
		//question 8
		if(q8SSButton == true){
			score++;
		}
		if(q8StatesButton == true){
			score++;
		}
		if(q8ChangeButton == true){
			score++;
		}
		Debug.Log ("Total score: " + score + "out of 18");
		return score;
	}

	public void reviewPressed(){
		resultsCanvas.enabled = false;
		reviewCanvas.enabled = true;
		questionNum++;
		showQuestion (questionNum);
		GameObject button = GameObject.Find ("ReviewButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	public void showQuestion(int qNum){
		Debug.Log ("Value of qNum: " + qNum);

		if (qNum == 1) {
			headerText.text = "Question 1";
			questionText.fontSize = 20;
			questionText.text = "Which of the following are true:" +
				"\n" +
				"\nAnswer: " +
				"\n\t * I can follow this course from the beginning " +
				"\n\t   through to the end" +
				"\n\t * I can pick and choose what I want to read and " +
				"\n\t   learn";
		}
		if (qNum == 2) {
			questionText.fontSize = 18;
			headerText.text = "Question 2";
			questionText.text = "What are some key documents you should get ahold of and keep safe as you work to regain your financial independence? Choose all that apply:" +
			"\n" +
			"\nAnswer: You need the following:" +
			"\n\t * Social security card, " +
			"\n\t * Copy of marriage certificate, " +
			"\n\t * Copy of birth certificates, " +
			"\n\t * Proof of insurance (medical, life, home, auto), " +
			"\n\t * Proof of any benefits received (disability, " +
			"\n\t   public assistance, retirement), " +
			"\n\t * and pictures of vaulable possessions in your " +
			"\n\t   home";
		}
		if (qNum == 3) {
			headerText.text = "Question 3";
			questionText.fontSize = 20;
			questionText.text = "What are some good ways to begin saving money as you are leaving an abusive relationship?" +
			"\n" +
			"\nAnswer: Save spare change from purchases and have any new or unexpected income (gifts, raises, bonuses) deposited into a new, secret bank account you open in your name";
		}
		if (qNum == 4) {
			headerText.text = "Question 4";
			questionText.text = "True or False: It is important to document the spending you may do with assets that have been kept in a joint account." +
				"\n" +
				"\nAnswer: True";
		}
		if (qNum == 5) {
			headerText.text = "Question 5";
			questionText.fontSize = 20;
			questionText.text = "What documents do you typically need to open a bank account at a bank branch office?" +
				"\n\tAnswer: All of the following:" +
				"\n\t * A valid ID, such as a drivers license" +
				"\n\t * A Social Security card" +
				"\n\t * Some minimum amount of money, which can " +
				"\n\t   vary from bank to bank (often a couple " +
				"\n\t   hundred of dollars, sometimes as little " +
				"\n\t   as $25";
		}
		if (qNum == 6) {
			headerText.text = "Question 6";
			questionText.fontSize = 20;
			questionText.text = "What are some of the reasons it's smart to have and use a credit card?" +
				"\n" +
				"\nAnswer: It's a good way for you to start showing that you can borrow money and pay it back reliably, and, it's a way to start establishing history.";
		}
		if (qNum == 7) {
			headerText.text = "Question 7";
			questionText.fontSize = 18;
			questionText.text = "What is a good first step if you want to find out about getting legally separated, divorced, or getting child support?" +
				"\n" +
				"\nAnswer: Both of the following:" +
				"\n\t * Go to a support agency and inquire about " +
				"\n\t   getting a lawyer" +
				"\n\t * Assemble some key documents, like an " +
				"\n\t   inventory of your possessions, some documentation " +
				"\n\t   of your living expenses, and evicence of your " +
				"\n\t   insurances (medical, auto, home, life)";
		}
		if (qNum == 8) {
			headerText.text = "Question 8";
			questionText.fontSize = 18;
			questionText.text = "Which of the following are true about changing your name to protect your identity?" +
				"\n" +
				"\nAnswer: The following are true:" +
				"\n\t * If you change your Social Security number, you may " +
				"\n\t   lose your credit history, educational " +
				"\n\t   accomplishments, and other information tied to your" +
				"\n\t   old identity" +
				"\n\t * Most states require some form of public disclosure of " +
				"\n\t   your identity" +
				"\n\t * If you don't want to change your identity (name " +
				"\n\t   and/or Social Security number) there are other ways " +
				"\n\t   to protect yourself and your privacy";
		}
		if (qNum == 9) {
			questionNum = 0;
			resultsCanvas.enabled = true;
			reviewCanvas.enabled = false;
		}
	}

	public void retakePressed(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		Vector3 movementVector = new Vector3 (19f,1.2f,34f);
		player [0].transform.position = movementVector;
		resultsCanvas.enabled = false;
		startCanvas.enabled = true;
		GameObject button = GameObject.Find ("RetakeButton");
		button.GetComponent<Image> ().color = Color.green;
	}

	// change scene 
	public void returnPressed(){
		GameObject button = GameObject.Find ("ReturnButton");
		button.GetComponent<Image> ().color = Color.green;
	}
} 
