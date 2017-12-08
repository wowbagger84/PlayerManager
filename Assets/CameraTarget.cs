using UnityEngine;
struct CameraTarget
{
	public Transform target;
	[Range(0,1)]
	public float weight;
	public bool inView;

	public CameraTarget(Transform target, float weight = 1f)
	{
		this.target = target;
		this.weight = weight;
		inView = false;
	}

	public void InView(bool visible)
	{
		inView = visible;
	}
}
