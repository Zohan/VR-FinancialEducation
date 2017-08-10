
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;
using System;

namespace AlpacaSound.EnchantedForest
{
	public class DemoGUI : MonoBehaviour
	{
		public EnchantedForest target;
		public bool debug = true;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnGUI()
		{
			float h = 20;

			float col1width = 110;
			float col2width = 200;
			float col3width = 150;

			float x0 = 20;
			float x1 = x0 + col1width;
			float x2 = x1 + col2width + 10;

			float y = 20;

			if (debug)
			{
				GUI.Box (new Rect (10, 10, 500, 240), "");
			}
			else
			{
				GUI.Box (new Rect (10, 10, 440, 145), "");
			}

			// Master Volume
			GUI.Label(new Rect(x0, y, col1width, h), "Master Volume");
			target.masterVolume = GUI.HorizontalSlider(new Rect(x1, y+5, col2width, h), target.masterVolume, 0, 1);
			if (debug) GUI.Label(new Rect(x2, y, col3width, h), "" + target.masterVolume);
			y += h;


			// Wind
			GUI.Label(new Rect(x0, y, col1width, h), "Wind");
			target.wind = GUI.HorizontalSlider(new Rect(x1, y+5, col2width, h), target.wind, 0, 1);
			if (debug) GUI.Label(new Rect(x2, y, col3width, h), "" + target.wind);
			y += h;
			

			// Atmospheric Presence
			GUI.Label(new Rect(x0, y, col1width, h), "Animal Activity");
			target.animalActivity = GUI.HorizontalSlider(new Rect(x1, y+5, col2width, h), target.animalActivity, 0, 1);
			if (debug) GUI.Label(new Rect(x2, y, col3width, h), "" + target.animalActivity);
			y += h;


			// Musical Presence
			GUI.Label(new Rect(x0, y, col1width, h), "Fairy Dust");
			target.fairyDust = GUI.HorizontalSlider(new Rect(x1, y+5, col2width, h), target.fairyDust, 0, 1);
			if (debug) GUI.Label(new Rect(x2, y, col3width, h), "" + target.fairyDust);
			y += h;


			// Time Of Day
			GUI.enabled = !target.useLocalTime;
			GUI.Label(new Rect(x0, y, col1width, h), "Time of Day");
			target.timeOfDay = GUI.HorizontalSlider(new Rect(x1, y+5, col2width, h), target.timeOfDay, 0, 1);
			if (debug) GUI.Label(new Rect(x2, y, col3width, h), Utils.TimeInHours(target.timeOfDay) + " (" + target.timeOfDay + ")");
			if (!debug) GUI.Label(new Rect(x2, y, col3width, h), "" + Utils.TimeInHours(target.timeOfDay));
			GUI.enabled = true;
			y += h;

			GUI.Label(new Rect(x0, y, col1width, h), "Use Local Time");
			target.useLocalTime = GUI.Toggle(new Rect(x1-2, y, col2width, h), target.useLocalTime, "");

			if (debug)
			{
				y += h;
				y += h;

				if (GUI.Button(new Rect(x0, y, col1width, h), "Play")) target.Play();
				if (GUI.Button(new Rect(x0+col1width+10, y, col1width, h), "Stop")) target.Stop();
				if (GUI.Button(new Rect(x0+2*col1width+20, y, col1width, h), "Kill")) target.Kill();
				y += h;

				y += h;
				if (GUI.Button(new Rect(x0, y, col1width, h), "Night"))
				{
					target.useLocalTime = false;
					target.timeOfDay = 0.0f;
				}
				
				if (GUI.Button(new Rect(x0+col1width + 10, y, col1width, h), "Morning"))
				{
					target.useLocalTime = false;
					target.timeOfDay = 0.25f;
				}
				
				y += h+2;
				if (GUI.Button(new Rect(x0, y, col1width, h), "Day"))
				{
					target.useLocalTime = false;
					target.timeOfDay = 0.5f;
				}
				
				if (GUI.Button(new Rect(x0+col1width + 10, y, col1width, h), "Evening"))
				{
					target.useLocalTime = false;
					target.timeOfDay = 0.75f;
				}

			}
		}

	}

}