
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlpacaSound.EnchantedForest
{
	public class EnchantedForest : MonoBehaviour
	{
		public bool autoplay = true;
		
		/// <summary>
		/// Master volume for the soundscape.
		/// </summary>
		public float masterVolume = 1;
		float m_masterVolume = 1;
		
		/// <summary>
		/// The volume of the wind.
		/// </summary>
		public float wind = 1;
		float m_wind = 1;
		
		/// <summary>
		/// How often the birds and other animals will play. (Doesn’t affect their volume.)
		/// </summary>
		public float animalActivity = 1;
		float m_animalActivity = 1;
		
		/// <summary>
		/// How often the sound effects and musical elements play. (Doesn’t affect their volume.)
		/// </summary>
		public float fairyDust = 1;
		float m_fairyDust = 1;
		
		/// <summary>
		/// Makes the Time Of Day follow the computer clock.
		/// </summary>
		public bool useLocalTime = false;
		
		/// <summary>
		/// The time of day.
		/// 0.00 = midnight,
		/// 0.25 = morning,
		/// 0.50 = midday,
		/// 0.75 = evening,
		/// 1.00 = midnight (again).
		/// </summary>
		public float timeOfDay = 0.5f;
		float m_timeOfDay = 0.5f;

		VolumeDevice globalVolumeDevice;
		VolumeDevice windVolumeDevice;
		MetaParameterDevice probabilityDevice;
		MetaParameterDevice animalIntervalDevice;
		MetaParameterDevice fxIntervalParameterDevice;
		MetaParameterDevice animalVelocityDevice;
		MetaParameterDevice fxVelocityDevice;
		List<NoteGenerator> noteGenerators;

		void Awake()
		{
			noteGenerators = new List<NoteGenerator>(GetComponentsInChildren<NoteGenerator>());

			MetaParameterDevice[] metaParameters = GetComponentsInChildren<MetaParameterDevice>();
			for (int i = 0; i < metaParameters.Length; i++) 
			{
				MetaParameterDevice metaParameter = metaParameters[i];

				switch (metaParameter.name)
				{
				case "Time Of Day":
					probabilityDevice = metaParameter;
					break;
				case "Animal Interval":
					animalIntervalDevice = metaParameter;
					break;
				case "Animal Velocity":
					animalVelocityDevice = metaParameter;
					break;
				case "FX Interval":
					fxIntervalParameterDevice = metaParameter;
					break;
				case "FX Velocity":
					fxVelocityDevice = metaParameter;
					break;
				default:
					Debug.LogWarning ("MetaParameterDevice not found.");
					break;
				}
			}

			VolumeDevice[] volumeDevices = GetComponentsInChildren<VolumeDevice>();
			for (int i = 0; i < volumeDevices.Length; i++)
			{
				VolumeDevice volumeDevice = volumeDevices[i];
				switch (volumeDevice.name)
				{
				case "Global Volume":
					globalVolumeDevice = volumeDevice;
					break;
				case "Wind Volume":
					windVolumeDevice = volumeDevice;
					break;
				default:
					Debug.LogWarning ("VolumeDevice not found.");
					break;
				}
			}
		}

		void Start()
		{
			globalVolumeDevice.volume = masterVolume;
			windVolumeDevice.volume = wind;
			probabilityDevice.parameter = timeOfDay;
			animalIntervalDevice.parameter = animalActivity;
			animalVelocityDevice.parameter = animalActivity;
			fxIntervalParameterDevice.parameter = fairyDust;
			fxVelocityDevice.parameter = fairyDust;

			if (autoplay)
			{
				Play();
			}
		}

		void Update()
		{
			if (useLocalTime)
			{
				DateTime now = DateTime.Now;

				/*
				float time = now.Hour / 24f;
				time += now.Minute / 24f / 60f;
				time += now.Second / 24f / 60f / 60f;
				time = Mathf.Clamp01(time);
				timeOfDay = time;
				*/

				timeOfDay = Mathf.Clamp01(((((now.Second / 60f) + now.Minute) / 60f) + now.Hour) / 24f);
			}

			masterVolume = Mathf.Clamp01(masterVolume);
			if (masterVolume != m_masterVolume)
			{
				globalVolumeDevice.volume = masterVolume;
				m_masterVolume = masterVolume;
			}
			
			wind = Mathf.Clamp01(wind);
			if (wind != m_wind)
			{
				windVolumeDevice.volume = wind;
				m_wind = wind;
			}
			
			animalActivity = Mathf.Clamp01(animalActivity);
			if (animalActivity != m_animalActivity)
			{
				animalIntervalDevice.parameter = animalActivity;
				animalVelocityDevice.parameter = animalActivity;
				m_animalActivity = animalActivity;
			}

			fairyDust = Mathf.Clamp01(fairyDust);
			if (fairyDust != m_fairyDust)
			{
				fxIntervalParameterDevice.parameter = fairyDust;
				fxVelocityDevice.parameter = fairyDust;
				m_fairyDust = fairyDust;
			}

			timeOfDay = Mathf.Clamp01(timeOfDay);
			if (timeOfDay != m_timeOfDay)
			{
				probabilityDevice.parameter = timeOfDay;
				m_timeOfDay = timeOfDay;
			}
		}

		/// <summary>
		/// Starts the playback of the soundscape.
		/// </summary>
		public void Play()
		{
			for (int i = 0; i < noteGenerators.Count; i++)
			{
				NoteGenerator generator = noteGenerators[i];
				generator.Play ();
			}
		}
		
		/// <summary>
		/// Gracefully ends the playback. No new sounds will be played but those that are already playing will finish.
		/// </summary>
		public void Stop()
		{
			for (int i = 0; i < noteGenerators.Count; i++)
			{
				NoteGenerator generator = noteGenerators[i];
				generator.Stop ();
			}
		}
		
		/// <summary>
		/// Abruptly stops all sounds in the soundscape.
		/// </summary>
		public void Kill()
		{
			for (int i = 0; i < noteGenerators.Count; i++)
			{
				NoteGenerator generator = noteGenerators[i];
				generator.Kill ();
			}
		}
		
	}
}



