using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class button : MonoBehaviour, IPointerDownHandler {
	public load loader;
	public void OnPointerDown(PointerEventData pointerEventData)
    {
    	loader = new load();
        //Output the name of the GameObject that is being clicked
        if(name == "startBTN") {
        	loader.loadScene(1);
        }
    }
}
