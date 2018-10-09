using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour {
	public score scoreBoard;
	public Transform winningWindow;
	public Transform losingWindow;
	public int anountToWin;
	public Text info;

	// Use this for initialization
	void Start () {
		winningWindow.gameObject.SetActive(false);
		losingWindow.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreBoard.enemyKilled >= anountToWin) {
			Time.timeScale = 0;
			winningWindow.gameObject.SetActive(true);
		}
	}

	public void loseGame() {
		Time.timeScale = 0;
		losingWindow.gameObject.SetActive(true);
	}
}
