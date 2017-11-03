﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mod1Script : MonoBehaviour {

	// The player object will be used to fetch its animatior for movement transitions
	private GameObject[] player;

	// Variable to hold the player's animatior
	private Animator playerAnimatior;

	// First canvas will introduce Module 1
	private Canvas Mod1_Intro_Canvas;

	// Mod1 Menu Canvas - here the player can select to go to one of the four sections
	private Canvas Mod1_Menu_Canvas;

	/*--------------------------------------------------------------------------------------------------------
		SP Menu Canvas - here the player can navigate to one of the three Safety Planning (SP) steps or the
		Mod1 menu
	--------------------------------------------------------------------------------------------------------*/
	private Canvas SP_Menu_Canvas;

	// SP_Step1 Canvas - here the player can read about Step 1 of the SP topic, continue to Part A of Step 1, 
	// or go back to the SP Menu
	private Canvas SP_Step1_Canvas;

	// SP_Step1_A Canvas - here the player can read about Part A of Step 1 of the SP topic or continue to Part B
	private Canvas SP_Step1_A_Canvas;

	// SP_Step1_B Canvas - here the player can read about Part B of Step 1 of the SP topic or continue to Part C 
	private Canvas SP_Step1_B_Canvas;

	// SP_Step1_C Canvas - here the player can read about Part C of Step 1 of the SP topic, continue to Step 2, or
	// go back to Part B of Step 1
	private Canvas SP_Step1_C_Canvas;

	// SP_Step2 Canvas - here the player can read about Step 2 of the SP topic, continue to Part A of Step 2, or
	// go back to the SP Menu
	private Canvas SP_Step2_Canvas;

	// SP_Step2_A Canvas - here the player can read Part A of Step 2 of the SP topic, continue to Part B of Step 2, or
	// go back to the primary Step 2 canvas
	private Canvas SP_Step2_A_Canvas;

	// SP_Step2_B Canvas - here the player can start reading Part B of Step 2 of the SP topic, 
	// continue to Part B.2 of Step 2, or go back to Part A of Step 2
	private Canvas SP_Step2_B_Canvas;

	// SP_Step2_B_2 Canvas - here the player can read Part B.2 of Step 2 of the SP topic, 
	// continue to Step 3, go back to Part B of Step 2, or go back to the SP Menu
	private Canvas SP_Step2_B_2_Canvas;

	// SP_Step3 Canvas - here the player can start reading about step 3 of the SP topic, 
	// continue to Part A of step 3, or go back to the SP menu
	private Canvas SP_Step3_Canvas;

	// SP_Step3_A Canvas - here the player can read Part A of step 3, 
	// continue to Part B of step 3, or go back to the start of step 3 
	private Canvas SP_Step3_A_Canvas;

	// SP_Step3_B Canvas - here the player can read Part B of step 3, 
	// continue to Part B.2 of step 3, or go back to Part A of step 3
	private Canvas SP_Step3_B_Canvas;

	// SP_Step3_B_2 Canvas - here the player can read Part B.2 of step 3, 
	// continue to Part B.3 of step 3, or go back to Part B of step 3
	private Canvas SP_Step3_B_2_Canvas;

	// SP_Step3_B_3 Canvas - here the player can read Part B.3 of step 3, 
	// continue to the Mod1 Menu, or go back to Part B.2 of step 3
	private Canvas SP_Step3_B_3_Canvas;

	/*--------------------------------------------------------------------------------------------------------
		SDCS Canvas - here the player can read about the Separation, Divorce, and Child Support (SDCS) topic, 
		continue to Part 1 of 3 of this topic, or go back to the Mod1 Menu
	--------------------------------------------------------------------------------------------------------*/
	private Canvas SDCS_Canvas;

	// SDCS_1 Canvas - here the player can read Part 1 of 3 of the SDCS topic, continue to Part 2, or 
	// go back to SDCS canvas 
	private Canvas SDCS_1_Canvas;

	// SDCS_2 Canvas - here the player can read Part 2 of 3 of the SDCS topic, continue to Part 3, or 
	// go back to Part 1 
	private Canvas SDCS_2_Canvas;

	// SDCS_3 Canvas - here the player can read Part 3 of 3 of the SDCS topic, continue to the Mod1 Menu, 
	// or go back to Part 2
	private Canvas SDCS_3_Canvas;

	/*--------------------------------------------------------------------------------------------------------
		PCIC Canvas - here the player can read about the Privacy Challenges and Identity Change (PCIC) topic, 
		continue to Myth #1 from "MYTHS & REALITIES OF IDENTITY CHANGE", or go back to the Mod1 Menu
	--------------------------------------------------------------------------------------------------------*/
	private Canvas PCIC_Canvas;

	// PCIC_1 Canvas - here the player can read Myth #1, continue to Myth #2, or go back to the PCIC Canvas
	private Canvas PCIC_1_Canvas;

	// PCIC_2 Canvas - here the player can read Myth #2, continue to Myth #3, or go back to Myth #1 
	private Canvas PCIC_2_Canvas;

	// PCIC_3 Canvas - here the player can read Myth #3, continue to Myth #4, or go back to Myth #2 
	private Canvas PCIC_3_Canvas;

	// PCIC_4 Canvas - here the player can read Myth #4, continue to Myth #5, or go back to Myth #3 
	private Canvas PCIC_4_Canvas;

	// PCIC_5 Canvas - here the player can read Myth #5, continue to Myth #6, or go back to Myth #4 
	private Canvas PCIC_5_Canvas;

	// PCIC_6 Canvas - here the player can read Myth #6, continue to Myth #7, or go back to Myth #5 
	private Canvas PCIC_6_Canvas;

	// PCIC_7 Canvas - here the player can read Myth #7, go back to the Mod1 Menu, or go back to Myth #6 
	private Canvas PCIC_7_Canvas;

	// Quiz Canvas - here the player can go to the Quiz Scene or continue to the Mod1 Menu
	private Canvas Quiz_Canvas;

	//-----------------------//

	//public GameObject stepOneHeader;
	//private Text stepOneHeaderText;
	//public GameObject stepOneBody;
	//private Text stepOneBodyText;
	//public GameObject s2Button;
	//private Text s2ButtonText;

	// Use this for initialization ---------//
	void Start () {

		// Fetch the player object (to fetch its animatior for movement transitions)
		player = GameObject.FindGameObjectsWithTag ("Player");

		// Fetch the player's animator
		playerAnimatior = player [0].GetComponent<Animator> ();

		// Canvases that are 'enabled = true' are visible
		// Otherwise they are not visible 'enabled = false'

		Mod1_Intro_Canvas = GameObject.Find ("Mod1_Intro_Canvas").GetComponent<Canvas> ();
		//Mod1_Intro_Canvas.enabled = true;

		Mod1_Menu_Canvas = GameObject.Find ("Mod1_Menu_Canvas").GetComponent<Canvas> ();
		Mod1_Menu_Canvas.enabled = false; // hide

		// SP canvases ---------------------------------------------------------

		SP_Menu_Canvas = GameObject.Find ("SP_Menu_Canvas").GetComponent<Canvas> ();
		SP_Menu_Canvas.enabled = false; // hide

		// SP Step 1 ----- //

		SP_Step1_Canvas = GameObject.Find ("SP_Step1_Canvas").GetComponent<Canvas> ();
		SP_Step1_Canvas.enabled = false; // hide
		 
		SP_Step1_A_Canvas = GameObject.Find ("SP_Step1_A_Canvas").GetComponent<Canvas> ();
		SP_Step1_A_Canvas.enabled = false; // hide
	
		SP_Step1_B_Canvas = GameObject.Find ("SP_Step1_B_Canvas").GetComponent<Canvas> ();
		SP_Step1_B_Canvas.enabled = false; // hide

		SP_Step1_C_Canvas = GameObject.Find ("SP_Step1_C_Canvas").GetComponent<Canvas> ();
		SP_Step1_C_Canvas.enabled = false; // hide

		// SP Step 2 ----- //

		SP_Step2_Canvas = GameObject.Find ("SP_Step2_Canvas").GetComponent<Canvas> ();
		SP_Step2_Canvas.enabled = false; // hide

		SP_Step2_A_Canvas = GameObject.Find ("SP_Step2_A_Canvas").GetComponent<Canvas> ();
		SP_Step2_A_Canvas.enabled = false; // hide

		SP_Step2_B_Canvas = GameObject.Find ("SP_Step2_B_Canvas").GetComponent<Canvas> ();
		SP_Step2_B_Canvas.enabled = false; // hide

		SP_Step2_B_2_Canvas = GameObject.Find ("SP_Step2_B_2_Canvas").GetComponent<Canvas> ();
		SP_Step2_B_2_Canvas.enabled = false; // hide

		// SP Step 3 ----- //

		SP_Step3_Canvas = GameObject.Find ("SP_Step3_Canvas").GetComponent<Canvas> ();
		SP_Step3_Canvas.enabled = false; // hide

		SP_Step3_A_Canvas = GameObject.Find ("SP_Step3_A_Canvas").GetComponent<Canvas> ();
		SP_Step3_A_Canvas.enabled = false; // hide
		  
		SP_Step3_B_Canvas = GameObject.Find ("SP_Step3_B_Canvas").GetComponent<Canvas> ();
		SP_Step3_B_Canvas.enabled = false; // hide

		SP_Step3_B_2_Canvas = GameObject.Find ("SP_Step3_B_2_Canvas").GetComponent<Canvas> ();
		SP_Step3_B_2_Canvas.enabled = false; // hide

		SP_Step3_B_3_Canvas = GameObject.Find ("SP_Step3_B_3_Canvas").GetComponent<Canvas> ();
		SP_Step3_B_3_Canvas.enabled = false; // hide

		// SDCS canvases ---------------------------------------------------------

		SDCS_Canvas = GameObject.Find ("SDCS_Canvas").GetComponent<Canvas> ();
		SDCS_Canvas.enabled = false; // hide

		SDCS_1_Canvas = GameObject.Find ("SDCS_1_Canvas").GetComponent<Canvas> ();
		SDCS_1_Canvas.enabled = false; // hide

		SDCS_2_Canvas = GameObject.Find ("SDCS_2_Canvas").GetComponent<Canvas> ();
		SDCS_2_Canvas.enabled = false; // hide

		SDCS_3_Canvas = GameObject.Find ("SDCS_3_Canvas").GetComponent<Canvas> ();
		SDCS_3_Canvas.enabled = false; // hide

		// PCIC canvases ---------------------------------------------------------

		PCIC_Canvas = GameObject.Find ("PCIC_Canvas").GetComponent<Canvas> ();
		PCIC_Canvas.enabled = false; // hide

		PCIC_1_Canvas = GameObject.Find ("PCIC_1_Canvas").GetComponent<Canvas> ();
		PCIC_1_Canvas.enabled = false; // hide

		PCIC_2_Canvas = GameObject.Find ("PCIC_2_Canvas").GetComponent<Canvas> ();
		PCIC_2_Canvas.enabled = false; // hide

		PCIC_3_Canvas = GameObject.Find ("PCIC_3_Canvas").GetComponent<Canvas> ();
		PCIC_3_Canvas.enabled = false; // hide

		PCIC_4_Canvas = GameObject.Find ("PCIC_4_Canvas").GetComponent<Canvas> ();
		PCIC_4_Canvas.enabled = false; // hide

		PCIC_5_Canvas = GameObject.Find ("PCIC_5_Canvas").GetComponent<Canvas> ();
		PCIC_5_Canvas.enabled = false; // hide

		PCIC_6_Canvas = GameObject.Find ("PCIC_6_Canvas").GetComponent<Canvas> ();
		PCIC_6_Canvas.enabled = false; // hide

		PCIC_7_Canvas = GameObject.Find ("PCIC_7_Canvas").GetComponent<Canvas> ();
		PCIC_7_Canvas.enabled = false; // hide

		// Quiz canvas ---------------------------------------------------------

		Quiz_Canvas = GameObject.Find ("Quiz_Canvas").GetComponent<Canvas> ();
		Quiz_Canvas.enabled = false; // hide

		//--------------------------------------//
		//stepOneHeaderText = GameObject.Find ("S1CHeader").GetComponent<Text> ();
		//stepOneBodyText = GameObject.Find ("S1CBody").GetComponent<Text> ();

	
	} //EOF void Start


	// SETTING TRIGGERS FOR ANIMATIONS ---------------------------//

	// Mod1_Intro_Canvas Buttons---------------//

	// Continue Button
	public void Mod1_Intro_Button_Pressed(){

		// Hide current
		Mod1_Intro_Canvas.enabled = false;

		// Show
		Mod1_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_Mod1_Intro_Button");

	} // EOF Mod1_Intro_Button_Pressed
		
	// Mod1_Menu_Canvas Buttons------------------//

	// SP Button
	public void Mod1_Menu_SP_Button_Pressed(){

		// Hide current
		Mod1_Menu_Canvas.enabled = false;

		// Show
		SP_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_Mod1_Menu_SP_Button");

	} // EOF Mod1_Menu_SP_Button_Pressed

	// SDCS Button
	public void Mod1_Menu_SDCS_Button_Pressed(){

		// Hide current
		Mod1_Menu_Canvas.enabled = false;

		// Show
		SDCS_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_Mod1_Menu_SDCS_Button");

	} // EOF Mod1_Menu_SDCS_Button_Pressed

	// PCIC_Button
	public void Mod1_Menu_PCIC_Button_Pressed(){

		// Hide current
		Mod1_Menu_Canvas.enabled = false;

		// Show
		PCIC_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_Mod1_Menu_PCIC_Button");

	} // EOF Mod1_Menu_PCIC_Button_Pressed

	// Quiz_Button
	public void Mod1_Menu_Quiz_Button_Pressed(){

		// Hide current
		Mod1_Menu_Canvas.enabled = false;

		// Show
		Quiz_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_Mod1_Menu_Quiz_Button");

	} // EOF Mod1_Menu_Quiz_Button_Pressed

	// SP_Menu_Canvas Buttons---------------------//

	// Step1_Button
	public void SP_Menu_Step1_Button_Pressed(){

		// Hide current
		SP_Menu_Canvas.enabled = false;

		// Show
		SP_Step1_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Menu_Step1_Button");

	} // EOF SP_Menu_Step1_Button_Pressed

	// Step2_Button
	public void SP_Menu_Step2_Button_Pressed(){

		// Hide current
		SP_Menu_Canvas.enabled = false;

		// Show
		SP_Step2_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Menu_Step2_Button");

	} // EOF SP_Menu_Step2_Button_Pressed

	// Step3_Button
	public void SP_Menu_Step3_Button_Pressed(){

		// Hide current
		SP_Menu_Canvas.enabled = false;

		// Show
		SP_Step3_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Menu_Step3_Button");

	} // EOF SP_Menu_Step3_Button_Pressed

	// Mod1_Menu_Button
	public void SP_Menu_Mod1_Menu_Button_Pressed(){

		// Hide current
		SP_Menu_Canvas.enabled = false;

		// Show
		Mod1_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Menu_Mod1_Menu_Button");

	} // EOF SP_Menu_Mod1_Menu_Button_Pressed

	// SP_Step1_Canvas buttons---------------------//

	// SP_Menu_Button
	public void SP_Step1_SP_Menu_Button_Pressed(){

		// Hide current
		SP_Step1_Canvas.enabled = false;

		// Show
		SP_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Step1_SP_Menu_Button");

	} // EOF SP_Step1_SP_Menu_Button_Pressed

	// SP_Step1_C_Canvas buttons---------------------//

	// SP_Step2
	public void SP_Step1_C_SP_Step2_Button_Pressed(){

		// Hide current
		SP_Step1_C_Canvas.enabled = false;

		// Show
		SP_Step2_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Step1_C_SP_Step2_Button");

	} // EOF SP_Step1_C_SP_Step2_Button_Pressed

	// SP_Menu_Button 
	public void SP_Step1_C_SP_Menu_Button_Pressed(){

		// Hide current
		SP_Step1_C_Canvas.enabled = false;

		// Show
		SP_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Step1_C_SP_Menu_Button");

	} // EOF SP_Step1_C_SP_Menu_Button_Pressed
		
	// SP_Step2_Canvas buttons---------------------//

	// SP_Menu_Button
	public void SP_Step2_SP_Menu_Button_Pressed(){

		// Hide current
		SP_Step2_Canvas.enabled = false;

		// Show
		SP_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Step2_SP_Menu_Button");

	} // EOF SP_Step2_SP_Menu_Button_Pressed

	// SP_Step2_B_2_Canvas buttons---------------------//

	// SP_Menu_Button
	public void SP_Step2_B_2_SP_Menu_Button_Pressed(){

		// Hide current
		SP_Step2_B_2_Canvas.enabled = false;

		// Show
		SP_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Step2_B_2_SP_Menu_Button");

	} // EOF SP_Step2_B_2_SP_Menu_Button_Pressed
		
	// SP_Step3_Button
	public void SP_Step2_B_2_SP_Step3_Button_Pressed(){

		// Hide current
		SP_Step2_B_2_Canvas.enabled = false;

		// Show
		SP_Step3_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Step2_B_2_SP_Step3_Button");

	} // EOF SP_Step2_B_2_SP_Step3_Button_Pressed

	// SP_Step3_Canvas buttons---------------------//

	// SP_Menu_Button
	public void SP_Step3_SP_Menu_Button_Pressed(){

		// Hide current
		SP_Step3_Canvas.enabled = false;

		// Show
		SP_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Step3_SP_Menu_Button");

	} // EOF SP_Step3_SP_Menu_Button_Pressed

	// SP_Step3_B_3_Canvas buttons---------------------//

	// SP_Menu_Button 
	public void SP_Step3_B_3_SP_Menu_Button_Pressed(){

		// Hide current
		SP_Step3_B_3_Canvas.enabled = false;

		// Show
		SP_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Step3_B_3_SP_Menu_Button");

	} // EOF SP_Step3_B_3_SP_Menu_Button_Pressed

	// Mod1_Menu_Button 
	public void SP_Step3_B_3_Mod1_Menu_Button_Pressed(){

		// Hide current
		SP_Step3_B_3_Canvas.enabled = false;

		// Show
		Mod1_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SP_Step3_B_3_Mod1_Menu_Button");

	} // EOF SP_Step3_B_3_Mod1_Menu_Button_Pressed

	// SDCS_Canvas buttons---------------------//

	// Mod1_Menu_Button 
	public void SDCS_Mod1_Menu_Button_Pressed(){

		// Hide current
		SDCS_Canvas.enabled = false;

		// Show
		Mod1_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SDCS_Mod1_Menu_Button");

	} // EOF SDCS_Mod1_Menu_Button_Pressed

	// SDCS_3_Canvas buttons---------------------//

	// Mod1_Menu_Button 
	public void SDCS_3_Mod1_Menu_Button_Pressed(){

		// Hide current
		SDCS_3_Canvas.enabled = false;

		// Show
		Mod1_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_SDCS_3_Mod1_Menu_Button");

	} // EOF SDCS_3_Mod1_Menu_Button_Pressed

	// PCIC_Canvas buttons---------------------//

	// Mod1_Menu_Button 
	public void PCIC_Mod1_Menu_Button_Pressed(){

		// Hide current
		PCIC_Canvas.enabled = false;

		// Show
		Mod1_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_PCIC_Mod1_Menu_Button");

	} // EOF PCIC_Mod1_Menu_Button_Pressed

	// PCIC_7_Canvas buttons---------------------//

	// Mod1_Menu_Button 
	public void PCIC_7_Mod1_Menu_Button_Pressed(){

		// Hide current
		PCIC_7_Canvas.enabled = false;

		// Show
		Mod1_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_PCIC_7_Mod1_Menu_Button");

	} // EOF PCIC_7_Mod1_Menu_Button_Pressed

	// Quiz_Canvas buttons---------------------//

	// Mod1_Menu_Button 
	public void Quiz_Mod1_Menu_Button_Pressed(){

		// Hide current
		Quiz_Canvas.enabled = false;

		// Show
		Mod1_Menu_Canvas.enabled = true;

		// Set Trigger
		playerAnimatior.SetTrigger ("Clicked_Quiz_Mod1_Menu_Button");

	} // EOF Quiz_Mod1_Menu_Button_Pressed

	//----------------------------------------------------------//
	/*
	 * Remember to create next 'state' (animation clip), trigger, 
	 * and transition
	 * 
	 * For the transiton - specify that it has no exit time and 
	 * no duration
	 * 
	 * Go to the animation-clip's  file in the 'Scripts' folder 
	 * and disable 'Loop time' in the inspector
	 * 
	 * Attach function to button's onclick event
	 * 
	 * For signs with multiple canvases, make sure that, when 
	 * there is transition to them, it is the only visible canvas 
	 * on that sign.
	*/
	//----------------------------------------------------------//

	//--------------------------------------------------//
	// Activating or deactivating canvases within signs  
	//--------------------------------------------------//

	// SP Step 1--------- //

	// Back to SP_Step1_Canvas from SP_Step1_A_Canvas
	public void BackTo_SP_Step1_Canvas (){
		// Hide
		SP_Step1_A_Canvas.enabled = false;

		// Show
		SP_Step1_Canvas.enabled = true;
	}

	// Continue to SP_Step1_A_Canvas from SP_Step1_Canvas
	public void ContinueTo_SP_Step1_A_Canvas (){
		// Hide
		SP_Step1_Canvas.enabled = false;

		// Show
		SP_Step1_A_Canvas.enabled = true;
	}

	// Back to SP_Step1_A_Canvas from SP_Step1_B_Canvas
	public void BackTo_SP_Step1_A_Canvas (){
		// Hide
		SP_Step1_B_Canvas.enabled = false;

		// Show
		SP_Step1_A_Canvas.enabled = true;
	}

	// Continue to SP_Step1_B_Canvas from SP_Step1_A_Canvas
	public void ContinueTo_SP_Step1_B_Canvas (){
		// Hide
		SP_Step1_A_Canvas.enabled = false;

		// Show
		SP_Step1_B_Canvas.enabled = true;
	}
		
	// Back to SP_Step1_B_Canvas from SP_Step1_C_Canvas
	public void BackTo_SP_Step1_B_Canvas (){
		// Hide
		SP_Step1_C_Canvas.enabled = false;

		// Show
		SP_Step1_B_Canvas.enabled = true;
	}

	// Continue to SP_Step1_C_Canvas from SP_Step1_B_Canvas
	public void ContinueTo_SP_Step1_C_Canvas (){
		// Hide
		SP_Step1_B_Canvas.enabled = false;

		// Show
		SP_Step1_C_Canvas.enabled = true;
	}

	// SP Step 2--------- //

	// Back to SP_Step2_Canvas from SP_Step2_A_Canvas
	public void BackTo_SP_Step2_Canvas (){
		// Hide
		SP_Step2_A_Canvas.enabled = false;

		// Show
		SP_Step2_Canvas.enabled = true;
	}

	// Continue to SP_Step2_A_Canvas from SP_Step2_Canvas
	public void ContinueTo_SP_Step2_A_Canvas (){
		// Hide
		SP_Step2_Canvas.enabled = false;

		// Show
		SP_Step2_A_Canvas.enabled = true;
	}

	// Back to SP_Step2_A_Canvas from SP_Step2_B_Canvas
	public void BackTo_SP_Step2_A_Canvas (){
		// Hide
		SP_Step2_B_Canvas.enabled = false;

		// Show
		SP_Step2_A_Canvas.enabled = true;
	}

	// Continue to SP_Step2_B_Canvas from SP_Step2_A_Canvas
	public void ContinueTo_SP_Step2_B_Canvas (){
		// Hide
		SP_Step2_A_Canvas.enabled = false;

		// Show
		SP_Step2_B_Canvas.enabled = true;
	}

	// Back to SP_Step2_B_Canvas from SP_Step2_B_2_Canvas
	public void BackTo_SP_Step2_B_Canvas (){
		// Hide
		SP_Step2_B_2_Canvas.enabled = false;

		// Show
		SP_Step2_B_Canvas.enabled = true;
	}

	// Continue to SP_Step2_B_2_Canvas from SP_Step2_B_Canvas
	public void ContinueTo_SP_Step2_B_2_Canvas (){
		// Hide
		SP_Step2_B_Canvas.enabled = false;

		// Show
		SP_Step2_B_2_Canvas.enabled = true;
	}

	// SP Step 3--------- //

	// Back to SP_Step3_Canvas from SP_Step3_A_Canvas
	public void BackTo_SP_Step3_Canvas (){
		// Hide
		SP_Step3_A_Canvas.enabled = false;

		// Show
		SP_Step3_Canvas.enabled = true;
	}

	// Continue to SP_Step3_A_Canvas from SP_Step3_Canvas
	public void ContinueTo_SP_Step3_A_Canvas (){
		// Hide
		SP_Step3_Canvas.enabled = false;

		// Show
		SP_Step3_A_Canvas.enabled = true;
	}

	// Back to SP_Step3_A_Canvas from SP_Step3_B_Canvas
	public void BackTo_SP_Step3_A_Canvas (){
		// Hide
		SP_Step3_B_Canvas.enabled = false;

		// Show
		SP_Step3_A_Canvas.enabled = true;
	}

	// Continue to SP_Step3_B_Canvas from SP_Step3_A_Canvas
	public void ContinueTo_SP_Step3_B_Canvas (){
		// Hide
		SP_Step3_A_Canvas.enabled = false;

		// Show
		SP_Step3_B_Canvas.enabled = true;
	}

	// Back to SP_Step3_B_Canvas from SP_Step3_B_2_Canvas
	public void BackTo_SP_Step3_B_Canvas (){
		// Hide
		SP_Step3_B_2_Canvas.enabled = false;

		// Show
		SP_Step3_B_Canvas.enabled = true;
	}

	// Continue to SP_Step3_B_2_Canvas from SP_Step3_B_Canvas
	public void ContinueTo_SP_Step3_B_2_Canvas (){
		// Hide
		SP_Step3_B_Canvas.enabled = false;

		// Show
		SP_Step3_B_2_Canvas.enabled = true;
	}

	// Back to SP_Step3_B_2_Canvas from SP_Step3_B_3_Canvas
	public void BackTo_SP_Step3_B_2_Canvas (){
		// Hide
		SP_Step3_B_3_Canvas.enabled = false;

		// Show
		SP_Step3_B_2_Canvas.enabled = true;
	}

	// Continue to SP_Step3_B_3_Canvas from SP_Step3_B_2_Canvas
	public void ContinueTo_SP_Step3_B_3_Canvas (){
		// Hide
		SP_Step3_B_2_Canvas.enabled = false;

		// Show
		SP_Step3_B_3_Canvas.enabled = true;
	}

	// SDCS canvases ---------------------------------------------------------

	// Back to SDCS_Canvas from SDCS_1_Canvas
	public void BackTo_SDCS_Canvas (){
		// Hide
		SDCS_1_Canvas.enabled = false;

		// Show
		SDCS_Canvas.enabled = true;
	}

	// Continue to SDCS_1_Canvas from SDCS_Canvas
	public void ContinueTo_SDCS_1_Canvas (){
		// Hide
		SDCS_Canvas.enabled = false;

		// Show
		SDCS_1_Canvas.enabled = true;
	}
		
	// Back to SDCS_1_Canvas from SDCS_2_Canvas
	public void BackTo_SDCS_1_Canvas (){
		// Hide
		SDCS_2_Canvas.enabled = false;

		// Show
		SDCS_1_Canvas.enabled = true;
	}

	// Continue to SDCS_2_Canvas from SDCS_1_Canvas
	public void ContinueTo_SDCS_2_Canvas (){
		// Hide
		SDCS_1_Canvas.enabled = false;

		// Show
		SDCS_2_Canvas.enabled = true;
	}

	// Back to SDCS_2_Canvas from SDCS_3_Canvas
	public void BackTo_SDCS_2_Canvas (){
		// Hide
		SDCS_3_Canvas.enabled = false;

		// Show
		SDCS_2_Canvas.enabled = true;
	}

	// Continue to SDCS_3_Canvas from SDCS_2_Canvas
	public void ContinueTo_SDCS_3_Canvas (){
		// Hide
		SDCS_2_Canvas.enabled = false;

		// Show
		SDCS_3_Canvas.enabled = true;
	}

	// PCIC canvases ---------------------------------------------------------

	// Back to PCIC_Canvas from PCIC_1_Canvas
	public void BackTo_PCIC_Canvas (){
		// Hide
		PCIC_1_Canvas.enabled = false;

		// Show
		PCIC_Canvas.enabled = true;
	}
		
	// Continue to PCIC_1_Canvas from PCIC_Canvas
	public void ContinueTo_PCIC_1_Canvas (){
		// Hide
		PCIC_Canvas.enabled = false;

		// Show
		PCIC_1_Canvas.enabled = true;
	}

	// Back to PCIC_1_Canvas from PCIC_2_Canvas
	public void BackTo_PCIC_1_Canvas (){
		// Hide
		PCIC_2_Canvas.enabled = false;

		// Show
		PCIC_1_Canvas.enabled = true;
	}
		
	// Continue to PCIC_2_Canvas from PCIC_1_Canvas
	public void ContinueTo_PCIC_2_Canvas (){
		// Hide
		PCIC_1_Canvas.enabled = false;

		// Show
		PCIC_2_Canvas.enabled = true;
	}

	// Back to PCIC_2_Canvas from PCIC_3_Canvas
	public void BackTo_PCIC_2_Canvas (){
		// Hide
		PCIC_3_Canvas.enabled = false;

		// Show
		PCIC_2_Canvas.enabled = true;
	}

	// Continue to PCIC_3_Canvas from PCIC_2_Canvas
	public void ContinueTo_PCIC_3_Canvas (){
		// Hide
		PCIC_2_Canvas.enabled = false;

		// Show
		PCIC_3_Canvas.enabled = true;
	}

	// Back to PCIC_3_Canvas from PCIC_4_Canvas
	public void BackTo_PCIC_3_Canvas (){
		// Hide
		PCIC_4_Canvas.enabled = false;

		// Show
		PCIC_3_Canvas.enabled = true;
	}

//	PCIC_4_Canvas
	// Continue to PCIC_4_Canvas from PCIC_3_Canvas
	public void ContinueTo_PCIC_4_Canvas (){
		// Hide
		PCIC_3_Canvas.enabled = false;

		// Show
		PCIC_4_Canvas.enabled = true;
	}

	// Back to PCIC_4_Canvas from PCIC_3_Canvas
	public void BackTo_PCIC_4_Canvas (){
		// Hide
		PCIC_5_Canvas.enabled = false;

		// Show
		PCIC_4_Canvas.enabled = true;
	}

	// Continue to PCIC_5_Canvas from PCIC_4_Canvas
	public void ContinueTo_PCIC_5_Canvas (){
		// Hide
		PCIC_4_Canvas.enabled = false;

		// Show
		PCIC_5_Canvas.enabled = true;
	}

	// Back to PCIC_5_Canvas from PCIC_6_Canvas
	public void BackTo_PCIC_5_Canvas (){
		// Hide
		PCIC_6_Canvas.enabled = false;

		// Show
		PCIC_5_Canvas.enabled = true;
	}

	// Continue to PCIC_6_Canvas from PCIC_5_Canvas
	public void ContinueTo_PCIC_6_Canvas (){
		// Hide
		PCIC_5_Canvas.enabled = false;

		// Show
		PCIC_6_Canvas.enabled = true;
	}

	// Back to PCIC_6_Canvas from PCIC_7_Canvas
	public void BackTo_PCIC_6_Canvas (){
		// Hide
		PCIC_7_Canvas.enabled = false;

		// Show
		PCIC_6_Canvas.enabled = true;
	}

	// Continue to PCIC_7_Canvas from PCIC_6_Canvas
	public void ContinueTo_PCIC_7_Canvas (){
		// Hide
		PCIC_6_Canvas.enabled = false;

		// Show
		PCIC_7_Canvas.enabled = true;
	}

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