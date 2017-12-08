using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_CameraRecenter : MonoBehaviour {
    // Attach this script to the VR_CameraRecenterButton
    public void RecenterVRCamera()
    {
        GvrCardboardHelpers.Recenter();
    }
}
