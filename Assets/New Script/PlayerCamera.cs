using UnityEngine;
using System.Collections;
/// <summary>
/// Only issue is getting more smoothness
/// camera is gonna be attached with GUI scripts (so the GUI moves with the player) 
/// </summary>
public class PlayerCamera : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
		target = GameObject.Find ("Player").transform;
	}


	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

	}


}
