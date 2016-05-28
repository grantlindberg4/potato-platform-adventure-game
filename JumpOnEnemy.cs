using UnityEngine;
using System.Collections;

// This script kills an enemy if something hazardous collides with it

public class JumpOnEnemy : MonoBehaviour {

	public float bounceOnEnemy;
	
	private Rigidbody2D rb2d;

	void Start() {
		rb2d = transform.parent.GetComponent<Rigidbody2D> ();	// Find the parent (Player) and use its Rigidbody
	}

	void OnTriggerEnter2D(Collider2D other) {

		// Player bounced on his head

		if(other.gameObject.CompareTag("Enemy")) {
			Destroy(other.gameObject);
			rb2d.velocity = new Vector2 (rb2d.velocity.x, bounceOnEnemy);	// Make the player bounce up on contact
		}
	}
}
