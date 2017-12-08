using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour {

	public float minZoom;
	public float maxZoom;
	public float zoomSpeed;
	public float xBound;
	public float yBound;
	public bool debug;

	List<CameraTarget> cameraTargets = new List<CameraTarget>();
	private Vector3 target;
	private float distance;
	private Camera localCamera;
	private int zoomIn;
	private bool zoomOut;

	// Use this for initialization
	void Start () {
		distance = maxZoom;
		localCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(cameraTargets.Count != 0)
		{
			target = Vector3.zero;
			zoomIn = 0;
			zoomOut = false;
			foreach (var cameraTarget in cameraTargets)
			{
				if (cameraTarget.target == null)
				{
					cameraTargets.Remove(cameraTarget);
					continue;
				}

				Vector3 screenPosition = localCamera.WorldToViewportPoint(cameraTarget.target.position);
				if (screenPosition.x > 1 - xBound || screenPosition.x < xBound || screenPosition.y > 1 - yBound || screenPosition.y < yBound)
				{
					zoomOut = true;
				}
				else if(screenPosition.x < 1 - xBound * 1.1 && screenPosition.x > xBound*1.1 && screenPosition.y < 1 - yBound * 1.1 && screenPosition.y > yBound * 1.1)
				{
					zoomIn++;
				}
				
				//TODO: Implement camera weight.

				target += cameraTarget.target.position;
			}

			
			
			if (zoomOut)
				distance += Time.deltaTime * zoomSpeed;
			else if (zoomIn == cameraTargets.Count)
				distance -= Time.deltaTime * zoomSpeed;




			if (cameraTargets.Count >= 2)
				target /= cameraTargets.Count;



			//TODO: add soft transition of camera.

			transform.position = target - transform.forward * Mathf.Clamp(distance, minZoom, maxZoom);
		}
	}

	public void AddCameraTarget(Transform target, float weight = 1f)
	{
		cameraTargets.Add(new CameraTarget(target, weight));
	}

	private void OnDrawGizmos()
	{
		if (debug)
		{
			Gizmos.color = new Color(1, 0, 0, 0.5f);
			Gizmos.DrawSphere(target, 0.5f);
		}
	}
}
