using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {

	public void clickTable(){
		Debug.Log ("Table clicked");
		Vector3 move = new Vector3 (140f, 185, 94.35f);
		GameObject.Find ("FPSController").transform.position = move;
		GetComponent<Collider> ().enabled = false;
	}
}
