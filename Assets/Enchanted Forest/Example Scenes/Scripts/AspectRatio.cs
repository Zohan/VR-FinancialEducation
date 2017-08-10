
//
// Interactive Audio: Enchanted Forest
// Copyright © 2014 Alpaca Sound
//

using UnityEngine;
using System.Collections;

namespace AlpacaSound
{

	public class AspectRatio : MonoBehaviour
	{
		public float width = 800;
		public float height = 500;

		void Update ()
		{
			float aspect = width / height;

			float screenHeight = Screen.height;
			float screenWidth = Screen.width;

			float actualHeight = screenHeight;
			float wantedHeight = screenWidth / aspect;

			float heightScale = wantedHeight / actualHeight;

			transform.localScale = new Vector3(1, heightScale, 1);
		}
	}

}

