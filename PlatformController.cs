using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	public GameObject platform;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection = 1;

	// Start by heading towards the destination point

	void Start() {
		currentPoint = points [pointSelection];
	}

	// Always be moving towards some target location

	void Update() {
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

		if (platform.transform.position == currentPoint.position) {
			pointSelection++;

			if (pointSelection == points.Length) {
				pointSelection = 0;	// Reset the platform movement cycle
			}

			currentPoint = points[pointSelection];
		}
	}
}
