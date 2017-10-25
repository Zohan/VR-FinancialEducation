
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
	public class SamplerPatch
	{

		public int Polyphony = 4;
		public float MasterVolume = 1;
		public bool useEnvelope = true;
		public float Attack = 0;
		public float Release = 3;
		public float velocitySensitivity = 0;
		public float PitchRandomization = 0;
		public float PanRandomization = 0;
		public List<Clip> Clips;

	}
}
