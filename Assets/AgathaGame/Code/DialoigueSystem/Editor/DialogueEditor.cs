using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Object = System.Object;

namespace AgathaGame
{
	public enum CharacterExample
	{
		Персонаж1,
		Персонаж2,
		Персонаж3
	}

	public class Record
	{
		public string tag;
		public bool isText;
		public CharacterExample character;
		public string text;
		public string comment;
	}

	[CustomEditor(typeof(Dialogue))]
	public class DialogueEditor : Editor
	{
		private Dialogue _dialogue;

		private Record[] _records;

		void OnEnable()
		{
			_dialogue = target as Dialogue;
			_records  = new Record[12];
			for (int i = 0; i < 12; i++)
				_records[i] = new Record();
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.LabelField("A1");
			DrawTable(_records);
			EditorGUILayout.Space(50, true);
			DrawDefaultInspector();
		}

		private void DrawTable(Record[] records)
		{
			EditorGUILayout.BeginVertical("HelpBox");
			foreach (var rec in records)
				DrawRecord(rec);
			EditorGUILayout.EndVertical();
		}

		private void DrawRecord(Record rec)
		{
			EditorGUILayout.BeginHorizontal();
			var width = GUILayout.Width(120);
			rec.tag = GUILayout.TextField(rec.tag, width);
			if (string.IsNullOrEmpty(rec.tag))
			{
				GUILayout.Space(123);
			}
			else
			{
				if (GUILayout.Button(rec.isText ? "TEXT" : "CHOICE", width))
					rec.isText = !rec.isText;
			}

			rec.character = (CharacterExample) EditorGUILayout.EnumPopup(rec.character, width);
			rec.text      = EditorGUILayout.TextArea(rec.text);
			EditorGUILayout.TextField(rec.text?.Length.ToString() ?? "-", width);
			EditorGUILayout.EndHorizontal();
		}
	}
}