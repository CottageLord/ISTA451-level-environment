using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour {
	public Transform menu;
	private bool paused = false;
	// Use this for initialization
	void Start () {
		menu.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Cancel")) {
			if(paused) {

				Time.timeScale = 1;
				menu.gameObject.SetActive(false);
			}
			else {
				
				Time.timeScale = 0;
				menu.gameObject.SetActive(true);
			}
			paused = !paused;
		}
	}
}
