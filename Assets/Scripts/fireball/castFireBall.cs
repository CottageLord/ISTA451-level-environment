using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castFireBall : MonoBehaviour {
	public playerScript caster;
	public fireball fireBall;

	public int maxFireBalls;
	public List<fireball> fireballs = new List<fireball>();
	fireball newFireBall;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			if(fireballs.Count > maxFireBalls) return;

			newFireBall = Instantiate<fireball>(fireBall);

			fireballs.Add( newFireBall );
			newFireBall.caster = this;
		}
		
		if(Input.GetButtonUp("Fire1") && newFireBall != null) {
			if(caster.trunAngle == 0){
				newFireBall.speed = new Vector3(0.1f, 0f, 0f);
			} else {
				newFireBall.speed = new Vector3(-0.1f, 0f, 0f);
			}
			newFireBall.flying = true;
		}
	}

	public void fireBallDestroyed( fireball diedFireBall ) {
		fireballs.Remove( diedFireBall );
	}
}
