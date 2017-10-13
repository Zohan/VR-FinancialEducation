using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimation : MonoBehaviour {
	Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TriggerAnimation(){
		animator.SetBool ("start", true);
	}
}
