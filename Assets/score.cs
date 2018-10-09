using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
	public Text scoreAmount;
	public int enemyKilled;

	void Start() {
		enemyKilled = 0;
	}

	public void scoreUp() {
		enemyKilled++;
		scoreAmount.text = "" + enemyKilled + "/5";
	}
}
