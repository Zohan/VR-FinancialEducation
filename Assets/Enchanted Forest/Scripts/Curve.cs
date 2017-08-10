
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
	public class Curve
	{
		public List<Vector2> points;

		public float MapValue(float x)
		{
			x = Mathf.Clamp01(x);
			
			if (points.Count == 0)
			{
				return x;
			}
			
			if (points.Count == 1)
			{
				return points[0].y;
			}
			
			if (x <= points[0].x)
			{
				return points[0].y;
			}
			
			if (x >= points[points.Count-1].x)
			{
				return points[points.Count-1].y;
			}
			
			for (int i = 0; i < points.Count-1; ++i)
			{
				if (x >= points[i].x && x <= points[i+1].x)
				{
					float x1 = points[i].x;
					float y1 = points[i].y;
					float x2 = points[i+1].x;
					float y2 = points[i+1].y;
					
					float m = (y2-y1) / (x2-x1);
					float mapped = m * x - m * x1 + y1;
					
					return mapped;
				}
			}
			
			return 0;
		}
		

	}
}