
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AlpacaSound.EnchantedForest
{
	public class Channel : MonoBehaviour
	{
		public float masterVolume = 1;
		public float globalVolume = 1;
		public bool useEnvelope = true;

		AudioSource audioSource;
		float clipVolume = 1;
		int Note = -1;
		float noteOnTime = -1;
		float noteOffTime = -1;
		float amp = 1;
		float attackTime = 0;
		float releaseTime = 0;

		void Awake()
		{
			audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.playOnAwake = false;
		}

		public bool IsPlaying()
		{
			return audioSource.isPlaying;
		}

		public void NoteOn(int note, AudioClip clip, float clipVolume, float amp, float pitch, float pan, float attackTime, float releaseTime, bool loop, bool startAtRandomPosition)
		{
			if (!audioSource.isPlaying)
			{
				audioSource.clip = clip;
				audioSource.pitch = pitch;
				audioSource.loop = loop;
				audioSource.panStereo = pan;

				if (startAtRandomPosition)
				{
					audioSource.time = SamplerUtils.GetRandomStartTime(clip);
				}
				else
				{
					audioSource.time = 0;
				}

				Note = note;
				this.clipVolume = clipVolume;
				this.amp = amp;
				this.attackTime = attackTime;
				this.releaseTime = releaseTime;
				noteOnTime = Time.realtimeSinceStartup;
				noteOffTime = -1;

				UpdateVolume();
				//print ("vol = " + audioSource.volume);
				audioSource.Play();
			}
		}

		void UpdateVolume()
		{
			float vol = amp * clipVolume * masterVolume * globalVolume;

			if (useEnvelope)
			{
				float currentTime = Time.realtimeSinceStartup;

				if ((noteOffTime > 0) && (currentTime > noteOffTime + releaseTime))
				{
					audioSource.Stop();
					return;
				}

				float env = SamplerUtils.GetEnvelope(attackTime, releaseTime, noteOnTime, noteOffTime, currentTime);
				vol *= env;

				//print ("env=" + env);
			}

			audioSource.volume = Mathf.Clamp01(vol);
		}

		public void Update()
		{
			if (audioSource.isPlaying)
			{
				UpdateVolume();
			}
		}

		public void NoteOff(int note, float releaseTime)
		{
			if (note == Note && noteOffTime < 0)
			{
				noteOffTime = Time.realtimeSinceStartup;
			}
		}

		public void Kill()
		{
			audioSource.Stop();
		}

	}
	
}
