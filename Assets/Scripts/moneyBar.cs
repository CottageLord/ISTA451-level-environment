using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyBar : MonoBehaviour {
	public playerScript player;
	public Text moneyAmount;

	public void changeMoney() {
		print("change money to: " + player.getMoney());
		moneyAmount.text = "" + player.getMoney();
	}
}
