
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AlpacaSound.EnchantedForest
{
	[System.Serializable]
	public class ParameterMap
	{
		public enum ParameterType
		{
			NoteGenerator_Interval,
			NoteGenerator_IntervalRand,
			NoteGenerator_Probability,
			NoteGenerator_Velocity,
			NoteGenerator_VelocityRand,
			VolumeDevice_Volume,
		}

		public List<MIDIDevice> devices;
		public List<ParameterType> parameters;
		public Curve curve;

		public void Send(float value)
		{
			for (int i = 0; i < devices.Count; i++)
			{
				MIDIDevice device = devices[i];
				float val = curve.MapValue(value);
				for (int j = 0; j < parameters.Count; j++)
				{
					ParameterType parameter = parameters[j];
					switch (parameter)
					{
					case ParameterType.NoteGenerator_Interval:
						((NoteGenerator)device).interval = val;
						break;
					case ParameterType.NoteGenerator_IntervalRand:
						((NoteGenerator)device).intervalRand = val;
						break;
					case ParameterType.NoteGenerator_Probability:
						((NoteGenerator)device).probability = val;
						break;
					case ParameterType.NoteGenerator_Velocity:
						((NoteGenerator)device).velocity = val;
						break;
					case ParameterType.NoteGenerator_VelocityRand:
						((NoteGenerator)device).velocityRand = val;
						break;
					case ParameterType.VolumeDevice_Volume:
						((VolumeDevice)device).volume = val;
						break;
					default:
						Debug.Log ("Unknown parameter " + parameter);
						break;
					}
				}
			}
		}

	}
}


