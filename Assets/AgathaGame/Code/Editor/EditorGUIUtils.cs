using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public static class EditorGUIUtils
{
	private static GUIStyle _boldText;
	private static GUILayoutOption _minWidth = GUILayout.MinWidth(150);

	private static GUIStyle boldText
	{
		get
		{
			if (_boldText == null)
			{
				_boldText           = new GUIStyle(GUI.skin.label);
				_boldText.fontStyle = FontStyle.Bold;
			}

			return _boldText;
		}
	}

	public static void DrawItemsList<T>(string header, Func<int, T, bool> draw, ref T[] list, string newLabel = "New",
	                                    int spaces = 0)
		where T : class, new()
	{
		GUILayout.Label(header, boldText);
		if (list == null)
			list = new T[0];

		T toRemove = null;
		for (int i = 0; i < list.Length; i++)
		{
			if (i > 0 && spaces > 0)
				EditorGUILayout.Space(spaces);
			if (draw(i, list[i]))
				toRemove = list[i];
		}

		if (toRemove != null)
		{
			var temp = list.ToList();
			temp.Remove(toRemove);
			list = temp.ToArray();
		}

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (GUILayout.Button(newLabel, _minWidth))
		{
			var temp = list.ToList();
			temp.Add(new T());
			list = temp.ToArray();
		}

		GUILayout.EndHorizontal();
	}

	public static void DrawLine(int padding = 10, int height = 1)
	{
		EditorGUILayout.Space(padding);
		Rect rect = EditorGUILayout.GetControlRect(false, height);
		rect.height = height;
		EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
		EditorGUILayout.Space(padding);
	}

	public static string ItemField(string item, string[] items)
	{
		var idx = Array.IndexOf(items, item);
		idx = EditorGUILayout.Popup(idx, items);
		return 0 <= idx && idx < items.Length ? items[idx] : item;
	}

	public static string ItemField(string label, string item, string[] items)
	{
		var idx = Array.IndexOf(items, item);
		idx = EditorGUILayout.Popup(label, idx, items);
		return 0 <= idx && idx < items.Length ? items[idx] : item;
	}

	public static void CollectDraggeble<T>(Rect rect, Action<List<T>> handler) where T : Object
	{
		if (!rect.Contains(Event.current.mousePosition))
			return;

		if (Event.current.type == EventType.DragUpdated)
		{
			DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
			Event.current.Use();
		}

		if (Event.current.type == EventType.DragExited)
		{
			var list = new List<T>();

			for (int i = 0; i < DragAndDrop.objectReferences.Length; i++)
			{
				T obj = DragAndDrop.objectReferences[i] as T;
				if (obj == null) continue;
				list.Add(obj);
			}

			Event.current.Use();
			handler(list);
		}
	}

	public static void CollectDraggebleComponent<T>(Rect rect, Action<List<T>> handler) where T : Component
	{
		if (Event.current.type == EventType.Used)
			return;

		if (!rect.Contains(Event.current.mousePosition))
			return;

		if (Event.current.type == EventType.DragUpdated)
		{
			DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
			Event.current.Use();
		}

		if (Event.current.type == EventType.DragExited)
		{
			var list = new List<T>();

			for (int i = 0; i < DragAndDrop.objectReferences.Length; i++)
			{
				GameObject gameObject = DragAndDrop.objectReferences[i] as GameObject;
				if (gameObject == null) continue;
				T component = gameObject.GetComponent<T>();
				if (component == null) continue;
				list.Add(component);
			}

			Event.current.Use();
			handler(list);
		}
	}


	public static void DrawImagePreview(Texture2D image, Vector2 size,
	                                    Color? borderColor = null,
	                                    Vector4? borderSizes = null)
	{
		var rect = EditorGUILayout.GetControlRect(false, size.y, GUILayout.Width(size.x));
		EditorGUI.DrawRect(rect, borderColor.HasValue ? borderColor.Value : Color.gray);
		var offsets = borderSizes.HasValue ? borderSizes.Value : new Vector4(2, 2, 2, 2);
		rect.x      += offsets[0];
		rect.y      += offsets[1];
		rect.width  -= offsets[0] + offsets[2];
		rect.height -= offsets[1] + offsets[3];
		if (image != null)
			EditorGUI.DrawPreviewTexture(rect, image);
		else
			EditorGUI.DrawRect(rect, Color.black);
	}
}