using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour {

	public float shakeAmount = 0.1f;
	public float shakeTime = 0.2f;
	private bool isShaking = false;

	private IEnumerator coroutine;
	private Vector2 originalPos;
	void Start() {
		originalPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (isShaking) {
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount + originalPos;
			transform.position = shakePos;
		}
	}

	public void Shake() {
		coroutine = ShakeNow();
		StartCoroutine(coroutine);
	}

	// use MonoBehaviour.StartCoroutine to make the target shakes for a while
	IEnumerator ShakeNow() {

		if (!isShaking) {
			isShaking = true;
		}

		yield return new WaitForSeconds(shakeTime);

		isShaking = false;
		transform.position = originalPos;
	}
}
