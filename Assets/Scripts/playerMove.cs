using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class playerMove : MonoBehaviour {
	public float speed, jumpPower;
	public Rigidbody2D player;
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

	void OnCollisionStay2D ( Collision2D impact ) {
		
		if(impact.gameObject.tag == "wall") {
			canJump = false;
		} else {
			canJump = true;
		}
		
	}

	void OnCollisionExit2D ( Collision2D impact ) {
		canJump = false;
	}
}
