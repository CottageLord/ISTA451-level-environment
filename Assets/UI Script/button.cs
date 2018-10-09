using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class button : MonoBehaviour, IPointerDownHandler {
    public int sceneNum;
	public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        if(name == "startBTN") {
        	SceneManager.LoadScene(sceneNum);
        } else {
        	Application.Quit();
        }
    }
}
