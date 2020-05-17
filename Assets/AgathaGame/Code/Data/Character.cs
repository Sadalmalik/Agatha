using UnityEngine;

namespace AgathaGame
{
	[CreateAssetMenu(menuName = "Agatha Game/Character")]
	public class Character : ScriptableObject
	{
		public string Name;
		public Sprite Photo;
		public string Description;
	}
}