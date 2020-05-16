using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Object = System.Object;

namespace AgathaGame
{
	[CustomEditor(typeof(Character))]
	public class CharacterEditor : Editor
	{
		private GUILayoutOption _descHeight = GUILayout.ExpandHeight(true);
		private GUILayoutOption _descHeightMin = GUILayout.MinHeight(200);

		private Character _char;

		void OnEnable()
		{
			_char = target as Character;
		}

		public override void OnInspectorGUI()
		{
			GUILayout.Label("Character");
			EditorGUILayout.BeginHorizontal();
			EditorGUIUtils.DrawImagePreview(_char.photo != null ? _char.photo.texture : null, new Vector2(150, 200));
			EditorGUILayout.BeginVertical();
			GUILayout.Label("Name:");
			_char.name = EditorGUILayout.TextField(_char.name);
			GUILayout.Label("Photo:");
			_char.photo = (Sprite) EditorGUILayout.ObjectField(_char.photo, typeof(Sprite), false);
			EditorGUILayout.EndVertical();
			EditorGUILayout.EndHorizontal();
			GUILayout.Label("Description:");
			_char.description = EditorGUILayout.TextArea(_char.description, _descHeight, _descHeightMin);
		}
	}
}