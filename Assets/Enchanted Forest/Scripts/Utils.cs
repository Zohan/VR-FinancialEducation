
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;
using System;

namespace AlpacaSound.EnchantedForest
{

	public class Utils
	{
		public static bool DEBUG = false;

		public static string TimeInHours(float time)
		{
			DateTime dt = new DateTime();
			int secondsPerDay = 24 * 60 * 60;
			dt = dt.AddSeconds ((int) (secondsPerDay * time));
			return dt.ToShortTimeString();
		}

		public static void LogWarning(string message)
		{
			if (DEBUG)
			{
				Debug.LogWarning(message);
			}
		}


	}

}