using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZoomType
{
	Size,
	Fov,
	Distance
}

public class CameraController : MonoBehaviour
{
	public Camera targetCamera;

	[Header("Camera View")]
	public Transform cameraRoot;

	public Transform target;
	public Vector3 offset;
	public float damping;

	[Header("Camera Zoom")]
	public ZoomType type;

	public float sensitivity;
	public float minZoom;
	public float maxZoom;

	private void Update()
	{
		print("m3 " + Input.GetAxis("Mouse ScrollWheel"));
		HandleZoom();
		HandlePosition();
	}

	private void HandleZoom()
	{
		float zoom;
		float scroll = -Input.mouseScrollDelta.y;

		switch (type)
		{
			case ZoomType.Size:
				zoom = targetCamera.orthographicSize;

				zoom += scroll * sensitivity;
				zoom =  Mathf.Clamp(zoom, minZoom, maxZoom);

				targetCamera.orthographicSize = zoom;
				break;
			case ZoomType.Fov:
				zoom = targetCamera.fieldOfView;

				zoom += scroll * sensitivity;
				zoom =  Mathf.Clamp(zoom, minZoom, maxZoom);

				targetCamera.fieldOfView = zoom;
				break;
			case ZoomType.Distance:
				var pos = targetCamera.transform.localPosition;

				pos.z += scroll * sensitivity;
				pos.z =  Mathf.Clamp(pos.z, minZoom, maxZoom);

				targetCamera.transform.localPosition = pos;
				break;
		}
	}

	private void HandlePosition()
	{
		cameraRoot.position = Vector3.Lerp(cameraRoot.position, target.position + offset, damping);
	}
}