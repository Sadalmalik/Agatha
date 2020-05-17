using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Object = System.Object;

namespace AgathaGame
{
	[CustomEditor(typeof(Dialogue))]
	public class DialogueEditor : Editor
	{
		private Dialogue _dialogue;

		void OnEnable()
		{
			_dialogue = target as Dialogue;
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.LabelField("A1");
			EditorGUILayout.Space(50, true);
			DrawDefaultInspector();
		}
	}
}