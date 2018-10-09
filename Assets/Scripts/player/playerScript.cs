using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
	public float speed, jumpPower;
	public Rigidbody2D player;
	public healthBar healthBar;
	public moneyBar moneyBar;
	public bool isWalking;
	public win winningWindow;

	public RaycastHit2D raycast;

	private Animator[] animator;
	private float RayOffset = 0.5f;
	private float raycastMaxDistance = 100f;

	public float onGroundOffset;
	public int trunAngle = 180;
	private int health;
	private int money;
	private int maxHealth = 10;

	private float horiz;
	public bool jump, canJump;
	private int contace;

	// Use this for initialization
	void Start () {
		animator = GetComponents<Animator>();
		isWalking = false;
		canJump = true;
		health = 10;
		money = 0;
	}

	public void earnMoney(int amount) {
		money += amount;
		moneyBar.changeMoney();
	}
	// called by button (for now)
	// notify health bar
	public void takeDamage(int damage) {
		health -= damage;
		if(health <= 0) {
			health = 0;
			winningWindow.loseGame();
		}
		healthBar.changeHealth(-damage);
	}

	// called by button (for now)
	// notify health bar
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

	
		// animation stand <-> walk
		if(horiz == 0) {
			isWalking = false;
			animator[0].SetFloat("mode", 1f);
		} else {
			isWalking = true;
			animator[0].SetFloat("mode", 0f);
		}
		// turn around by controller
		if (horiz < 0) {
			trunAngle = 180;
			turnAround();
		} else if (horiz > 0) {
			trunAngle = 0;
			turnAround();
		}

		jump = Input.GetButtonDown("Jump");
		raycast = castRay();
		if(raycast.distance < onGroundOffset){
			canJump = true;
			animator[0].SetBool("grounded", true);
		} else {
			canJump = false;
			isWalking = false;
			animator[0].SetBool("grounded", false);
		}
	}

	void FixedUpdate() {
		player.velocity = new Vector2 ( horiz, player.velocity.y );
		if (jump && canJump) {
			player.velocity = Vector3.up * jumpPower;
		}
	}

	// can not jump in the air
	private RaycastHit2D castRay() {
		Vector2 direction = new Vector2(0f, -1f);
		// update the raycast direction
		Vector2 startPoint = new Vector2(this.transform.position.x, this.transform.position.y - RayOffset);
		//Debug.DrawRay(startPoint, direction, Color.red);
		return Physics2D.Raycast(startPoint, direction, raycastMaxDistance);
	}

	void turnAround() {
		transform.rotation = Quaternion.Euler(0, trunAngle, 0);
	}
}

