using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCaster : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, 10000f);
		print(hit.collider);
	}
}
