using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Quiz2 : MonoBehaviour {

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

	public static int tv;
	public static int movie;
	public static int car;
	public static int heat;
	public static int videoGames;
	public static int candy;
	public static int food;
	public static int shelter;
	public static int coffee;

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


	//GameObject q5Sign;
	private Canvas q5Canvas;
	public static bool location;
	public static bool logo;
	public static bool products;
	public static bool fees;
	public static bool online;
	public static bool friends;
	public static bool famous;

	//GameObject q6Sign;
	private Canvas q6Canvas;
	public static bool bank;
	public static bool creditUnion;
	public static bool lender;
	public static bool check;

	private GameObject player;


	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

		// initializatin for start sign
		//startSign = GameObject.Find("squareSignStart");
		startCanvas = GameObject.Find ("StartCanvas").GetComponent<Canvas> ();
		startCanvas.enabled = true;

		// initialization for question 1
		//q1Sign = GameObject.Find("squareSignQ1");
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

		tv = 0;
		movie = 0;
		car = 0;
		heat = 0;
		videoGames = 0;
		candy = 0;
		food = 0;
		shelter = 0;
		coffee = 0;
		q1Count = 0;

		// initialization for question 2
		//q2Sign = GameObject.Find("squareSignQ2");
		q2Canvas = GameObject.Find ("Q2").GetComponent<Canvas> ();
		q2Canvas.enabled = false;

		//initializaiton for question 3
		//q3Sign = GameObject.Find("squareSignQ3");
		q3Canvas = GameObject.Find ("Q3").GetComponent<Canvas> ();
		q3Canvas.enabled = false;

		// initializaiton for quesiton 4
		//q4Sign = GameObject.Find("squareSignQ4");
		q4Canvas = GameObject.Find ("Q4").GetComponent<Canvas> ();
		q4Canvas.enabled = false;

		// initialization for question 5
		//q5Sign = GameObject.Find("squareSignQ5");
		q5Canvas = GameObject.Find ("Q5").GetComponent<Canvas> ();
		q5Canvas.enabled = false;

		location = false;
		logo = false;
		products = false;
		fees = false;
		online = false;
		friends = false;
		famous = false;

		// initializaiton for question 6
		//q6Sign = GameObject.Find("squareSignQ6");
		q6Canvas = GameObject.Find ("Q6").GetComponent<Canvas> ();
		q6Canvas.enabled = false;

		bank = false;
		creditUnion = false;
		lender = false;
		check = false;



	}
	/************************* START CANVAS FUNCTIONS *************************/
	// if yes pressed continue to question 1
	public void yesButtonPressed(){
		startCanvas.enabled = false;
		q1Canvas.enabled = true;
		tvCanvas.enabled = true;
		player.transform.position = new Vector3(21,1,32);
	}

	// if no pressed go back to module 2
	public void noButtonPressed(){

	}
	/************************* QUESTION 1 FUNCTIONS *************************/

	// wants = 0
	// needs = 1


	public void tvWantPressed(){
		tv = 0;
	}
	public void tvNeedsPressed(){
		tv = 1;
	}

	public void movieWantPressed(){
		movie = 0;
	}

	public void movieNeedsPressed(){
		movie = 1;
	}

	public void carWantPressed(){
		car = 0;
	}

	public void carNeedsPressed(){
		car = 1;
	}

	public void heatWantPressed(){
		heat = 0;
	}

	public void heatNeedsPressed(){
		heat = 1;
	}

	public void videoGamesWantPressed(){
		videoGames = 0;
	}

	public void videoGamesNeedsPressed(){
		videoGames = 1;
	}

	public void candyWantPressed(){
		candy = 0;
	}

	public void candyNeedsPressed(){
		candy = 1;
	}

	public void foodWantPressed(){
		food = 0;
	}

	public void foodNeedsPressed(){
		food = 1;
	}

	public void shelterWantPressed(){
		shelter = 0;
	}

	public void shelterNeedsPressed(){
		shelter = 1;
	}

	public void coffeeWantPressed(){
		tv = 0;
	}

	public void coffeeNeedsPressed(){
		tv = 1;
	}

	public void q1NextPressed(){
		q1Count++;
		Debug.Log("count: " + q1Count);
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
			coffeeCanvas.enabled = true;
		} else {
			q1Canvas.enabled = false;
			coffeeCanvas.enabled = false;
			q2Canvas.enabled = true;
			q1Count = 0;
		}
	}

	/************************* QUESTION 2 FUNCTIONS *************************/
	public void selfPressed(){
		self = true;
	}

	public void friendPressed(){
		friend = true;
	}

	public void musicianPressed(){
		musician = true;
	}

	public void celebrityPressed(){
		celebrity = true;
	}

	public void q2NextPressed(){
		q2Canvas.enabled = false;
		q3Canvas.enabled = true;
	}

	/************************* QUESTION 3 FUNCTIONS *************************/
	public void trueButtonPressed(){
		truePressed = true;
	}

	public void falseButtonPressed(){
		falsePressed = true;
	}

	public void q3NextPressed(){
		q3Canvas.enabled = false;
		q4Canvas.enabled = true;
	}

	/************************* QUESTION 4 FUNCTIONS *************************/
	public void q4NextPressed(){
		q4Canvas.enabled = false;
		q5Canvas.enabled = true;
	}

	/************************* QUESTION 5 FUNCTIONS *************************/

	public void locationPressed(){
		location = true;
	}
	public void logoPressed(){
		logo = true;
	}
	public void productsPressed(){
		products = true;
	}
	public void feesPressed(){
		fees = true;
	}
	public void onlinePressed(){
		online = true;
	}
	public void friendsPressed(){
		friends = true;
	}
	public void famousPressed(){
		famous = true;
	}

	public void q5NextPressed(){
		q5Canvas.enabled = false;
		q6Canvas.enabled = true;
	}

	/************************* QUESTION 6 FUNCTIONS *************************/

	public void bankPressed(){
		bank = true;
	}
	public void creditUnionPressed(){
		creditUnion = true;
	}
	public void lenderPressed(){
		lender = true;
	}
	public void checkPressed(){
		check = true;
	}

	public void q6FinishPressed(){
		q6Canvas.enabled = false;
	}

	/************************* RESULTS CANVAS FUNCTIONS *************************/


	/************************* REVIEW CANVAS FUNCTIONS *************************/
}
