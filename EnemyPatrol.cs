using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	[HideInInspector] public float moveSpeed = 5;
	[HideInInspector] public bool movingRight = true;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	[HideInInspector] public bool hittingWall;

	public Transform edgeCheck;
	[HideInInspector] public bool atEdge;

	public Transform groundCheck;

	public Vector3 enemyScale;

	void Start() {
		enemyScale = transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		atEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || !atEdge) {
			movingRight = !movingRight;
		}

		if (movingRight) {
			transform.localScale = new Vector3(enemyScale.x, enemyScale.y, enemyScale.z);	// Make the sprite face right
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} 
		else {
			transform.localScale = new Vector3(-enemyScale.x, enemyScale.y, enemyScale.z);	// Make the sprite face left
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}
