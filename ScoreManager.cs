using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public Text scoreText;

	public static int score;
	
	void Update () {

		// This just tests to make sure the score doesn't become negative

		if (score < 0) {
			score = 0;
		}

		scoreText.text = "" + score;
	}

	// Called when the player earns points

	public static void updateScore(int points) {
		score += points;
	}
}
