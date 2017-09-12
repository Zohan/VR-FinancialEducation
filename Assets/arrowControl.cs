using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowControl : MonoBehaviour {
	GameObject document;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startRotate(GameObject doc){
		document = doc;
	}

	public void rotateDocument(){
		document.transform.Rotate (0, 10, 0);
	}
}
