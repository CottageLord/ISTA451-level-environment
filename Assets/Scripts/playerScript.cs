using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class playerScript : MonoBehaviour {

	public float speed, jumpPower;
	public Rigidbody2D player;
	public healthBar healthBar;

	private float RayOffset = 0.5f;
	private float raycastMaxDistance = 100f;

	private int health;
	private int money;
	private int maxHealth = 10;

	float horiz;
	bool jump, canJump;
	int contace;

	// Use this for initialization
	void Start () {
		canJump = true;
		health = 10;
		money = 0;
	}

	public void takeDamage(int damage) {
		if(health <= 0) {
			print("You died.");
			return;
		}
		health -= damage;
		healthBar.changeHealth(-damage);
		// TODO: if died
	}

	public void getHealed(int heal) {

		if (health + heal > maxHealth) {
			heal = maxHealth - health;
			health = maxHealth;
		} else {
			health += heal;
		}
		healthBar.changeHealth(heal);
	}

	public int getHealth() {
		return health;
	}

	public int getMoney() {
		return money;
	}

	// Update is called once per frame
	void Update () {
		horiz = Input.GetAxis("Horizontal") * speed;
		jump = Input.GetButtonDown("Jump");
		if(castRay().distance < 0.1){
			canJump = true;
		} else {
			canJump = false;
		}
	}

	void FixedUpdate() {
		player.velocity = new Vector2 ( horiz, player.velocity.y );
		if (jump && canJump) {
			player.velocity = Vector3.up * jumpPower;
		}
	}

	private RaycastHit2D castRay() {
		Vector2 direction = new Vector2(0f, -1f);
		// update the raycast direction
		Vector2 startPoint = new Vector2(this.transform.position.x, this.transform.position.y - RayOffset);
		//Debug.DrawRay(startPoint, direction, Color.red);
		return Physics2D.Raycast(startPoint, direction, raycastMaxDistance);
	}
}
