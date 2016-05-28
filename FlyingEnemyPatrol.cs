using UnityEngine;
using System.Collections;

public class FlyingEnemyPatrol : MonoBehaviour {

	[HideInInspector] public float moveSpeed = 5;
	[HideInInspector] public bool movingRight = true;

	[HideInInspector] private Rigidbody2D rb2d;
	[HideInInspector] public Vector3 enemyScale;
	[HideInInspector] private float counter = 0;
	[HideInInspector] private float time = 0;
	[HideInInspector] private bool incrTime = true;

	void Start() {
		enemyScale = transform.localScale;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(incrTime) {
			time += Time.deltaTime;
		}
		else {
			time -= Time.deltaTime;
		}

		if(time >= 300) {
			incrTime = false;
		}

		if(time <= -200) {
			incrTime = true;
		}

		counter += Time.deltaTime;

		if (counter > 6) {
			movingRight = !movingRight;	// Change direction of travel
			counter = 0;
		}

		// Actual movement occurs here

		if (movingRight) {
			transform.localScale = new Vector3(enemyScale.x, enemyScale.y, enemyScale.z);	// Make the sprite face right
			rb2d.velocity = new Vector2 (moveSpeed, Mathf.Sin(2 * Mathf.PI * time));
		} 
		else {
			transform.localScale = new Vector3(-enemyScale.x, enemyScale.y, enemyScale.z);	// Make the sprite face left
			rb2d.velocity = new Vector2(-moveSpeed, Mathf.Sin(2 * Mathf.PI * time));
		}
	}
}
