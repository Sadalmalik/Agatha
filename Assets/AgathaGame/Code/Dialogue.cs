using System;
using System.Collections.Generic;
using UnityEngine;

namespace AgathaGame
{
	[Serializable]
	public class Speech
	{
		public Character character;
		public string text;
	}

	[Serializable]
	public class Choice
	{
		public string text;
		public Dialogue target;
	}

	[CreateAssetMenu(menuName = "Agatha Game/Dialogue")]
	public class Dialogue : ScriptableObject
	{
		public string name;
		public Speech[] lines;
		public Choice[] choices;
	}
}