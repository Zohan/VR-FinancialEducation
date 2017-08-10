
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;

namespace AlpacaSound.EnchantedForest
{

	public class VolumeDevice : MIDIDevice 
	{
		[System.Serializable]
		public enum DeviceType
		{
			MasterVolume,
			GlobalVolume,
		}

		public DeviceType deviceType;

		float m_volume;
		public float volume
		{
			get
			{
				return m_volume;
			}

			set
			{
				if (value != m_volume)
				{
					m_volume = value;
					Send();
				}
			}
		}

		void Start()
		{
			Send();
		}

		void Send()
		{
			switch (deviceType)
			{
			case DeviceType.MasterVolume:
				SendMIDIMessage(MIDIMessage.CreateMasterVolumeMessage(volume));		
				break;
			case DeviceType.GlobalVolume:
				SendMIDIMessage(MIDIMessage.CreateGlobalVolumeMessage(volume));		
				break;
			default:
				Debug.LogWarning("Unknown device type.");
				break;
			}
		}

	}
}
