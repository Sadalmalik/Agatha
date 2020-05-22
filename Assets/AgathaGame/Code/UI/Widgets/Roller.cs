using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AgathaGame.UI
{
	public class Roller : MonoBehaviour
	{
		public RectTransform ringTrans;
		public Image ringImage;
		public float speed;
		public float aspect;

		void Update()
		{
			var angle = (Time.time * speed) % 720 - 360;
			
			if (angle > 0)
			{
				ringImage.fillClockwise = true;
				ringImage.fillAmount    = angle / 360;
			}
			else
			{
				ringImage.fillClockwise = false;
				ringImage.fillAmount    = -angle / 360;
			}
			
			ringTrans.localRotation = Quaternion.Euler(0, 0, angle * aspect);
		}
	}
}