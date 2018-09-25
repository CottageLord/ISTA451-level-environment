using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float speed;
	private Vector3 move;
	private int trunAngle = 180;

	private float RayOffset = 2f;
	private float raycastMaxDistance = 100f;
	// Use this for initialization
	void Start () {
		move = new Vector3(-speed, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		// move the arrow
		this.transform.position += move * Time.deltaTime;
		if(castRay(new Vector2(move.x, 0f)).distance < 0.1){
			turnAround();
		}
	}

	private RaycastHit2D castRay(Vector2 direction) {
		// update the raycast direction
		float directinalOffSet = RayOffset * (trunAngle == 0 ? 1 : -1);
		Vector2 startPoint = new Vector2(this.transform.position.x + directinalOffSet, this.transform.position.y);
		//Debug.DrawRay(startPoint, direction, Color.red);
		return Physics2D.Raycast(startPoint, direction, raycastMaxDistance);
	}

	void turnAround() {
		move = -move;
		transform.rotation = Quaternion.Euler(0, trunAngle, 0);
		if (trunAngle > 0) {
			trunAngle = 0;
		} else {
			trunAngle = 180;
		}
	}

}
