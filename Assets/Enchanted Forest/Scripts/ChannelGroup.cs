
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AlpacaSound.EnchantedForest
{

	public class ChannelGroup : MonoBehaviour
	{
		List<Channel> channels;

		public float masterVolume
		{
			set
			{
				for (int i = 0; i < channels.Count; i++)
				{
					Channel ch = channels[i];
					ch.masterVolume = value;
				}
			}
		}
		
		public float globalVolume
		{
			set
			{
				for (int i = 0; i < channels.Count; i++)
				{
					Channel ch = channels[i];
					ch.globalVolume = value;
				}
			}
		}
		
		public void SetPolyphony(int polyphony, bool useEnvelope)
		{
			channels = new List<Channel>();

			for (int i = 0; i < polyphony; ++i)
			{
				Channel ch = gameObject.AddComponent<Channel>();
				ch.useEnvelope = useEnvelope;
				channels.Add(ch);
			}
		}

		public void NoteOn(int note, AudioClip clip, float clipVolume, float amp, float pitch, float pan, float attackTime, float releaseTime, bool loop, bool startAtRandomPosition)
		{
			Channel ch = GetAvailableChannel();

			if (ch != null)
			{
				ch.NoteOn(note, clip, clipVolume, amp, pitch, pan, attackTime, releaseTime, loop, startAtRandomPosition);
			}
			else
			{
				Utils.LogWarning("No channel available.");
			}
		}

		Channel GetAvailableChannel()
		{
			for (int i = 0; i < channels.Count; ++i)
			{
				Channel ch = channels[i];
				if (!ch.IsPlaying())
				{
					return ch;
				}
			}

			return null;
		}

		public void NoteOff(int note, float releaseTime)
		{
			for (int i = 0; i < channels.Count; i++)
			{
				Channel ch = channels[i];
				ch.NoteOff (note, releaseTime);
			}
		}

		public void Kill()
		{
			for (int i = 0; i < channels.Count; i++)
			{
				Channel ch = channels[i];
				ch.Kill ();
			}
		}
	}
}
