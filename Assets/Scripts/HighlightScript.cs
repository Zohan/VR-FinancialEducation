using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightScript : MonoBehaviour {

    public Image Highlighter;
    public float alphaLevel = 1f;

    // Use this for initialization
    void Start() {
        Transparent();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Highlight() {
        Highlighter.color = Color.yellow;
    }

    public void Transparent() {
        Highlighter.color = Color.red;
    }
}