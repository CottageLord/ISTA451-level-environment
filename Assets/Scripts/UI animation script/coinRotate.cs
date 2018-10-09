using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotate : MonoBehaviour {
	public float rotateScale;
	public float rotateTime;

	private Vector3 originalRotation;
	private Vector3 rotation;
	private bool rotating = false;

	private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
		rotation = new Vector3(0f, rotateScale, 0f);
		originalRotation = this.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if (rotating) {
			
			this.transform.eulerAngles += rotation;
		}
	}

	public void Rotate() {
		coroutine = RotateNow();
		StartCoroutine(coroutine);
	}

	// use MonoBehaviour.StartCoroutine to make the target shakes for a while
	IEnumerator RotateNow() {

		if (!rotating) {
			rotating = true;
		}

		yield return new WaitForSeconds(rotateTime);

		rotating = false;
		transform.eulerAngles = originalRotation;
	}
}
