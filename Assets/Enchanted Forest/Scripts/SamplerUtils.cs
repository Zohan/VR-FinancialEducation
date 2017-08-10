
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;

namespace AlpacaSound.EnchantedForest
{
	public class SamplerUtils
	{

		public static float SemitonesToRatio(int noteNumber, int rootNote)
		{
			float semitoneRatio = 1.05946309435929f; // Mathf.Pow(2f, (1f/12f))
			int semitones = noteNumber - rootNote;
			return Mathf.Pow(semitoneRatio, semitones);
		}

		public static float RandomizeSubtract(float value, float randomization)
		{
			float result = value - Random.Range(0, randomization);
			return result;
		}
		
		public static float Randomize(float value, float randomization)
		{
			float result = Random.Range(value-randomization, value+randomization);
			return result;
		}

		public static float TimeToSpeed(float time, float value)
		{
			if (time == 0)
			{
				return 1000000;
			}
			else
			{
				return value / time;
			}
		}

		public static float GetEnvelope(float attackTime, float releaseTime, float noteOnTime, float noteOffTime, float currentTime)
		{
			if (noteOffTime > 0)
			{
				// releasing
				float noteOffLevel = Mathf.Clamp01((noteOffTime - noteOnTime) / attackTime);
				return Mathf.Clamp01(noteOffLevel * (releaseTime - (currentTime - noteOffTime)) / releaseTime);
			}
			else if (currentTime < noteOnTime + attackTime)
			{
				// attacking
				return Mathf.Clamp01((currentTime - noteOnTime) / attackTime);
			}
			else
			{
				// sustaining
				return 1;
			}
		}

		public static float GetAmp(float velocity, float velocitySensitivity)
		{
			float amp = 1 - velocitySensitivity + velocity * velocitySensitivity;
			return amp;
		}

		public static float GetRandomStartTime(AudioClip clip)
		{
			return Random.Range(0, clip.length);
		}

	}

}