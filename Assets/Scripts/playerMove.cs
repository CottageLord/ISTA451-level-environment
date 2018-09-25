using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class playerMove : MonoBehaviour {
	public float speed, jumpPower;
	public Rigidbody2D player;
	private float RayOffset = 0.5f;
	private float raycastMaxDistance = 100f;
	float horiz;
	bool jump, canJump;
	int contace;

	// Use this for initialization
	void Start () {
		canJump = true;
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
	/*
	// "eat" the other object
	void OnTriggerEnter2D ( Collider2D other) {
		if ( other.gameObject.tag == "other") {

			other.gameObject.SetActive(false);
		} 
	}
	*/

	private RaycastHit2D castRay() {
		Vector2 direction = new Vector2(0f, -1f);
		// update the raycast direction
		Vector2 startPoint = new Vector2(this.transform.position.x, this.transform.position.y - RayOffset);
		Debug.DrawRay(startPoint, direction, Color.red);
		return Physics2D.Raycast(startPoint, direction, raycastMaxDistance);
	}
}
