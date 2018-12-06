using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	// Comment
	public Transform target;
	public float smoothing = 2f;

	Vector3 offset;

	void Start() {
		// Comment
		offset = transform.position - target.position;
	}

	void FixedUpdate() {
		Vector3 targetCamPos = target.position + offset;
		// LERP smoothly moves between 2 positions
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
