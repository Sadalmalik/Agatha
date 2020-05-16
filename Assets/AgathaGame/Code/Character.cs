using UnityEngine;

namespace AgathaGame
{
	[CreateAssetMenu(menuName = "Agatha Game/Character")]
	public class Character : ScriptableObject
	{
		public string name;
		public Sprite photo;
		public string description;
	}
}