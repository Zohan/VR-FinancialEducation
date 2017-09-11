using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentScript : MonoBehaviour {

	Vector3 move;

	public void selectdoc(){
		int yRotation = 90;
		this.gameObject.transform.Rotate (60, 0, 0);
		switch (gameObject.name) {
		case "birthcertificate":
			move = new Vector3 (139.4f, 184f, 94.1f);
			break;
		case "marriagecertificate":
			move = new Vector3 (139.2f, 184.2f, 94.1f);
			break;
		case "benefit":
			move = new Vector3 (138, 183.5f, 94);
			break;
		case "socialsecurity (1)":
			this.gameObject.transform.Rotate (-60, 0, 45);
			move = new Vector3 (138.7f, 184.5f, 94.2f);
			break;
		case "bankstatement":
			move = new Vector3 (137.5f, 183.5f, 94.2f);
			break;
		}
		gameObject.transform.position = move;

	}

	public void gazedoc(){
		Debug.Log (gameObject.name);
	}
}
