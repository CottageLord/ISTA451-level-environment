using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onSlope : MonoBehaviour {
	public Rigidbody2D player;
	public playerScript playerStatus;
	private Vector3 PlayerPos;

	void Start () {
		PlayerPos = player.transform.position;
	}
	// Update is called once per frame
	void Update () {

		if (playerStatus.canJump && !playerStatus.isWalking) {
			player.transform.position = PlayerPos;
		} else {
			PlayerPos = player.transform.position;
		}
	}
}
