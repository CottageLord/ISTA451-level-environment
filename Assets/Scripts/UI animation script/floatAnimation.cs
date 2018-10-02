using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatAnimation : MonoBehaviour {

	public float floatScale;
	public float floatTime;

	private Vector3 originalSize;
	private Vector3 changeSize;
	private bool floating = false;

	private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
		changeSize = new Vector3(floatScale, floatScale, floatScale);
		originalSize = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (floating) {
			this.transform.localScale += changeSize;
		}
	}

	public void FloatUp() {
		coroutine = FloatNow();
		StartCoroutine(coroutine);
	}

	// use MonoBehaviour.StartCoroutine to make the target shakes for a while
	IEnumerator FloatNow() {

		if (!floating) {
			floating = true;
		}

		yield return new WaitForSeconds(floatTime);

		floating = false;
		transform.localScale = originalSize;
	}
}
