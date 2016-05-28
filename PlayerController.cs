using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// Setting up the player
	
	private Animator anim;
	private Rigidbody2D rb2d;

	[HideInInspector] public bool facingRight = true;
	public float moveSpeed;
	[HideInInspector] public float moveVelocity;
	public float jumpPower;
	[HideInInspector] public float fireDelay = 0f;

	// Shooting

	public Transform firePoint;
	public GameObject Missile;

	// Jumping

	[HideInInspector] private int numberOfJumps = 0;
	public Transform groundCheck;
	private bool grounded = false;
	private bool canJump = false;

	// Climbing

	public bool onLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	// Applies sprite components to player at beginning of game

	void Start() {
		anim = gameObject.GetComponent<Animator>();
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		rb2d.velocity = Vector2.zero;	// When the player is created, we don't want him to move
		gravityStore = rb2d.gravityScale;
	}
	
	// Update is called once per frame

	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		canJump = grounded || numberOfJumps < 1;
		moveVelocity = 0f;	// In every update, the player will not be moving

		// Used for making the player jump

		if (Input.GetKeyDown(KeyCode.W)) {
//			Debug.Log(string.Format("canJump = {0}", canJump));
//			Debug.Log(string.Format("grounded = {0}", grounded));
//			Debug.Log(string.Format("numberOfJumps = {0}", numberOfJumps));

			if(canJump) {
				Jump();
			}
		}

		if(grounded) {
			numberOfJumps = 0;
		}

		if (fireDelay > 0) {	// Do we still have delay before we can shoot?
			fireDelay--;
		}

		else {
			fireDelay = 0;	// We don't have to wait any longer to shoot
		}

		// Used for firing a missile

		if (Input.GetKeyDown(KeyCode.Space) && fireDelay == 0) {
			Instantiate (Missile, firePoint.position, firePoint.rotation);	// Fire a missile
			fireDelay = 50;	// Reset the fire delay
		}

		// Move right

		if(Input.GetKey(KeyCode.D)) {
			moveVelocity = moveSpeed;
		}

		// Move left

		if(Input.GetKey(KeyCode.A)) {
			moveVelocity = -moveSpeed;
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit ();
		}

		if (onLadder) {
			rb2d.gravityScale = 0f;
			climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
			rb2d.velocity = new Vector2(rb2d.velocity.x, climbVelocity);
		}

		if (!onLadder) {
			rb2d.gravityScale = gravityStore;

		}

		rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y); 
	}
	
	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (h));

		// Change the direction the character faces

		if (h > 0 && !facingRight) {
			Flip ();
		}
		else if (h < 0 && facingRight) {
			Flip ();
		}
	}

	// This function makes the player jump

	public void Jump() {
		anim.SetTrigger("Jump");
		rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
		numberOfJumps++;
	}

	// Change the way our character faces

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	// Things that occur when player collides with other objects. Coins, death, and enemy collision goes here

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			grounded = true;
		}

		// The player is in contact with the platform. Make him stay there.

		if (other.transform.parent.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}

		// If the finish line is touched, move to the next level

		if (other.transform.tag == "Finish") {
			Application.Quit();
		}
	}

	void OnCollisionExit2D(Collision2D other) {

		if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			grounded = false;
		}

		// The player is now off the platform. Make him independent from its movement.

		if (other.transform.parent.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}
}
