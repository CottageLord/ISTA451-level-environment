using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moneyBarBTNTest : MonoBehaviour, IPointerDownHandler{
	public playerScript player;
	public int amount;
	public void OnPointerDown(PointerEventData pointerEventData)
    {
    	player.earnMoney(amount);
    }
}
