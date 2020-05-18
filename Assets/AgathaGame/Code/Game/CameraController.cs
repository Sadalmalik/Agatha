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

	public Transform cameraTarget;
	public Vector3 cameraOffset;
	[Range(0,20)]
	public float cameraDamping;

	[Header("Camera Zoom")]
	public ZoomType zoomType;

	public float zoomSensitivity;
	[Range(0,20)]
	public float zoomDamping;
	public float zoomMin;
	public float zoomMax;
	public float zoomTarget;
	
	private void Update()
	{
		//Mathf.MoveTowards()
		HandleZoom();
		HandlePosition();
	}

	private void HandleZoom()
	{
		float scroll = -Input.mouseScrollDelta.y;
		
		zoomTarget += scroll * zoomSensitivity;
		zoomTarget =  Mathf.Clamp(zoomTarget, zoomMin, zoomMax);
		var coef = 1 / (zoomDamping+1);
		
		switch (zoomType)
		{
			case ZoomType.Size:
				targetCamera.orthographicSize = Mathf.Lerp(targetCamera.orthographicSize, zoomTarget, coef);
				break;
			case ZoomType.Fov:
				targetCamera.fieldOfView = Mathf.Lerp(targetCamera.fieldOfView, zoomTarget, coef);
				break;
			case ZoomType.Distance:
				var pos = targetCamera.transform.localPosition;
				pos.z = Mathf.Lerp(pos.z, zoomTarget, coef);
				targetCamera.transform.localPosition = pos;
				break;
		}
	}

	private void HandlePosition()
	{
		var coef = 1 / (cameraDamping+1);
		cameraRoot.position = Vector3.Lerp(cameraRoot.position, cameraTarget.position + cameraOffset, coef);
	}
}