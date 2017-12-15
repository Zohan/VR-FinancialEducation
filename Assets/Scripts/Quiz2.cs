using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Quiz2 : MonoBehaviour {

	// The player object will be used to fetch its animatior for movement transitions
	private GameObject[] player;

	// Variable to hold the player's animatior
	private Animator playerAnimatior;

	//GameObject startSign;
	private Canvas startCanvas;
	public static bool yesPressed;
	public static bool noPressed;

	//GameObject q1Sign;
	private Canvas q1Canvas;
	private Canvas tvCanvas;
	private Canvas movieCanvas;
	private Canvas carCanvas;
	private Canvas heatCanvas;
	private Canvas videoGamesCanvas;
	private Canvas candyCanvas;
	private Canvas foodCanvas;
	private Canvas shelterCanvas;
	private Canvas coffeeCanvas;

//	public static int tv;
//	public static int movie;
//	public static int car;
//	public static int heat;
//	public static int videoGames;
//	public static int candy;
//	public static int food;
//	public static int shelter;
//	public static int coffee;
	public static bool tvWantsButtonPressed;
	public static bool tvNeedsButtonPressed;
	public static bool movieWantsButtonPressed;
	public static bool movieNeedsButtonPressed;
	public static bool carWantsButtonPressed;
	public static bool carNeedsButtonPressed;
	public static bool heatWantsButtonPressed;
	public static bool heatNeedsButtonPressed;
	public static bool videoGamesWantsButtonPressed;
	public static bool videoGamesNeedsButtonPressed;
	public static bool candyWantsButtonPressed;
	public static bool candyNeedsButtonPressed;
	public static bool foodWantsButtonPressed;
	public static bool foodNeedsButtonPressed;
	public static bool shelterWantsButtonPressed;
	public static bool shelterNeedsButtonPressed;
	public static bool coffeeWantsButtonPressed;
	public static bool coffeeNeedsButtonPressed;

	static int q1Count;

	//GameObject q2Sign;
	private Canvas q2Canvas;
	public static bool self;
	public static bool friend;
	public static bool musician;
	public static bool celebrity;

	//GameObject q3Sign;
	private Canvas q3Canvas;
	public static bool truePressed;
	public static bool falsePressed;

	//GameObject q4Sign;
	private Canvas q4Canvas;
	public static bool monthlyBillsPressed;
	public static bool isMonthlyBillsStep1;
	public static bool outOfPocketPressed;
	public static bool isOutOfPocketStep2;
	public static bool reviewNumbersPressed;
	public static bool isReviewNumbersStep3;
	public static bool reviewBigTicketsPressed;
	public static bool isReviewBigTicketsStep4;
	public static bool createPlanPressed;
	public static bool isCreatePlanStep5;
	static int q4Count;

	//GameObject q5Sign;
	private Canvas q5Canvas;
	public static bool location;
	public static bool logo;
	public static bool products;
	public static bool fees;
	public static bool online;
	public static bool friends;
	public static bool reputation;

	//GameObject q6Sign;
	private Canvas q6Canvas;
	public static bool bank;
	public static bool creditUnion;
	public static bool lender;
	public static bool check;

	// For results and review canvas
	private Canvas resultsCanvas;
	private Canvas reviewCanvas;
	public GameObject qNumHeader;
	private Text headerText;
	public GameObject questionBox;
	private Text questionText;
	public GameObject scoreBoard;
	private Text quizScore;
	int score;
	double score_percentage;
	static int questionNum;

	// Button colors
	Color green = new Color(90,70,10); // selected color
	Color unselected_color;
	private ColorBlock next_button_colors;

	// Color next_button_color = new Color(30, 200, 224);
	// Color next_button_hihglight_color = new Color(167, 203, 208);

	// Use this for initialization
	void Start () {

		// Fetch the player object (to fetch its animatior for movement transitions)
		player = GameObject.FindGameObjectsWithTag ("Player");

		// Fetch the player's animator
		playerAnimatior = player [0].GetComponent<Animator> ();

		// initializatin for start sign
		startCanvas = GameObject.Find ("StartCanvas").GetComponent<Canvas> ();
		startCanvas.enabled = true;

		// initialization for question 1
		q1Canvas = GameObject.Find ("Q1").GetComponent<Canvas> ();
		tvCanvas = GameObject.Find ("TVCanvas").GetComponent<Canvas> ();
		movieCanvas = GameObject.Find ("MovieCanvas").GetComponent<Canvas> ();
		carCanvas = GameObject.Find ("CarCanvas").GetComponent<Canvas> ();
		heatCanvas = GameObject.Find ("HeatCanvas").GetComponent<Canvas> ();
		videoGamesCanvas = GameObject.Find ("VideoGameCanvas").GetComponent<Canvas> ();
		candyCanvas = GameObject.Find ("CandyCanvas").GetComponent<Canvas> ();
		foodCanvas = GameObject.Find ("FoodCanvas").GetComponent<Canvas> ();
		shelterCanvas = GameObject.Find ("ShelterCanvas").GetComponent<Canvas> ();
		coffeeCanvas = GameObject.Find ("CoffeeCanvas").GetComponent<Canvas> ();

		q1Canvas.enabled = false;
		tvCanvas.enabled = false;
		movieCanvas.enabled = false;
		carCanvas.enabled = false;
		heatCanvas.enabled = false;
		videoGamesCanvas.enabled = false;
		candyCanvas.enabled = false;
		foodCanvas.enabled = false;
		shelterCanvas.enabled = false;
		coffeeCanvas.enabled = false;

		tvWantsButtonPressed = false;
		tvNeedsButtonPressed = false;
		movieWantsButtonPressed = false;
		movieNeedsButtonPressed = false;
		carWantsButtonPressed = false;
		carNeedsButtonPressed = false;
		heatWantsButtonPressed = false;
		heatNeedsButtonPressed = false;
		videoGamesWantsButtonPressed = false;
		videoGamesNeedsButtonPressed = false;
		candyWantsButtonPressed = false;
		candyNeedsButtonPressed = false;
		foodWantsButtonPressed = false;
		foodNeedsButtonPressed = false;
		shelterWantsButtonPressed = false;
		shelterNeedsButtonPressed = false;
		coffeeWantsButtonPressed = false;
		coffeeNeedsButtonPressed = false;
//		tv = -1;
//		movie = -1;
//		car = -1;
//		heat = -1;
//		videoGames = -1;
//		candy = -1;
//		food = -1;
//		shelter = -1;
//		coffee = -1;
		q1Count = 0;

		// initialization for question 2
		q2Canvas = GameObject.Find ("Q2").GetComponent<Canvas> ();
		q2Canvas.enabled = false;

		self = false;
		friend = false;
		musician = false;
		celebrity = false;

		//initializaiton for question 3
		q3Canvas = GameObject.Find ("Q3").GetComponent<Canvas> ();
		q3Canvas.enabled = false;

		truePressed = false;
		falsePressed = false;

		// initializaiton for quesiton 4
		q4Canvas = GameObject.Find ("Q4").GetComponent<Canvas> ();
		q4Canvas.enabled = false;

		monthlyBillsPressed = false;
		isMonthlyBillsStep1 = false;
		outOfPocketPressed = false;
		isOutOfPocketStep2 = false;
		reviewNumbersPressed = false;
		isReviewNumbersStep3 = false;
		reviewBigTicketsPressed = false;
		isReviewBigTicketsStep4 = false;
		createPlanPressed = false;
		isCreatePlanStep5 = false;
		q4Count = 0;

		// initialization for question 5
		q5Canvas = GameObject.Find ("Q5").GetComponent<Canvas> ();
		q5Canvas.enabled = false;

		location = false;
		logo = false;
		products = false;
		fees = false;
		online = false;
		friends = false;
		reputation = false;

		// initializaiton for question 6
		q6Canvas = GameObject.Find ("Q6").GetComponent<Canvas> ();
		q6Canvas.enabled = false;

		bank = false;
		creditUnion = false;
		lender = false;
		check = false;

		// initializaiton for results and review
		resultsCanvas = GameObject.Find ("Results").GetComponent<Canvas> ();
		reviewCanvas = GameObject.Find ("Review").GetComponent<Canvas> ();
		resultsCanvas.enabled = false;
		reviewCanvas.enabled = false;
		headerText = GameObject.Find("QuestionNumber").GetComponent<Text> ();
		questionText = GameObject.Find ("QuestionBox").GetComponent<Text> ();
		quizScore = GameObject.Find ("ScoreBox").GetComponent<Text> ();
		score = 0;
		questionNum = 0;
		//score_percentage = 0;

		// Initialize Colors for Q1 Next button
		GameObject button = GameObject.Find ("YesButton");
		next_button_colors = button.GetComponent<Button>().colors;

		// Initialize Colors for Unselected Choices
		button = GameObject.Find ("TVNeedsButton1");
		unselected_color = button.GetComponent<Image> ().color;
	}

	/************************* START CANVAS FUNCTIONS *************************/
	// if yes pressed continue to question 1
	public void yesButtonPressed(){
		startCanvas.enabled = false;
		q1Canvas.enabled = true;
		tvCanvas.enabled = true;
		//player.transform.position = new Vector3(21,1,32);
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q1");
	}
		
	/************************* QUESTION 1 FUNCTIONS *************************/

	public void tvWantPressed(){ 
		GameObject button = GameObject.Find ("TVWantButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			tvWantsButtonPressed = true; //correct answer
			button.GetComponent<Image> ().color = Color.green;
		} else {
			tvWantsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void tvNeedsPressed(){
		GameObject button = GameObject.Find ("TVNeedsButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			tvNeedsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			tvNeedsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void movieWantPressed(){ 
		GameObject button = GameObject.Find ("MovieWantButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			movieWantsButtonPressed = true; //correct answer
			button.GetComponent<Image> ().color = Color.green;
		} else {
			movieWantsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void movieNeedsPressed(){
		GameObject button = GameObject.Find ("MovieNeedsButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			movieNeedsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			movieNeedsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void carWantPressed(){
		GameObject button = GameObject.Find ("CarWantButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			carWantsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			carWantsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void carNeedsPressed(){ 
		GameObject button = GameObject.Find ("CarNeedsButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			carNeedsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			carNeedsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void heatWantPressed(){
		GameObject button = GameObject.Find ("HeatWantButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			heatWantsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			heatWantsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void heatNeedsPressed(){ //correct answer
		GameObject button = GameObject.Find ("HeatNeedsButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			heatNeedsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			heatNeedsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void videoGamesWantPressed(){ //correct answer
		GameObject button = GameObject.Find ("VideoGameWantButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			videoGamesWantsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			videoGamesWantsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void videoGamesNeedsPressed(){
		GameObject button = GameObject.Find ("VideoGameNeedsButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			videoGamesNeedsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			videoGamesNeedsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void candyWantPressed(){ //correct answer
		GameObject button = GameObject.Find ("CandyWantButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			candyWantsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			candyWantsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void candyNeedsPressed(){
		GameObject button = GameObject.Find ("CandyNeedsButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			candyNeedsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			candyNeedsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void foodWantPressed(){
		GameObject button = GameObject.Find ("FoodWantButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			foodWantsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			foodWantsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void foodNeedsPressed(){ //correct answer
		GameObject button = GameObject.Find ("FoodNeedsButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			foodNeedsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			foodNeedsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void shelterWantPressed(){
		GameObject button = GameObject.Find ("ShelterWantButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			shelterWantsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			shelterWantsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void shelterNeedsPressed(){ //correct answer
		GameObject button = GameObject.Find ("ShelterNeedsButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			shelterNeedsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			shelterNeedsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void coffeeWantPressed(){ //correct answer
		GameObject button = GameObject.Find ("CoffeeWantButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			coffeeWantsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			coffeeWantsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}
	public void coffeeNeedsPressed(){
		GameObject button = GameObject.Find ("CoffeeNeedsButton1");
		if (button.GetComponent<Image> ().color == unselected_color) {
			coffeeNeedsButtonPressed = true;
			button.GetComponent<Image> ().color = Color.green;
		} else {
			coffeeNeedsButtonPressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		}
	}

	public void q1NextPressed(){
		q1Count++;
		//Debug.Log("count: " + q1Count);
		if (q1Count == 1) {
			tvCanvas.enabled = false;
			movieCanvas.enabled = true;
		} else if (q1Count == 2) {
			movieCanvas.enabled = false;
			carCanvas.enabled = true;
		} else if (q1Count == 3) {
			carCanvas.enabled = false;
			heatCanvas.enabled = true;
		} else if (q1Count == 4) {
			heatCanvas.enabled = false;
			videoGamesCanvas.enabled = true;
		} else if (q1Count == 5) {
			videoGamesCanvas.enabled = false;
			candyCanvas.enabled = true;
		} else if (q1Count == 6) {
			candyCanvas.enabled = false;
			foodCanvas.enabled = true;
		} else if (q1Count == 7) {
			foodCanvas.enabled = false;
			shelterCanvas.enabled = true;
		} else if (q1Count == 8) {
			shelterCanvas.enabled = false;
			GameObject button = GameObject.Find ("Q1NextItemButton");
			button.GetComponentInChildren<Text>().text = "Next";
			button.GetComponent<Button>().colors = next_button_colors;
			coffeeCanvas.enabled = true;
		} else {
			q1Canvas.enabled = false;
			coffeeCanvas.enabled = false;
			q2Canvas.enabled = true;
			q1Count = 0;
			// Set Trigger
			playerAnimatior.SetTrigger ("To_Q2");
		}
	}

	/************************* QUESTION 2 FUNCTIONS *************************/
	public void selfPressed(){ 
		GameObject button = GameObject.Find ("SelfButton");
		if (self) {
			self = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			self = true;  //correct answer
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void friendPressed(){
		GameObject button = GameObject.Find ("FriendButton");
		if (friend) {
			friend = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			friend = true; 
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void musicianPressed(){
		GameObject button = GameObject.Find ("MusicianButton");
		if (musician) {
			musician = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			musician = true; 
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void celebrityPressed(){
		GameObject button = GameObject.Find ("CelebrityButton");
		if (celebrity) {
			celebrity = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			celebrity = true;
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void q2NextPressed(){
		q2Canvas.enabled = false;
		q3Canvas.enabled = true;
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q3");
	}

	/************************* QUESTION 3 FUNCTIONS *************************/
	public void trueButtonPressed(){
		GameObject button = GameObject.Find ("TrueButton");
		if (truePressed) {
			truePressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			truePressed = true;
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void falseButtonPressed(){
		GameObject button = GameObject.Find ("FalseButton");
		if (falsePressed) {
			falsePressed = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			falsePressed = true;  //correct answer
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void q3NextPressed(){
		q3Canvas.enabled = false;
		q4Canvas.enabled = true;
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q4");
	}

	/************************* QUESTION 4 FUNCTIONS *************************/

	public void monthlyBillsButtonPressed(){ 
		if (!monthlyBillsPressed) {
			GameObject button = GameObject.Find ("monthlyBillsButton");
			button.GetComponent<Image> ().color = Color.green;
			monthlyBillsPressed = true;
			q4Count++;
			button.GetComponentInChildren<Text>().text = q4Count + ". List your regular monthly bills";
			if (q4Count == 1) { isMonthlyBillsStep1 = true; }
		}
	}// EOF monthlyBillsButtonPressed
		
	public void outOfPocketButtonPressed(){
		if (!outOfPocketPressed) {
			GameObject button = GameObject.Find ("outOfPocketButton");
			button.GetComponent<Image> ().color = Color.green;
			outOfPocketPressed = true;
			q4Count++;
			button.GetComponentInChildren<Text>().text = q4Count + ". Track your out-of-pocket spending for a week";
			if (q4Count == 2) { isOutOfPocketStep2 = true; }
		}
	}// EOF outOfPocketButtonPressed
		
	public void reviewNumbersButtonPressed(){ //correct answer
		if (!reviewNumbersPressed) {
			GameObject button = GameObject.Find ("reviewNumbersButton");
			button.GetComponent<Image> ().color = Color.green;
			reviewNumbersPressed = true;
			q4Count++;
			button.GetComponentInChildren<Text>().text = q4Count + ". Review the numbers at the end of a week or month, and look for ways to start saving";
			if (q4Count == 3) { isReviewNumbersStep3 = true; }
		}
	}// EOF reviewNumbersButtonPressed
		
	public void reviewBigTicketsButtonPressed(){
		if (!reviewBigTicketsPressed) {
			GameObject button = GameObject.Find ("reviewBigTicketsButton");
			button.GetComponent<Image> ().color = Color.green;
			reviewBigTicketsPressed = true;
			q4Count++;
			button.GetComponentInChildren<Text>().text = q4Count + ". Review big-ticket expenses (to become aware of ways to prevent surprises that could lead to debt)";
			if (q4Count == 4) { isReviewBigTicketsStep4 = true; }
		}
	} // EOF reviewBigTicketsButtonPressed
		
	public void createPlanButtonPressed(){
		if (!createPlanPressed) {
			GameObject button = GameObject.Find ("createPlanButton");
			button.GetComponent<Image> ().color = Color.green;
			createPlanPressed = true;
			q4Count++;
			button.GetComponentInChildren<Text>().text = q4Count + ". Create a plan for ways to cut back on spending and what to do with extra money";
			if (q4Count == 5) { isCreatePlanStep5 = true; }
		}
	} // EOF createPlanButtonPressed
		
	// If reset is pressed
	public void q4ResetPressed(){
		// Reset counter
		q4Count = 0;

		// Reset monthlyBillsButton text and color
		GameObject button = GameObject.Find ("monthlyBillsButton");
		button.GetComponentInChildren<Text>().text = "List your regular monthly bills" ;
		button.GetComponent<Image> ().color = unselected_color;
		monthlyBillsPressed = false;
		isMonthlyBillsStep1 = false;

		// Reset outOfPocketButton text and color
		button = GameObject.Find ("outOfPocketButton");
		button.GetComponentInChildren<Text>().text = "Track your out-of-pocket spending for a week" ;
		button.GetComponent<Image> ().color = unselected_color;
		outOfPocketPressed = false;
		isOutOfPocketStep2 = false;

		// Reset reviewNumbersButton text and color
		button = GameObject.Find ("reviewNumbersButton");
		button.GetComponentInChildren<Text>().text = "Review the numbers at the end of a week or month, and look for ways to start saving" ;
		button.GetComponent<Image> ().color = unselected_color;
		reviewNumbersPressed = false;
		isReviewNumbersStep3 = false;

		// Reset reviewBigTicketsButton text and color
		button = GameObject.Find ("reviewBigTicketsButton");
		button.GetComponentInChildren<Text>().text = "Review big-ticket expenses (to become aware of ways to prevent surprises that could lead to debt)" ;
		button.GetComponent<Image> ().color = unselected_color;
		reviewBigTicketsPressed = false;
		isReviewBigTicketsStep4 = false;

		// Reset createPlanButton text and color
		button = GameObject.Find ("createPlanButton");
		button.GetComponentInChildren<Text>().text = "Create a plan for ways to cut back on spending and what to do with extra money" ;
		button.GetComponent<Image> ().color = unselected_color;
		createPlanPressed = false;
		isCreatePlanStep5 = false;
	
	}//EOF q4ResetPressed

	public void q4NextPressed(){
		q4Canvas.enabled = false;
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q5");
		q5Canvas.enabled = true;
	}

	/************************* QUESTION 5 FUNCTIONS *************************/

	public void locationPressed(){
		GameObject button = GameObject.Find ("LocationButton");
		if (location) {
			location = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			location = true;  //correct answer
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void logoPressed(){
		GameObject button = GameObject.Find ("LogoButton");
		if (logo) {
			logo = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			logo = true;
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void productsPressed(){
		GameObject button = GameObject.Find ("ProductsButton");
		if (products) {
			products = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			products = true;  //correct answer
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void feesPressed(){
		GameObject button = GameObject.Find ("FeesButton");
		if (fees) {
			fees = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			fees = true;  //correct answer
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void onlinePressed(){
		GameObject button = GameObject.Find ("OnlineButton");
		if (online) {
			online = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			online = true;  //correct answer
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void friendsPressed(){
		GameObject button = GameObject.Find ("FriendsButton");
		if (friends) {
			friends = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			friends = true;
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void reputationPressed(){ // Changed from 'famous' to 'reputation' to include all the factors in the video
		GameObject button = GameObject.Find ("ReputationButton");
		if (reputation) {
			reputation = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			reputation = true; //correct answer
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void q5NextPressed(){
		q5Canvas.enabled = false;
		q6Canvas.enabled = true;
		// Set Trigger
		playerAnimatior.SetTrigger ("To_Q6");
	}

	/************************* QUESTION 6 FUNCTIONS *************************/

	public void bankPressed(){
		GameObject button = GameObject.Find ("BankButton");
		if (bank) {
			bank = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			bank = true;
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void creditUnionPressed(){
		GameObject button = GameObject.Find ("CreditButton");
		if (creditUnion) {
			creditUnion = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			creditUnion = true; //correct answer
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void lenderPressed(){
		GameObject button = GameObject.Find ("PaydayButton");
		if (lender) {
			lender = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			lender = true;
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void checkPressed(){
		GameObject button = GameObject.Find ("CheckButton");
		if (check) {
			check = false;
			button.GetComponent<Image> ().color = unselected_color;
		} else {
			check = true;
			button.GetComponent<Image> ().color = Color.green;
		}
	}

	public void q6FinishPressed(){

		// Prep score text box
		int playerScore = calculateScore ();
		score_percentage = ( (double)playerScore / 18 ) * 100 ;
		if ( (score_percentage % 1) == 0 ) {
			//Debug.Log ("int Score: " + System.Math.Round(score_percentage,0));
			score_percentage = System.Math.Round (score_percentage, 0);
		} else {
			//Debug.Log ("float Score: " + System.Math.Round(score_percentage,1));
			score_percentage = System.Math.Round (score_percentage, 1);
		}
		quizScore.text = "Score: " + playerScore + " / 18 (" + score_percentage + "%)";

		q6Canvas.enabled = false;
		resultsCanvas.enabled = true;
		reviewCanvas.enabled = false;

		// Set Trigger
		playerAnimatior.SetTrigger ("To_Results");
	}

	/************************* RESULTS CANVAS FUNCTIONS *************************/


	/************************* REVIEW CANVAS FUNCTIONS *************************/

	public int calculateScore(){

		// question 1 ========================================= //
		if (tvWantsButtonPressed) {
			score++;
		}
		if (movieWantsButtonPressed) {
			score++;
		}
		if (carNeedsButtonPressed) {
			score++;
		}
		if (heatNeedsButtonPressed) {
			score++;
		}
		if (videoGamesWantsButtonPressed) {
			score++;
		}
		if (candyWantsButtonPressed) {
			score++;
		}
		if (foodNeedsButtonPressed) {
			score++;
		}
		if (shelterNeedsButtonPressed) {
			score++;
		}
		if (coffeeWantsButtonPressed) {
			score++;
		}
			
		// question 2 ========================================= //
		if(self == true){
			score++;
		}
	
		// question 3 ========================================= //
		if(falsePressed == true){
			score++;
		}

		// question 4 ========================================= //
		if(isMonthlyBillsStep1 && isOutOfPocketStep2 && isReviewNumbersStep3 && isReviewBigTicketsStep4 && isCreatePlanStep5)
		{score++;}

		// question 5 ========================================= //
		if (location) {
			score++;
		}
		if (products) {
			score++;
		}
		if (fees) {
			score++;
		}
		if (online) {
			score++;
		}
		if (reputation) {
			score++;
		}
			
		// question 6 ========================================= //
		if (creditUnion) {
			score++;
		}

		Debug.Log ("Total score: " + score + "out of 18");
		return score;

	} // EOF calculateScore()

	public void reviewPressed(){
		resultsCanvas.enabled = false;
		reviewCanvas.enabled = true;
		questionNum++;
		showQuestion (questionNum);
		//GameObject button = GameObject.Find ("ReviewButton");
		//button.GetComponent<Image> ().color = Color.green;
	}

	public void reviewNextPressed(){
		questionNum++;
		showQuestion (questionNum);
	}

	public void showQuestion(int qNum){
		Debug.Log ("Value of qNum: " + qNum);

		if (qNum == 1) {
			headerText.text = "Question 1";
			questionText.fontSize = 20;
			questionText.text = "Select a category (need vs. want) for each item." +
				"\n" +
				"\nAnswer: " +
				"\n\t * Needs: Car and gas, heat and utilities, healthy food," +
				"\n\t   and shelter." +
				"\n\t * Wants: A new TV, movie tickets, a new video game," + 
				"\n\t   candy bars, and fancy coffee.";
		}
		if (qNum == 2) {
			questionText.fontSize = 20;
			headerText.text = "Question 2";
			questionText.text = "Sometimes you feel like buying something you know you don't need, but you just want to have it in the present moment. At times like this, who is it probably most useful to think of?" +
				"\n" +
				"\nAnswer: Your future self.";
		}
		if (qNum == 3) {
			headerText.text = "Question 3";
			questionText.fontSize = 20;
			questionText.text = "True or false: Collecting Social Security based on a spouse or former spouse's earnings will reduce the amount that spouse receives." +
				"\n" +
				"\nAnswer: False.";
		}
		if (qNum == 4) {
			headerText.text = "Question 4";
			questionText.fontSize = 18;
			questionText.text = "Select the following activities in order to show how you can track your spending." +
				"\nAnswer: " +
				"\n\t Step 1: List your regular monthly bills." +
				"\n\t Step 2: Track your out-of-pocket spending for a week." +
				"\n\t Step 3: Review the numbers at the end of a week or" +
				"\n\t         month, and look for ways to start saving." +
				"\n\t Step 4: Review big-ticket expenses (to become aware" +
				"\n\t         of ways to prevent surprises that could lead to debt)." +
				"\n\t Step 5: Create a plan for ways to cut back on spending" +
				"\n\t         and what to do with extra money.";
			
		}
		if (qNum == 5) {
			headerText.text = "Question 5";
			questionText.fontSize = 18;
			questionText.text = "What are some things to consider when you choose a bank?" +
				"\n" +
				"\n\tAnswer: All of the following:" +
				"\n\t * Do the products and services match with your needs" +
				"\n\t   (kinds of checking and savings accounts, and even" +
				"\n\t   investment options)?" +
				"\n\t * Number of locations (both branches and ATMs)" +
				"\n\t * What are the costs and fees associated with their" +
				"\n\t   accounts?" +
				"\n\t * The quality of the online and mobile banking options" +
				"\n\t * The bank's reputation among customers";
		}
		if (qNum == 6) {
			headerText.text = "Question 6";
			questionText.fontSize = 20;
			questionText.text = "Which of the following is the only banking organization that is owned by its members (the people who use it)?" +
				"\n" +
				"\nAnswer: A credit union.";
		}
		if (qNum == 7) {
			questionNum = 0;
			resultsCanvas.enabled = true;
			reviewCanvas.enabled = false;
		}
	} // EOF showQuestion()
		
} // EOF public class Quiz2 : MonoBehaviour ...