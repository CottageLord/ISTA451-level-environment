using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
	public rule rule;
	public Sprite halfHeart;
	public Sprite emptyHeart;
	public Sprite fullHeart;
	public shake shaker;
	public floatAnimation floater;

	public Image[] hearts;
	private int[] health = {2, 2, 2, 2, 2};
	private int healthAmount = rule.playerHealthMaximum;
	private int heartAmount = rule.numberOfHealthBarHearts;
	private Image image;

	public void changeHealth(int amount) {
		
		if(amount < 0) {
			shaker.Shake();
		} else {
			floater.FloatUp();
		}
		// change the health
		healthAmount += amount;
		// bounds the health
		if(healthAmount <= 0) {
			healthAmount = 0;
		}

		if(healthAmount > rule.playerHealthMaximum) {
			healthAmount = rule.playerHealthMaximum;
		}

		// update the health bar, find the place that could be half heart
		// then update the rest
		int indexToChange = healthAmount / 2;
		int changeTo = healthAmount % 2;

		indexToChange = changeTo == 0 ? indexToChange - 1 : indexToChange;
		changeTo = changeTo == 0 ? 2 : 1;
		
		if (indexToChange < 0) {
			indexToChange = 0;
			health[indexToChange] = 0;
		} else {
			health[indexToChange] = changeTo;
		}
		
		for (int i = 0; i < indexToChange; i++) {
			health[i] = 2;
		}

		for (int i = indexToChange + 1; i < rule.numberOfHealthBarHearts; i++) {
			health[i] = 0;
		}
		
		updateHealthBar();
	}

	private void updateHealthBar() {
		for(int i = 0; i < heartAmount; i++) {
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