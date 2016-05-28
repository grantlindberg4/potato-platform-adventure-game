using UnityEngine;
using System.Collections;

// This script is intended to handle events in which the player dies
// This includes falling off the level, running into enemies, etc.

public class KillPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			LivesManager.loseLife();	// Player loses one life

			// Change the Applicaton.LoadLevel to some kind of respawn function. It resets coins and enemies, but it shouldn't do that.

			StartCoroutine("Wait");
		}
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel);
	}
}
