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

	private Canvas movement2Canvas;
	private Canvas q2PromptCanvas;
	private Canvas q2Canvas;

	private Canvas movement3Canvas;
	private Canvas q3PromptCanvas;
	private Canvas q3Canvas;

	private Canvas movement4Canvas;
	private Canvas q4PromptCanvas;
	private Canvas q4Canvas;

	private Canvas movement5Canvas;
	private Canvas q5PromptCanvas;
	private Canvas q5Canvas;

	private Canvas movement6Canvas;
	private Canvas q6PromptCanvas;
	private Canvas q6Canvas;

	private Canvas movement7Canvas;
	private Canvas q7PromptCanvas;
	private Canvas q7Canvas;

	private Canvas movement8Canvas;
	private Canvas q8PromptCanvas;
	private Canvas q8Canvas;

	/*private Canvas endMovementCanvas;*/

	//int qNumber;
	//int score;


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

		// initializatin for Q2
		movement2Canvas = GameObject.Find ("MoveToQ2").GetComponent<Canvas> ();
		q2PromptCanvas = GameObject.Find ("Question2").GetComponent<Canvas> ();
		q2Canvas = GameObject.Find ("Q2").GetComponent<Canvas> ();
		movement2Canvas.enabled = false;
		q2PromptCanvas.enabled = false;
		q2Canvas.enabled = false;

		// initializatin for Q3
		movement3Canvas = GameObject.Find ("MoveToQ3").GetComponent<Canvas> ();
		q3PromptCanvas = GameObject.Find ("Question3").GetComponent<Canvas> ();
		q3Canvas = GameObject.Find ("Q3").GetComponent<Canvas> ();
		movement3Canvas.enabled = false;
		q3PromptCanvas.enabled = false;
		q3Canvas.enabled = false;
		// initializatin for Q4
		movement4Canvas = GameObject.Find ("MoveToQ4").GetComponent<Canvas> ();
		q4PromptCanvas = GameObject.Find ("Question4").GetComponent<Canvas> ();
		q4Canvas = GameObject.Find ("Q4").GetComponent<Canvas> ();
		movement4Canvas.enabled = false;
		q4PromptCanvas.enabled = false;
		q4Canvas.enabled = false;

		// initializatin for Q5
		movement5Canvas = GameObject.Find ("MoveToQ5").GetComponent<Canvas> ();
		q5PromptCanvas = GameObject.Find ("Question5").GetComponent<Canvas> ();
		q5Canvas = GameObject.Find ("Q5").GetComponent<Canvas> ();
		movement5Canvas.enabled = false;
		q5PromptCanvas.enabled = false;
		q5Canvas.enabled = false;

		// initializatin for Q6
		movement6Canvas = GameObject.Find ("MoveToQ6").GetComponent<Canvas> ();
		q6PromptCanvas = GameObject.Find ("Question6").GetComponent<Canvas> ();
		q6Canvas = GameObject.Find ("Q6").GetComponent<Canvas> ();
		movement6Canvas.enabled = false;
		q6PromptCanvas.enabled = false;
		q6Canvas.enabled = false;

		// initializatin for Q7
		movement7Canvas = GameObject.Find ("MoveToQ7").GetComponent<Canvas> ();
		q7PromptCanvas = GameObject.Find ("Question7").GetComponent<Canvas> ();
		q7Canvas = GameObject.Find ("Q7").GetComponent<Canvas> ();
		movement7Canvas.enabled = false;
		q7PromptCanvas.enabled = false;
		q7Canvas.enabled = false;

		// initializatin for Q8
		movement8Canvas = GameObject.Find ("MoveToQ8").GetComponent<Canvas> ();
		q8PromptCanvas = GameObject.Find ("Question8").GetComponent<Canvas> ();
		q8Canvas = GameObject.Find ("Q8").GetComponent<Canvas> ();
		movement8Canvas.enabled = false;
		q8PromptCanvas.enabled = false;
		q8Canvas.enabled = false;
		// initializatin for final canvas  
		/*endMovementCanvas = GameObject.Find ("MoveToEnd").GetComponent<Canvas> ();
		endMovementCanvas.enabled = false;*/
	
		//qNumber = 0;
		//score = 0;
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void yesButtonPressed(){
		startCanvas.enabled = false;
		movement1Canvas.enabled = true;

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

	public void backwardButtonPressed(){

	}
		
	public void showQ1(){
		//qNumber  = 1;
		q1PromptCanvas.enabled = false;
		q1Canvas.enabled = true;
	}

	public void q1NextPressed(){
		q1Canvas.enabled = false;
		movement2Canvas.enabled = true;
	}

	public void forwardToQ2(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		//Vector3 movementVector = new Vector3 (-0.3f, 0, 4.25f);
		Vector3 movementVector = new Vector3 (-0.3f, 0, 3f);
		player [0].transform.Translate (movementVector);
		q2PromptCanvas.enabled = true;
		movement2Canvas.enabled = false;  
	}

	public void showQ2(){
		q2PromptCanvas.enabled = false;
		q2Canvas.enabled = true;

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


} 
