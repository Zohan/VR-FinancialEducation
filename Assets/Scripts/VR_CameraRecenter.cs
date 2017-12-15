using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class VR_CameraRecenter : MonoBehaviour {
    // Attach this script to the VR_CameraRecenterButton
    public void RecenterVRCamera()
    {
        GvrCardboardHelpers.Recenter();
    }

    public void rotationPressed(float degrees){
		GameObject[] player = GameObject.FindGameObjectsWithTag ("Player");
        Vector3 movementVector = new Vector3 (0.0f, degrees, 0.0f);
		player[0].transform.eulerAngles = movementVector;
    }
}
