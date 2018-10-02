using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToSlope : MonoBehaviour {

	public Transform transformToAlign;
	public Transform rayStart;
	public float maxDistanceToFloor;

	RaycastHit2D[] results = new RaycastHit2D[1];
	
	void Update () {

		if( Physics2D.RaycastNonAlloc( rayStart.position, -rayStart.up, results, maxDistanceToFloor, 1 << LayerMask.NameToLayer( "Environment" ) ) > 0 ) {
			transformToAlign.rotation = Quaternion.LookRotation( transformToAlign.forward, results[0].normal );
		}
		else {
			transformToAlign.rotation = Quaternion.LookRotation( transformToAlign.forward, Vector3.up );;
		}
	}
}
