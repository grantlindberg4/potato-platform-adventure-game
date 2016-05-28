using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {
	public float shotSpeed = 10;
	public PlayerController player;

	// Tests to see the direction in which the missile should be fired

	void Start() {
		player = FindObjectOfType<PlayerController>();
		if (player.transform.localScale.x < 0) {
			shotSpeed = -shotSpeed;
		}
	}
	
	// Missile moves in one direction the whole time

	void Update() {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (shotSpeed, GetComponent<Rigidbody2D> ().velocity.y);
	}

	// The missile is destroyed when it travels off-screen

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
