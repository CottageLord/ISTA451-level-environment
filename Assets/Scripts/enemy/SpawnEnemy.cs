using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
	public playerScript player;
	public score scoreBoard;
	public int spawnInterval;
	public enemy enemy;
	public bool hasSpawned;

	public void enemyDead() {
		if(!hasSpawned) {
			StartCoroutine(spawnNew());
		}
	}

	IEnumerator spawnNew() {
		yield return new WaitForSeconds(spawnInterval);
		// spawn a new anemy
		enemy newStoneGiant = Instantiate(enemy, transform.position, 
			Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		// set all the field
		newStoneGiant.player = player;
		newStoneGiant.spawner = this;
		newStoneGiant.ScoreBoard = scoreBoard;
		// avoid crowded spawn point
		hasSpawned = true;
	}
}
