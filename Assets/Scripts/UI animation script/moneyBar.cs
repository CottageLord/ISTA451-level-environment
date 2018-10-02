using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyBar : MonoBehaviour {
	public playerScript player;
	public Text moneyAmount;
	public coinRotate coin;

	public void changeMoney() {
		moneyAmount.text = "" + player.getMoney();
		coin.Rotate();
	}
}
