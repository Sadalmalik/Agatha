using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Randomizer : MonoBehaviour
{
	public Vector3 randomizeRotation;
	public bool apply;

	void Start()
	{
		if (Application.isPlaying)
			Destroy(this);
	}

	void Update()
	{
		if (apply)
		{
			apply = false;
			Apply();
		}
	}

	private void Apply()
	{
		foreach (Transform child in transform)
		{
			child.localRotation = Quaternion.Euler(
					Random.Range(-randomizeRotation.x / 2, randomizeRotation.x / 2),
					Random.Range(-randomizeRotation.y / 2, randomizeRotation.y / 2),
					Random.Range(-randomizeRotation.z / 2, randomizeRotation.z / 2)
				);
		}
	}
}