using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesManager : MonoBehaviour {
	public Text livesText;	

	public static int lives = 3;

//	// Use this for initialization
//	void Start () {
//		lives = 3;
//	}
	
	// Update is called once per frame
	void Update () {
		livesText.text = "" + lives;

		// If we lose all our lives, exit the game

		if (lives <= 0) {
			Application.Quit();
		}
	}

	// Called when the player dies

	public static void loseLife() {
		lives--;
	}
}
