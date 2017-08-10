
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AlpacaSound.EnchantedForest
{

	public class MIDIDevice : MonoBehaviour
	{
		public List<GameObject> MIDIOuts;

		protected void SendMIDIMessage(MIDIMessage msg)
		{
			for (int i = 0; i < MIDIOuts.Count; i++)
			{
				GameObject MIDIOut = MIDIOuts[i];

				if (MIDIOut)
				{
					MIDIDevice device = MIDIOut.GetComponent<MIDIDevice>();
					if (device)
					{
						device.OnMIDIMessage (msg);
					}
				}
			}
		}

		protected virtual void OnMIDIMessage(MIDIMessage msg)
		{
		}

	}

}
