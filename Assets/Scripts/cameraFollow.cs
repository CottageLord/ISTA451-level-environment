using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public Transform target;
	public float speed;
	public int cameraScope;

	// run right after the Update()
	void LateUpdate() {
		transform.position = new Vector3(target.position.x, 
			target.position.y, target.position.z - cameraScope);
	}
}
