using UnityEngine;
using System.Collections;

public class ShootEnemy : MonoBehaviour {

	// Shot by a missile

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Enemy")) {
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}
}
