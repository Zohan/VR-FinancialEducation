using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class StartHere : MonoBehaviour {

	private Canvas cardboardCanvas;
	private Canvas movementCanvas;
	private Canvas navigationCanvas;
	private Canvas newMovementCanvas;

	public GameObject navtextBox;
	private Text navigationText;
	public GameObject header;
	private Text headerText;
	public GameObject navButton;
	private Text navButtonText;

	public AudioClip footsteps;

	int counter;
	int forwardCounter;


	// Use this for initialization
	void Start () {
		cardboardCanvas = GameObject.Find ("Cardboard Canvas").GetComponent<Canvas> ();
		movementCanvas = GameObject.Find ("Movement Canvas").GetComponent<Canvas> ();
		navigationCanvas = GameObject.Find ("Course Navigation Canvas").GetComponent<Canvas> ();
		newMovementCanvas = GameObject.Find ("Movement Canvas 2").GetComponent<Canvas> ();
		cardboardCanvas.enabled = true;
		movementCanvas.enabled = false;
		navigationCanvas.enabled = false;
		headerText = header.GetComponent<Text> ();
		navigationText = navtextBox.GetComponent<Text> ();
		navButtonText = navButton.GetComponent<Text> ();
		counter = 0;
		forwardCounter = 0;
	}

	public void donePressed(){
		cardboardCanvas.enabled = false;
		movementCanvas.enabled = true;

	}

	public void forwardButtonPressed(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (0.2f, 0, 4.25f);
		player [0].transform.Translate (movementVector);

		AudioSource sound = GetComponent<AudioSource>();
		sound.PlayOneShot(footsteps, 0.7F);


		forwardCounter++;
		if (forwardCounter == 1) {
			movementCanvas.enabled = false;
			navigationCanvas.enabled = true;
		} else {
			// transition into next scene
		}
	}

	public void buttonCount(){
		counter++;
		if (counter == 1) {
			nextPressed ();
		} else {
			navDonePressed ();
		}
	}

	public void nextPressed(){
		headerText.text = "Navigating through the Material";
		navigationText.text = "You can access the course two ways:" +
			"\n\t\t * Move from the first topic in order" +
			"\n\t\t   through to the last. The topics start" +
			"\n\t\t   more basic and become more " +
			"\n\t\t   advanced as you continue." +
			"\n\t\t * Or pick and choose which topics you" +
			"\n\t\t   want to learn, when you want to learn " +
			"\n\t\t   them.";
		navButtonText.text = "Done";
	}

	public void navDonePressed(){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] camera = GameObject.FindGameObjectsWithTag ("MainCamera");
		Vector3 movementVector = new Vector3 (0.2f, 0, 3.25f);
		player [0].transform.Translate (movementVector);
		navigationCanvas.enabled = false;
		newMovementCanvas.enabled = true;
	}
}
