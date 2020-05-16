using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Object = System.Object;

namespace AgathaGame
{
	[CustomEditor(typeof(Character))]
	public class DialogueEditor : Editor
	{
		private Character _char;

		void OnEnable()
		{
			_char = target as Character;
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
		}
	}
}