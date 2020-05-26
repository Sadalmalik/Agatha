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
			EditorGUIUtils.DrawImagePreview(_char.Photo != null ? _char.Photo.texture : null, new Vector2(150, 200));
			EditorGUILayout.BeginVertical();
			GUILayout.Label("Name:");
			_char.Name = EditorGUILayout.TextField(_char.Name);
			GUILayout.Label("Photo:");
			_char.Photo = (Sprite) EditorGUILayout.ObjectField(_char.Photo, typeof(Sprite), false);
			EditorGUILayout.EndVertical();
			EditorGUILayout.EndHorizontal();
			GUILayout.Label("Description:");
			_char.Description = EditorGUILayout.TextArea(_char.Description, _descHeight, _descHeightMin);
		}
	}
}