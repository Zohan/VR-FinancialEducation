using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentScript : MonoBehaviour {

	Vector3 move;
	Vector3 origin;
	Quaternion origin_rotate;
	private bool selected;

	void Start(){
		origin = this.gameObject.transform.position;
		origin_rotate = this.gameObject.transform.rotation;
		selected = false;
	}

	public void selectdoc(){
		if (selected == false) {
			selected = true;
			docview ();
		} else {
			Debug.Log ("what");
			selected = false;
			this.gameObject.transform.rotation = origin_rotate;
			this.gameObject.transform.position = origin;
			this.gameObject.transform.localScale = new Vector3 (1, 1, 1);
		}

	}

	public void docview(){
		int yRotation = 90;
		this.gameObject.transform.Rotate (60, 0, 0);
		this.gameObject.transform.localScale = new Vector3 (3, 3, 3);
		switch (gameObject.name) {
		case "birthcertificate":
			move = new Vector3 (84.8f, 179f, 89.6f);
			break;
		case "marriagecertificate":
			move = new Vector3 (85.8f, 178.8f, 90f);
			break;
		case "benefit":
			move = new Vector3 (82.9f, 178.3f, 90f);
			break;
		case "socialsecurity (1)":
			this.gameObject.transform.Rotate (-60, 0, 45);
			move = new Vector3 (84.2f, 180.8f, 89.8f);
			break;
		case "bankstatement":
			move = new Vector3 (78.8f, 177f, 89.8f);
			break;
		}
		gameObject.transform.position = move;
	}

	public void gazedoc(){
		Debug.Log (gameObject.name);
	}
}
