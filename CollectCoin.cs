using UnityEngine;
using System.Collections;

public class CollectCoin : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			ScoreManager.updateScore(10);	// A coin is worth 10 points
			Destroy(gameObject);	// The coin disappears after it is collected
		}
	}

}
