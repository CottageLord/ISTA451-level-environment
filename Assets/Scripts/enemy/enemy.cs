﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public Rigidbody2D emeny;
	public playerScript player;
	public float speed;
	public float animationSpeed;
	public int damage;
	public int health;

	private int reward;
	private Vector2 move;
	private int trunAngle = 180;

	private float RayOffset = 2f;
	private float raycastMaxDistance = 100f;

	// Use this for initialization
	void Start () {
		reward = Random.Range(18, 26);
		move = new Vector2(-speed, 0f);
		gameObject.GetComponent<Animator>().speed = animationSpeed;	
	}
	
	// Update is called once per frame
	void Update () {
		emeny.velocity = move;
		if(!canKeepGoing(new Vector2(move.x, 0f))) {
			turnAround();
		}
	}

	private bool canKeepGoing(Vector2 direction) {
		
		// the raycast direction
		float directinalOffSet = RayOffset * (trunAngle == 0 ? 1 : -1);
		Vector2 startPoint = new Vector2(this.transform.position.x + directinalOffSet, 
			this.transform.position.y);
		// get the ray cast results
		Vector2 castDown = new Vector2 (0f, -1f);
		float distanceToWall = Physics2D.Raycast(startPoint, direction, raycastMaxDistance).distance;
		float distanceToGround = Physics2D.Raycast(startPoint, castDown, raycastMaxDistance).distance;
		
		return (distanceToWall > 0.1 && distanceToGround < 2);
	}

	void turnAround() {
		move = new Vector2(-move.x, 0f);
		transform.rotation = Quaternion.Euler(0, trunAngle, 0);
		if (trunAngle > 0) {
			trunAngle = 0;
		} else {
			trunAngle = 180;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "fireball")
		{
			health -= collision.gameObject.GetComponent<fireball>().damage;
			if (health <= 0) {
				player.earnMoney(reward);
				Destroy(emeny.gameObject);
			}
		}
    }

}
