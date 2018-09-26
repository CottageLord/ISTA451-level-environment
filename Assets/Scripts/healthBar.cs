using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
	public Sprite halfHeart;
	public Sprite emptyHeart;
	public Sprite fullHeart;

	public Image[] hearts;
	private int[] health = {2, 2, 2, 2, 2};
	private int heartAmount = 5;
	private Image image;

	public void changeHealth(int amount) {
		// the amount of health change each time
		// damage = -1, heal = 1
		int changeAmount = amount > 0 ? 1 : -1;
		// find the right most heart that have health
		int i = 4;
		while(i >= 0) {
			if(health[i] != 0) {
				break;
			}
			i--;
		}
		if(i < 0) {
			i = 0;
		}
		print("The nonempty heart is at: " + i);
		while(amount != 0 && i >= 0 && i <= 4) {
			amount -= changeAmount;
			health[i] += changeAmount;
			if(health[i] <= 0) {
				if(i > 0) {
					i--;
				} else {
					i = 0;
					break;
				}
			} else if(health[i] > 2) {
				health[i] = 2;
				health[i + 1] += changeAmount;
				i++;
			}
		}
		updateHealthBar();
	}

	private void updateHealthBar() {
		print("current health: [");
		for(int i = 0; i < heartAmount; i++) {
			print("[" + health[i] + "]");
			changeTexture(hearts[i], health[i]);
		}
	}

	// 0 for empty, 1 for half, 2 for full
	private void changeTexture(Image imageComponent, int mode) {
		switch(mode){
			case 0:
				imageComponent.sprite = emptyHeart;
				break;
			case 1:
				imageComponent.sprite = halfHeart;
				break;
			case 2:
				imageComponent.sprite = fullHeart;
				break;
		}
	}
}
