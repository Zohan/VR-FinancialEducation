using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentScript : MonoBehaviour {

	public void selectdoc(){
		int yRotation = 90;
		this.gameObject.transform.Rotate (60, 0, 0);
		Vector3 move = new Vector3 (139.2f, 184f, 94.1f);
		gameObject.transform.position = move;
	}

	public void gazedoc(){
		Debug.Log (gameObject.name);
	}
}
