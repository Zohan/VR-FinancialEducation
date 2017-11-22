using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// REF: http://wiki.unity3d.com/index.php?title=FadeInOut
// simple fading script
// A texture is stretched over the entire screen. The color of the pixel is set each frame until it reaches its target color.
public class CameraFade : MonoBehaviour
{
    // Reference to module 2 main script
    public Module2_Main mainScript;

    private GUIStyle m_BackgroundStyle = new GUIStyle();                // Style for background tiling
    private Texture2D m_FadeTexture;                                    // 1x1 pixel texture used for fading
    private Color m_CurrentScreenOverlayColor = new Color(0, 0, 0, 0);  // default starting color: black and fully transparrent
    private Color m_TargetScreenOverlayColor = new Color(0, 0, 0, 0);   // default target color: black and fully transparrent
    private Color m_DeltaColor = new Color(0, 0, 0, 0);                 // the delta-color is basically the "speed / second" at which the current color should change
    private int m_FadeGUIDepth = -1000;                                 // make sure this texture is drawn on top of everything
    private bool changeState = false;                                   // allow for state change after fade
    private string nextState = "";                                      // state to transition to after a fade event

    //public delegate void PostFadeCallback(); // declare delegate type
    //protected PostFadeCallback callbackFunction; // to store the function

    // initialize the texture, background-style and initial color:
    private void Awake()
    {
        m_FadeTexture = new Texture2D(1, 1);
        m_BackgroundStyle.normal.background = m_FadeTexture;
        SetScreenOverlayColor(m_CurrentScreenOverlayColor);
    }

    // draw the texture and perform the fade:
    private void OnGUI()
    {
        // if the current color of the screen is not equal to the desired color: keep fading!
        if (m_CurrentScreenOverlayColor != m_TargetScreenOverlayColor)
        {
            // if the difference between the current alpha and the desired alpha is smaller than delta-alpha * deltaTime, then we're pretty much done fading:
            if (Mathf.Abs(m_CurrentScreenOverlayColor.a - m_TargetScreenOverlayColor.a) < Mathf.Abs(m_DeltaColor.a) * Time.deltaTime)
            {
                m_CurrentScreenOverlayColor = m_TargetScreenOverlayColor;
                SetScreenOverlayColor(m_CurrentScreenOverlayColor);
                m_DeltaColor = new Color(0, 0, 0, 0);

                // Return callback function
                if (changeState && mainScript != null)
                {
                    changeState = false;
                    mainScript.GoToState(nextState);
                    FadeIn(2);
                }
            }
            else
            {
                // fade!
                SetScreenOverlayColor(m_CurrentScreenOverlayColor + m_DeltaColor * Time.deltaTime);
            }
        }

        // only draw the texture when the alpha value is greater than 0:
        if (m_CurrentScreenOverlayColor.a > 0)
        {
            GUI.depth = m_FadeGUIDepth;
            GUI.Label(new Rect(-10, -10, Screen.width + 10, Screen.height + 10), m_FadeTexture, m_BackgroundStyle);
        }
    }

    public void FadeIn(float seconds)
    {
        SetScreenOverlayColor(new Color(0, 0, 0, 1));
        StartFade(new Color(0, 0, 0, 0), seconds);
    }
    public void FadeOut(float seconds)
    {
        SetScreenOverlayColor(new Color(0, 0, 0, 0));
        StartFade(new Color(0, 0, 0, 1), seconds);
    }
    public void FadeToState(string state)
    {
        if (state != null && state != "")
        {
            changeState = true;
            nextState = state;
        }
        FadeOut(2);
    }
    //public void FadeOutCallback(Action<string> callback)
    //{
    //    callbackFunction = callback;
    //}

    //public Action myAction;
    //private Action<string> callbackFunction;

    //void Start()
    //{
    //    myAction += callback;
    //    callbackFunction += callbackString;

    //    myAction();
    //    callbackFunction("foo");
    //}


    //public void DoRequest(string request, Action<string> callback)
    //{
    //    // do stuff....
    //    callback("asdf");
    //}

    //---
    //void callProcess()
    //{
    //    FadeOutCallback(dosomething);
    //}

    //void dosomething()
    //{
    //    //...
    //}

    // instantly set the current color of the screen-texture to "newScreenOverlayColor"
    // can be usefull if you want to start a scene fully black and then fade to opague
    public void SetScreenOverlayColor(Color newScreenOverlayColor)
    {
        m_CurrentScreenOverlayColor = newScreenOverlayColor;
        m_FadeTexture.SetPixel(0, 0, m_CurrentScreenOverlayColor);
        m_FadeTexture.Apply();
    }


    // initiate a fade from the current screen color (set using "SetScreenOverlayColor") towards "newScreenOverlayColor" taking "fadeDuration" seconds
    public void StartFade(Color newScreenOverlayColor, float fadeDuration)
    {
        // can't have a fade last -2455.05 seconds!
        if (fadeDuration <= 0.0f)
        {
            SetScreenOverlayColor(newScreenOverlayColor);
        }
        // initiate the fade: set the target-color and the delta-color
        else
        {
            m_TargetScreenOverlayColor = newScreenOverlayColor;
            m_DeltaColor = (m_TargetScreenOverlayColor - m_CurrentScreenOverlayColor) / fadeDuration;
        }
    }
}