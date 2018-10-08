using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class healthBarBTNTest : MonoBehaviour, IPointerDownHandler {
	public playerScript player;
	public int amount;
	
	public void OnPointerDown(PointerEventData pointerEventData)
    {
    	print(amount);
    	if(amount > 0) {
    		player.getHealed(amount);
    	} else {
    		player.takeDamage(-amount);
        }
    }
}
