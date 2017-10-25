
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AlpacaSound.EnchantedForest
{

	public class NoteGenerator : MIDIDevice
	{
		public bool autoplay = false;
		public float interval = 1;
		public float intervalRand = 0; // Factor to multiply interval with (1 +- intervalRand)
		public float noteLength = 1;
		public float noteLengthRand = 0;
		public float velocity = 1;
		public float velocityRand = 0;
		public float probability = 1;
		public bool avoidRepetition = false;
		public float initialDelay = 0;
		public List<int> notes;

		float lastNoteTime;
		float currentIntervalRand;
		float currentNoteLength;
		int lastNoteIndex = -1;
		bool isNoteOn = false;

		bool isActive = false;

		void Start()
		{
			if (autoplay)
			{
				Play ();
			}
		}

		public void Play()
		{
			lastNoteTime = Time.realtimeSinceStartup + initialDelay;
			isActive = true;
		}

		public void Stop()
		{
			NoteOff();
			isActive = false;
		}

		public void Kill()
		{
			MIDIMessage msg = MIDIMessage.CreateKillMessage();
			SendMIDIMessage(msg);
		}
		
		void Update()
		{
			if (isActive)
			{
				if (isNoteOn)
				{
					if (probability == 0)
					{
						NoteOff();
					}
					else if (Time.realtimeSinceStartup >= lastNoteTime + currentNoteLength)
					{
						NoteOff();
					}
				}

				if (Time.realtimeSinceStartup >= lastNoteTime + interval * currentIntervalRand)
				{
					PlayNote();
				}
			}
		}

		void NoteOff()
		{
			if (isNoteOn)
			{
				MIDIMessage noteOff = MIDIMessage.CreateNoteOffMessage(notes[lastNoteIndex]);
				SendMIDIMessage(noteOff);
				isNoteOn = false;
			}
		}

		void PlayNote()
		{
			NoteOff();

			if (notes.Count > 0)
			{
				float p = Random.value;

				if (p < probability)
				{
					int noteIndex = PickNextNoteIndex();
					lastNoteIndex = noteIndex;

					int note = notes[noteIndex];
					float vel = Mathf.Clamp01(SamplerUtils.RandomizeSubtract(velocity, velocityRand));
					if (vel > 0)
					{
						currentNoteLength = SamplerUtils.Randomize(noteLength, noteLengthRand);
						MIDIMessage noteOn = MIDIMessage.CreateNoteOnMessage(note, vel);
						SendMIDIMessage(noteOn);
						isNoteOn = true;
					}
				}
			}

			lastNoteTime = Time.realtimeSinceStartup;
			currentIntervalRand = Random.Range(1-intervalRand, 1+intervalRand);
		}

		int PickNextNoteIndex()
		{
			if (notes.Count <= 1)
			{
				return 0;
			}

			if (avoidRepetition)
			{
				if (lastNoteIndex == -1)
				{
					return Random.Range (0, notes.Count);
				}
				else
				{
					int noteIndex = Random.Range (0, notes.Count - 1);
					return (noteIndex >= lastNoteIndex) ? (noteIndex + 1) : noteIndex;
				}
			}
			else
			{
				return Random.Range (0, notes.Count);
			}
		}
	}
}