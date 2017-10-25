
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AlpacaSound.EnchantedForest
{
	public class MetaParameterDevice : MonoBehaviour
	{
		float m_parameter = 0.5f;
		public float parameter
		{
			set
			{
				if (value != m_parameter)
				{
					m_parameter = value;
					SendParameters();
				}
			}

			get
			{
				return m_parameter;
			}
		}

		public List<ParameterMap> maps;

		void Start ()
		{
			SendParameters();
		}

		void SendParameters()
		{
			for (int i = 0; i < maps.Count; i++)
			{
				ParameterMap map = maps[i];
				map.Send (parameter);
			}
		}
	}
}
