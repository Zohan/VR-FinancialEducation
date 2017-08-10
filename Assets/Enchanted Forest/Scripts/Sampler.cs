
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AlpacaSound.EnchantedForest
{

	public class Sampler : MIDIDevice
	{
		public SamplerPatch patch;

		ChannelGroup channels;

		void Awake ()
		{
			channels = gameObject.AddComponent<ChannelGroup>();
			channels.SetPolyphony(patch.Polyphony, patch.useEnvelope);
			channels.masterVolume = patch.MasterVolume;
		}

		void Start ()
		{
		}

		protected override void OnMIDIMessage(MIDIMessage msg)
		{
			switch (msg.Type)
			{
				case MIDIMessage.MessageType.NoteOn:
				for (int i = 0; i < patch.Clips.Count; ++i)
				{
					int note = msg.intValue;
					Clip clip = patch.Clips[i];
					if ((note >= clip.ZoneStart) && (note <= clip.ZoneEnd))
					{
						float velocity = msg.floatValue;
						float amp = SamplerUtils.GetAmp(velocity, patch.velocitySensitivity);

						float pitch = SamplerUtils.SemitonesToRatio(msg.intValue, clip.RootNote);
						pitch = SamplerUtils.Randomize(pitch, patch.PitchRandomization);
						pitch = Mathf.Clamp(pitch, 0.1f, 10f);
						
						float pan = SamplerUtils.Randomize(0, Mathf.Clamp01(patch.PanRandomization));
						
						AudioClip audioclip = clip.clip;
						channels.NoteOn(note, audioclip, clip.volume, amp, pitch, pan, patch.Attack, patch.Release, clip.loop, clip.startAtRandomPosition);
						return;
					}
				}
				break;

				case MIDIMessage.MessageType.NoteOff:
				channels.NoteOff(msg.intValue, patch.Release);
				break;

			case MIDIMessage.MessageType.MasterVolume:
				channels.masterVolume = msg.floatValue;
				break;
				
			case MIDIMessage.MessageType.GlobalVolume:
				channels.globalVolume = msg.floatValue;
				break;
				
			case MIDIMessage.MessageType.Kill:
				channels.Kill();
				break;
				
			default:
				print ("Unknown MIDIMessageType");
				break;
			}
		}

	}

}

