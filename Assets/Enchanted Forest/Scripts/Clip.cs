
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;

namespace AlpacaSound.EnchantedForest
{

	[System.Serializable]
	public class Clip
	{
		public AudioClip clip;
		public float volume = 1;
		public bool loop = false;
		public bool startAtRandomPosition = false;
		public int RootNote;
		public int ZoneStart;
		public int ZoneEnd;
		
		public override string ToString()
		{
			return clip.name + " " + RootNote + ":[" + ZoneStart + "-" + ZoneEnd + "]";
		}

	}

}

