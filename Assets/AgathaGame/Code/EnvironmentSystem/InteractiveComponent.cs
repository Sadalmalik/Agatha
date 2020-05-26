using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveComponent : MonoBehaviour
{
	public void HandleClick()
	{
		Debug.Log($"Click '{name}'");
	}
}
