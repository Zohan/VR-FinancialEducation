using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// REF: http://wiki.unity3d.com/index.php?title=FadeInOut
// REF: https://gist.github.com/xtrimsky/0d58ee4db1964577893353365903b91a
public class VR_CameraFade : MonoBehaviour
{
    // Fields
    public Module2_Main mainScript;         // Reference to module 2 main script
    public Material material;               // material to render for fade effect
    public float defaultFadeTime = 2.0f;    // default amount of time for fade events (seconds)

    private Color currentFadeColor = new Color(0, 0, 0, 0);             // default starting color: black and fully transparrent
    private Color targetFadeColor = new Color(0, 0, 0, 0);              // default target color: black and fully transparrent
    private Color deltaColor = new Color(0, 0, 0, 0);                   // the delta-color is basically the "speed / second" at which the current color should change
    private bool runFadeIn = false;                                     // should be in FADE IN state
    private bool runFadeOut = false;                                    // should be in FADE OUT state
    private bool changeState = false;                                   // allow for state change after fade
    private string nextState = "";                                      // state to transition to after a fade event

    // initialize the texture, background-style and initial color:
    private void Awake()
    {
        ApplyFadeColor(currentFadeColor);
    }

    // initiate a fade from the current screen color (set using "ApplyFadeColor") towards "newFadeColor" taking "fadeDuration" seconds
    public void StartFade(Color newFadeColor, float fadeDuration)
    {
        // can't have a fade last -2455.05 seconds!
        if (fadeDuration <= 0.0f)
        {
            ApplyFadeColor(newFadeColor);
        }
        // initiate the fade: set the target-color and the delta-color
        else
        {
            targetFadeColor = newFadeColor;
            deltaColor = (targetFadeColor - currentFadeColor) / fadeDuration;
        }
    }

    // instantly set the current color of the screen-texture to "newFadeColor"
    // can be usefull if you want to start a scene fully black and then fade to opague
    public void ApplyFadeColor(Color newFadeColor)
    {
        currentFadeColor = newFadeColor;
        material.color = currentFadeColor;
    }

    // draw the texture and perform the fade:
    private void Update()
    {
        // if the current color of the screen is not equal to the desired color: keep fading!
        if (currentFadeColor != targetFadeColor)
        {
            // if the difference between the current alpha and the desired alpha is smaller than delta-alpha * deltaTime, then we're pretty much done fading:
            if (Mathf.Abs(currentFadeColor.a - targetFadeColor.a) < Mathf.Abs(deltaColor.a) * Time.deltaTime)
            {
                currentFadeColor = targetFadeColor;
                ApplyFadeColor(currentFadeColor);
                deltaColor = new Color(0, 0, 0, 0);

                // If a state change is expected
                if (changeState && mainScript != null)
                {
                    changeState = false;
                    mainScript.GoToState(nextState);
                    FadeIn(defaultFadeTime);
                }
            }
            else
            {
                // fade!
                ApplyFadeColor(currentFadeColor + deltaColor * Time.deltaTime);
            }
        }
    }

    public void FadeIn(float seconds)
    {
        ApplyFadeColor(new Color(0, 0, 0, 1));
        StartFade(new Color(0, 0, 0, 0), seconds);
    }
    public void FadeOut(float seconds)
    {
        ApplyFadeColor(new Color(0, 0, 0, 0));
        StartFade(new Color(0, 0, 0, 1), seconds);
    }
    public void FadeToState(string state)
    {
        if (state != null && state != "")
        {
            changeState = true;
            nextState = state;
        }
        FadeOut(defaultFadeTime);
    }
}