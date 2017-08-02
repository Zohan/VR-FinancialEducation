using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class QuizQuestions : MonoBehaviour {

	public string MyText = "Prompt";
	public GameObject header;
	private Text text;

	private Canvas startCanvas;
	private Canvas movementCanvas;


	// Use this for initialization
	void Start () {
		Text text = header.GetComponent<Text> ();
		//text.text = "READY?";
		startCanvas = GameObject.Find ("Start").GetComponent<Canvas> ();
		movementCanvas = GameObject.Find ("Move").GetComponent<Canvas> ();
		hideMoveArrows ();
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void yesButtonPressed(){
		Text text = header.GetComponent<Text> ();
		text.text = "Yes";
		startCanvas = GameObject.Find ("Start").GetComponent<Canvas> ();
		startCanvas.GetComponent<Canvas> ().enabled = false;
		showMoveArrows ();

	}

	public void noButtonPressed(){
		Text text = header.GetComponent<Text> ();
		text.text = "No";
		//startCanvas = GameObject.Find ("Start").GetComponent<Canvas> ();
		startCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void forwardButtonPressed(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 direction = new Vector3 (-0.40f, 0, 4.5f);
		player [0].transform.Translate (direction);
	}

	public void backwardButtonPressed(){

	}

	public void showMoveArrows(){
		movementCanvas.GetComponent<Canvas> ().enabled = true;
	}

	public void hideMoveArrows(){
		movementCanvas.GetComponent<Canvas> ().enabled = false;
	}

	public void goToQuestionOne(){

	}
}
