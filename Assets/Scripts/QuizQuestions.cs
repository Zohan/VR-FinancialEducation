using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class QuizQuestions : MonoBehaviour {

	//string url = "www.surveygizmo.com/s3/3701259/Keeping-Safe-and-Starting-Over";

	private Canvas startCanvas;
	private Canvas movement1Canvas;
	private Canvas q1PromptCanvas;
	private Canvas q1Canvas;
	public static bool q1O1Pressed;
	public static bool q1O2Pressed;

	private Canvas movement2Canvas;
	private Canvas q2PromptCanvas;
	private Canvas q2Canvas;
	public static bool q2SSButton;
	public static bool q2MCButton;
	public static bool q2BCButton;
	public static bool q2PIButton;
	public static bool q2PBButton;
	public static bool q2PicButton;

	private Canvas movement3Canvas;
	private Canvas q3PromptCanvas;
	private Canvas q3Canvas;
	public static bool q3IDButton;
	public static bool q3ChangeButton;
	public static bool q3UIButton;
	public static bool q3VIButton;

	private Canvas movement4Canvas;
	private Canvas q4PromptCanvas;
	private Canvas q4Canvas;
	public static bool q4true;
	public static bool q4false;

	private Canvas movement5Canvas;
	private Canvas q5PromptCanvas;
	private Canvas q5Canvas;
	public static bool q5IDButton;
	public static bool q5SSButton;
	public static bool q5MinButton;
	public static bool q5AllButton;

	private Canvas movement6Canvas;
	private Canvas q6PromptCanvas;
	private Canvas q6Canvas;
	public static bool q6SpendButton;
	public static bool q6DebtButton;
	public static bool q6BorrowButton;
	public static bool q6CHButton;
	public static bool q6AllButton;

	private Canvas movement7Canvas;
	private Canvas q7PromptCanvas;
	private Canvas q7Canvas;
	public static bool q7LawyerButton;
	public static bool q7DocsButton;
	public static bool q7BothButton;

	private Canvas movement8Canvas;
	private Canvas q8PromptCanvas;
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
	int questionNum;

	Color color;
	Color green = new Color(90,70,10);


	// Use this for initialization
	void Start () {
		startCanvas = GameObject.Find ("Start").GetComponent<Canvas> ();
		// initializatin for Q1
		movement1Canvas = GameObject.Find ("MoveToQ1").GetComponent<Canvas> ();
		q1PromptCanvas = GameObject.Find ("Question1").GetComponent<Canvas> ();
		q1Canvas = GameObject.Find ("Q1").GetComponent<Canvas> ();
		movement1Canvas.enabled = false;
		q1PromptCanvas.enabled = false;
		q1Canvas.enabled = false;
		q1O1Pressed = false;
		q1O2Pressed = false;

		// initializatin for Q2
		movement2Canvas = GameObject.Find ("MoveToQ2").GetComponent<Canvas> ();
		q2PromptCanvas = GameObject.Find ("Question2").GetComponent<Canvas> ();
		q2Canvas = GameObject.Find ("Q2").GetComponent<Canvas> ();
		movement2Canvas.enabled = false;
		q2PromptCanvas.enabled = false;
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
		q3Canvas = GameObject.Find ("Q3").GetComponent<Canvas> ();
		movement3Canvas.enabled = false;
		q3PromptCanvas.enabled = false;
		q3Canvas.enabled = false;
		q3IDButton = false;
		q3ChangeButton = false;
		q3UIButton = false;
		q3VIButton = false;

		// initializatin for Q4
		movement4Canvas = GameObject.Find ("MoveToQ4").GetComponent<Canvas> ();
		q4PromptCanvas = GameObject.Find ("Question4").GetComponent<Canvas> ();
		q4Canvas = GameObject.Find ("Q4").GetComponent<Canvas> ();
		movement4Canvas.enabled = false;
		q4PromptCanvas.enabled = false;
		q4Canvas.enabled = false;
		q4true = false;
		q4false = false;

		// initializatin for Q5
		movement5Canvas = GameObject.Find ("MoveToQ5").GetComponent<Canvas> ();
		q5PromptCanvas = GameObject.Find ("Question5").GetComponent<Canvas> ();
		q5Canvas = GameObject.Find ("Q5").GetComponent<Canvas> ();
		movement5Canvas.enabled = false;
		q5PromptCanvas.enabled = false;
		q5Canvas.enabled = false;
		q5IDButton = false;
		q5SSButton = false;
		q5MinButton = false;
		q5AllButton = false;

		// initializatin for Q6
		movement6Canvas = GameObject.Find ("MoveToQ6").GetComponent<Canvas> ();
		q6PromptCanvas = GameObject.Find ("Question6").GetComponent<Canvas> ();
		q6Canvas = GameObject.Find ("Q6").GetComponent<Canvas> ();
		movement6Canvas.enabled = false;
		q6PromptCanvas.enabled = false;
		q6Canvas.enabled = false;
		q6SpendButton = false;
		q6DebtButton = false;
		q6BorrowButton = false;
		q6CHButton = false;
		q6AllButton = false;

		// initializatin for Q7
		movement7Canvas = GameObject.Find ("MoveToQ7").GetComponent<Canvas> ();
		q7PromptCanvas = GameObject.Find ("Question7").GetComponent<Canvas> ();
		q7Canvas = GameObject.Find ("Q7").GetComponent<Canvas> ();
		movement7Canvas.enabled = false;
		q7PromptCanvas.enabled = false;
		q7Canvas.enabled = false;
		q7LawyerButton = false;
		q7DocsButton = false;
		q7BothButton = false;

		// initializatin for Q8
		movement8Canvas = GameObject.Find ("MoveToQ8").GetComponent<Canvas> ();
		q8PromptCanvas = GameObject.Find ("Question8").GetComponent<Canvas> ();
		q8Canvas = GameObject.Find ("Q8").GetComponent<Canvas> ();
		movement8Canvas.enabled = false;
		q8PromptCanvas.enabled = false;
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
		startCanvas.enabled = false;
		movement1Canvas.enabled = true;
		resultsCanvas.enabled = false;
		reviewCanvas.enabled = false;

	}

	public void noButtonPressed(){
		startCanvas.enabled = false;
	}

	public void forwardToQ1(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (-0.3f, 0, 4.25f);
		player [0].transform.Translate (movementVector);
		q1PromptCanvas.enabled = true;
		q1Canvas.enabled = false;
		movement1Canvas.enabled = false;
	}
		
	public void showQ1(){
		q1PromptCanvas.enabled = false;
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
	}

	public void showQ7(){
		q7PromptCanvas.enabled = false;
		q7Canvas.enabled = true;
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
		quizScore.text = "You answered " + playerScore + " out of 8 questions correctly";
	}

	public int calculateScore(){
		// question 1
		if (q1O1Pressed == true && q1O2Pressed == true) {
			score++;
			Debug.Log ("Q1 correct");
		}
		// question 2
		if(q2SSButton == true && q2MCButton == true && q2BCButton == true && q2PIButton == true && q2PBButton == true){
			score++;
			Debug.Log ("Q2 correct");
		}
		// question 3
		if(q3ChangeButton == true && q3UIButton == true){
			score++;
			Debug.Log ("Q3 correct");
		}
		// question 4
		if (q4true == true) {
			score++;
			Debug.Log ("Q4 correct");
		}
		// question 5
		if(q5AllButton == true){
			score++;
			Debug.Log ("Q5 correct");
		}
		// question 6
		if(q6BorrowButton == true && q6CHButton == true){
			score++;
			Debug.Log ("Q6 correct");
		}
		//question 7
		if(q7BothButton == true){
			score++;
			Debug.Log ("Q7 correct");
		}
		//question 8
		if(q8SSButton == true && q8StatesButton == true && q8ChangeButton == true){
			score++;
			Debug.Log ("Q8 correct");
		}
		Debug.Log ("Total score: " + score);
		return score;
	}

	public void reviewPressed(){
		resultsCanvas.enabled = false;
		reviewCanvas.enabled = true;
		questionNum++;
		showQuestion (questionNum);
	
	}

	public void showQuestion(int qNum){
		Debug.Log ("Value of qNum: " + qNum);

		if (qNum == 1) {
			headerText.text = "Question 1";
			questionText.text = "Which of the following are true:" +
				"\n \t\t Answer: I can follow this course from the beginning through to the end" +
				"\n \t\t\t and" +
				"\n \t\t\t I can pick and choose what I want to read and learn";
		}
		if (qNum == 2) {
			headerText.text = "Question 2";
			questionText.text = "What are some key documents you should get ahold of and keep safe as you work to regain your financial independence? Choose all that apply:" +
			"\n\t\t Answer: Social security card, " +
			"\n\t\t copy of marriage certificate, " +
			"\n\t\t copy of birth certificates, " +
			"\n\t\t proof of insurance (medical, life, home, auto), " +
			"\n\t\t proof of any benefits received (disability, public assistance, retirement), " +
			"\n\t\t and pictures of vaulable possessions in your home";
		}
	}




	public void retakePressed(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (19f,1.2f,34f);
		player [0].transform.position = movementVector;
		resultsCanvas.enabled = false;
		startCanvas.enabled = true;
	
	}

	// change scene 
	/*public void returnPressed(){

	}*/
} 
