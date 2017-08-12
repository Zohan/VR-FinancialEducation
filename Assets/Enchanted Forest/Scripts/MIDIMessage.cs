
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;

namespace AlpacaSound.EnchantedForest
{
	
	public class MIDIMessage
	{
		public MessageType Type;
		public int intValue;
		public float floatValue;

		public enum MessageType
		{
			NoteOn,
			NoteOff,
			MasterVolume,
			GlobalVolume,
			Kill,
		};

		public MIDIMessage(MessageType type)
		{
			Type = type;
		}

		public static MIDIMessage CreateNoteOnMessage(int noteNumber, float velocity)
		{
			MIDIMessage msg = new MIDIMessage(MessageType.NoteOn);
			msg.intValue = noteNumber;
			msg.floatValue = velocity;
			return msg;
		}
		
		public static MIDIMessage CreateNoteOffMessage(int noteNumber)
		{
			MIDIMessage msg = new MIDIMessage(MessageType.NoteOff);
			msg.intValue = noteNumber;
			return msg;
		}

		public static MIDIMessage CreateMasterVolumeMessage(float volume)
		{
			MIDIMessage msg = new MIDIMessage(MessageType.MasterVolume);
			msg.floatValue = volume;
			return msg;
		}
		
		public static MIDIMessage CreateGlobalVolumeMessage(float volume)
		{
			MIDIMessage msg = new MIDIMessage(MessageType.GlobalVolume);
			msg.floatValue = volume;
			return msg;
		}
		
		public static MIDIMessage CreateKillMessage()
		{
			MIDIMessage msg = new MIDIMessage(MessageType.Kill);
			return msg;
		}
		

		
	}
}
