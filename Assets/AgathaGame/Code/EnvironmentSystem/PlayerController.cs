using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Camera gameCamera;
	public UnityEngine.AI.NavMeshAgent agent;
	public Transform marker;

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			HandleClick();
		}
	}

	private void HandleClick()
	{
		Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out var hit, 1000f, 0x7FFFFFFF - LayerMask.NameToLayer("NavigationBase")))
		{
			var target = hit.point;
			
			var interact = hit.transform.GetComponent<InteractiveComponent>();
			if(interact!=null)
			{
				interact.HandleClick();
				target = interact.transform.position;
			}
			
			marker.transform.position = target;
			agent.SetDestination(target);
		}
	}
}
