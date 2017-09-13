using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod4_AnimationScript : MonoBehaviour {

	Animator animator;
	int counter;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextStep(){
		counter++;
		animator.SetInteger ("next_step", counter);
	}
}
