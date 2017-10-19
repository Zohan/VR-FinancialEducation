using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class QuizQuestions : MonoBehaviour {

	//string url = "www.surveygizmo.com/s3/3701259/Keeping-Safe-and-Starting-Over";

	//private Canvas startCanvas;
	GameObject startBook;
	private Canvas startCanvas;
	private Canvas movement1Canvas;
	private Canvas q1PromptCanvas;
	GameObject book1;
	private Canvas q1Canvas;
	public static bool q1O1Pressed;
	public static bool q1O2Pressed;

	private Canvas movement2Canvas;
	private Canvas q2PromptCanvas;
	GameObject book2;
	private Canvas q2Canvas;
	public static bool q2SSButton;
	public static bool q2MCButton;
	public static bool q2BCButton;
	public static bool q2PIButton;
	public static bool q2PBButton;
	public static bool q2PicButton;

	private Canvas movement3Canvas;
	private Canvas q3PromptCanvas;
	GameObject book3;
	private Canvas q3Canvas;
	public static bool q3IDButton;
	public static bool q3ChangeButton;
	public static bool q3UIButton;
	public static bool q3VIButton;

	private Canvas movement4Canvas;
	private Canvas q4PromptCanvas;
	GameObject book4;
	private Canvas q4Canvas;
	public static bool q4true;
	public static bool q4false;

	private Canvas movement5Canvas;
	private Canvas q5PromptCanvas;
	GameObject book5;
	private Canvas q5Canvas;
	public static bool q5IDButton;
	public static bool q5SSButton;
	public static bool q5MinButton;
	public static bool q5AllButton;

	private Canvas movement6Canvas;
	private Canvas q6PromptCanvas;
	GameObject book6;
	private Canvas q6Canvas;
	public static bool q6SpendButton;
	public static bool q6DebtButton;
	public static bool q6BorrowButton;
	public static bool q6CHButton;
	public static bool q6AllButton;

	private Canvas movement7Canvas;
	private Canvas q7PromptCanvas;
	GameObject book7;
	private Canvas q7Canvas;
	public static bool q7LawyerButton;
	public static bool q7DocsButton;
	public static bool q7BothButton;

	private Canvas movement8Canvas;
	private Canvas q8PromptCanvas;
	GameObject book8;
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
		startBook = GameObject.Find("BookStart");
		startCanvas = GameObject.Find ("StartCanvas").GetComponent<Canvas> ();
		startBook.SetActive (true);
		startCanvas.enabled = true;
		// initializatin for Q1
		movement1Canvas = GameObject.Find ("MoveToQ1").GetComponent<Canvas> ();
		q1PromptCanvas = GameObject.Find ("Question1").GetComponent<Canvas> ();
		q1Canvas = GameObject.Find ("Q1Canvas").GetComponent<Canvas> ();
		book1 = GameObject.Find ("Book1");
		movement1Canvas.enabled = false;
		q1PromptCanvas.enabled = false;
		book1.SetActive (false);
		q1Canvas.enabled = false;
		q1O1Pressed = false;
		q1O2Pressed = false;

		// initializatin for Q2
		movement2Canvas = GameObject.Find ("MoveToQ2").GetComponent<Canvas> ();
		q2PromptCanvas = GameObject.Find ("Question2").GetComponent<Canvas> ();
		q2Canvas = GameObject.Find ("Q2Canvas").GetComponent<Canvas> ();
		book2 = GameObject.Find ("Book2");
		movement2Canvas.enabled = false;
		q2PromptCanvas.enabled = false;
		book2.SetActive (false);
		q2Canvas.enabled = false;
		q2SSButton = false;
		q2MCButton = false;
		q2BCButton = false;
		q2PIButton = false;
		q2PBButton = false;
		q2PicButton = false;

		// initializatin for Q3
		movement3Canvas = GameObject.Find ("MoveToQ3").GetComponent<Canvas> ();
		q3PromptCanvas = GameObject.Find ("Question3").GetComponent<Canvas> ();
		q3Canvas = GameObject.Find ("Q3Canvas").GetComponent<Canvas> ();
		book3 = GameObject.Find ("Book3");
		movement3Canvas.enabled = false;
		q3PromptCanvas.enabled = false;
		book3.SetActive (false);
		q3Canvas.enabled = false;
		q3IDButton = false;
		q3ChangeButton = false;
		q3UIButton = false;
		q3VIButton = false;

		// initializatin for Q4
		movement4Canvas = GameObject.Find ("MoveToQ4").GetComponent<Canvas> ();
		q4PromptCanvas = GameObject.Find ("Question4").GetComponent<Canvas> ();
		q4Canvas = GameObject.Find ("Q4Canvas").GetComponent<Canvas> ();
		book4 = GameObject.Find ("Book4");
		movement4Canvas.enabled = false;
		q4PromptCanvas.enabled = false;
		book4.SetActive (false);
		q4Canvas.enabled = false;
		q4true = false;
		q4false = false;

		// initializatin for Q5
		movement5Canvas = GameObject.Find ("MoveToQ5").GetComponent<Canvas> ();
		q5PromptCanvas = GameObject.Find ("Question5").GetComponent<Canvas> ();
		q5Canvas = GameObject.Find ("Q5Canvas").GetComponent<Canvas> ();
		book5 = GameObject.Find ("Book5");
		movement5Canvas.enabled = false;
		q5PromptCanvas.enabled = false;
		book5.SetActive (false);
		q5Canvas.enabled = false;
		q5IDButton = false;
		q5SSButton = false;
		q5MinButton = false;
		q5AllButton = false;

		// initializatin for Q6
		movement6Canvas = GameObject.Find ("MoveToQ6").GetComponent<Canvas> ();
		q6PromptCanvas = GameObject.Find ("Question6").GetComponent<Canvas> ();
		q6Canvas = GameObject.Find ("Q6Canvas").GetComponent<Canvas> ();
		book6 = GameObject.Find ("Book6");
		movement6Canvas.enabled = false;
		q6PromptCanvas.enabled = false;
		book6.SetActive (false);
		q6Canvas.enabled = false;
		q6SpendButton = false;
		q6DebtButton = false;
		q6BorrowButton = false;
		q6CHButton = false;
		q6AllButton = false;

		// initializatin for Q7
		movement7Canvas = GameObject.Find ("MoveToQ7").GetComponent<Canvas> ();
		q7PromptCanvas = GameObject.Find ("Question7").GetComponent<Canvas> ();
		q7Canvas = GameObject.Find ("Q7Canvas").GetComponent<Canvas> ();
		book7 = GameObject.Find ("Book7");
		movement7Canvas.enabled = false;
		q7PromptCanvas.enabled = false;
		book7.SetActive (false);
		q7Canvas.enabled = false;
		q7LawyerButton = false;
		q7DocsButton = false;
		q7BothButton = false;

		// initializatin for Q8
		movement8Canvas = GameObject.Find ("MoveToQ8").GetComponent<Canvas> ();
		q8PromptCanvas = GameObject.Find ("Question8").GetComponent<Canvas> ();
		q8Canvas = GameObject.Find ("Q8Canvas").GetComponent<Canvas> ();
		book8 = GameObject.Find ("Book8");
		movement8Canvas.enabled = false;
		q8PromptCanvas.enabled = false;
		book8.SetActive (false);
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

	public void yesButtonPressed(){
		startBook.SetActive(false);
		startCanvas.enabled = false;
		movement1Canvas.enabled = true;
		resultsCanvas.enabled = false;
		reviewCanvas.enabled = false;

	}

	public void noButtonPressed(){
		startBook.SetActive(false);
		startCanvas.enabled = false;
	}

	public void forwardToQ1(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (-0.3f, 0, 4.25f);
		player [0].transform.Translate (movementVector);
		q1PromptCanvas.enabled = true;
		book1.SetActive (false);
		q1Canvas.enabled = false;
		movement1Canvas.enabled = false;
	}
		
	public void showQ1(){
		Debug.Log ("Made it");
		q1PromptCanvas.enabled = false;
		//book1.SetActive (true);
		q1Canvas.enabled = true;
	}

	public void q1O1ButtonPressed(){
		q1O1Pressed = true;
		GameObject button = GameObject.Find ("Option1");
		button.GetComponent<Image> ().color = green;
		//Debug.Log ("O1: " + q1O1Pressed);
	}

	public void q1O2ButtonPressed(){
		q1O2Pressed = true;
		GameObject button = GameObject.Find ("Option2");
		button.GetComponent<Image> ().color = Color.green;
		//Debug.Log ("O2: " + q1O2Pressed);
	}

	public void q1NextPressed(){
		q1Canvas.enabled = false;
		book1.SetActive (false);
		movement2Canvas.enabled = true;
	}

	public void forwardToQ2(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (-0.3f, 0, 3f);
		player [0].transform.Translate (movementVector);
		q2PromptCanvas.enabled = true;
		movement2Canvas.enabled = false;  
	}

	public void showQ2(){
		q2PromptCanvas.enabled = false;
		q2Canvas.enabled = true;
		book2.SetActive (true);
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

	public void q2NextPressed(){
		q2Canvas.enabled = false;
		book2.SetActive (false);
		movement3Canvas.enabled = true;
	}

	public void forwardToQ3(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (-0.3f, 0, 4.25f);
		player [0].transform.Translate (movementVector);
		q3PromptCanvas.enabled = true;
		movement3Canvas.enabled = false;  
	}

	public void showQ3(){
		q3PromptCanvas.enabled = false;
		q3Canvas.enabled = true;
		book3.SetActive (true);
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

	public void q3NextPressed(){
		q3Canvas.enabled = false;
		book3.SetActive (false);
		movement4Canvas.enabled = true;
	}

	public void forwardToQ4(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (3f, 0, 3f);
		player [0].transform.Translate (movementVector);
		movement4Canvas.enabled = false;  
		q4PromptCanvas.enabled = true;
	}

	public void showQ4(){
		q4Canvas.enabled = true;
		book4.SetActive (true);
		q4PromptCanvas.enabled = false;
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

	public void q4NextPressed(){
		q4Canvas.enabled = false;
		book4.SetActive (false);
		movement5Canvas.enabled = true;
	}

	public void forwardToQ5(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (2f, 0, .5f);
		player [0].transform.Translate (movementVector);
		movement5Canvas.enabled = false;  
		q5PromptCanvas.enabled = true;
	}

	public void showQ5(){
		q5PromptCanvas.enabled = false;
		q5Canvas.enabled = true;
		book5.SetActive (true);
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

	public void q5NextPressed(){
		q5Canvas.enabled = false;
		book5.SetActive (false);
		movement6Canvas.enabled = true;
	}

	public void forwardToQ6(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (3f, 0, 1f);
		player [0].transform.Translate (movementVector);
		movement6Canvas.enabled = false;  
		q6PromptCanvas.enabled = true;
	}

	public void showQ6(){
		q6PromptCanvas.enabled = false;
		q6Canvas.enabled = true;
		book6.SetActive (true);
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

	public void q6NextPressed(){
		q6Canvas.enabled = false;
		book6.SetActive (false);
		movement7Canvas.enabled = true;
	}

	public void forwardToQ7(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (3f, 0, -2f);
		player [0].transform.Translate (movementVector);
		movement7Canvas.enabled = false;  
		q7PromptCanvas.enabled = true;
		q7Canvas.enabled = false;
		book7.SetActive (false);
	}

	public void showQ7(){
		q7PromptCanvas.enabled = false;
		q7Canvas.enabled = true;
		book7.SetActive (true);
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

	public void q7NextPressed(){
		q7Canvas.enabled = false;
		book7.SetActive (false);
		movement8Canvas.enabled = true;
	}

	public void forwardToQ8(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (2f, 0, -3f);
		player [0].transform.Translate (movementVector);
		movement8Canvas.enabled = false;  
		q8PromptCanvas.enabled = true;
	}

	public void showQ8(){
		q8PromptCanvas.enabled = false;
		q8Canvas.enabled = true;
		book8.SetActive (true);
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
		book8.SetActive (false);
		int playerScore = calculateScore ();
		resultsCanvas.enabled = true;
		reviewCanvas.enabled = false;
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
		if(q2PicButton = true){
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
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (19f,1.2f,34f);
		player [0].transform.position = movementVector;
		resultsCanvas.enabled = false;
		//startCanvas.enabled = true;
		startBook.SetActive(true);
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
