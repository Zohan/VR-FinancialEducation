
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using UnityEditor;
using System;

namespace AlpacaSound.EnchantedForest
{
	[CustomEditor (typeof(EnchantedForest))]
	public class EnchantedForestEditor : Editor
	{
		SerializedObject serObj;

		SerializedProperty autoplay;
		SerializedProperty masterVolume;
		SerializedProperty wind;
		SerializedProperty animalActivity;
		SerializedProperty fairyDust;
		SerializedProperty useLocalTime;
		SerializedProperty timeOfDay;

		void OnEnable()
		{
			serObj = new SerializedObject(target);
			
			autoplay = serObj.FindProperty("autoplay");
			masterVolume = serObj.FindProperty("masterVolume");
			wind = serObj.FindProperty("wind");
			animalActivity = serObj.FindProperty("animalActivity");
			fairyDust = serObj.FindProperty("fairyDust");
			useLocalTime = serObj.FindProperty("useLocalTime");
			timeOfDay = serObj.FindProperty("timeOfDay");
		}


		override public void OnInspectorGUI()
		{

			serObj.Update();

			//EnchantedForest myTarget = (EnchantedForest) target;

			autoplay.boolValue = EditorGUILayout.Toggle("Autoplay", autoplay.boolValue);
			masterVolume.floatValue = EditorGUILayout.Slider("Master Volume", masterVolume.floatValue, 0, 1);
			wind.floatValue = EditorGUILayout.Slider("Wind", wind.floatValue, 0, 1);
			animalActivity.floatValue = EditorGUILayout.Slider("Animal Activity", animalActivity.floatValue, 0, 1);
			fairyDust.floatValue = EditorGUILayout.Slider("Fairy Dust", fairyDust.floatValue, 0, 1);
			useLocalTime.boolValue = EditorGUILayout.Toggle("Use Local Time", useLocalTime.boolValue);

			EditorGUI.BeginDisabledGroup (useLocalTime.boolValue);
			timeOfDay.floatValue = EditorGUILayout.Slider("Time Of Day", timeOfDay.floatValue, 0, 1);
			EditorGUI.EndDisabledGroup ();

			EditorGUILayout.LabelField("Time Of Day (hours)", Utils.TimeInHours(timeOfDay.floatValue));

			serObj.ApplyModifiedProperties();
		}

	}
}
