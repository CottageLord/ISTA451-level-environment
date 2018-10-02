using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstep : MonoBehaviour {
	public playerScript player;
	public AudioClip[] clips;
	public AudioSource footstepsSource;
	public float footstepInterval = 0.5f;
	
	int lastFootstep = -1;

	public void Start() {
		StartCoroutine( PlayFootsteps() );
	}


	IEnumerator PlayFootsteps() {
		while( enabled ) {
			if(player.isWalking) {
				int randomFootstep = lastFootstep;
				while( randomFootstep == lastFootstep ) {
					randomFootstep = Random.Range( 0, clips.Length );
				}
				lastFootstep = randomFootstep;

				footstepsSource.clip = clips[randomFootstep];
				footstepsSource.Play();
			}
				yield return new WaitForSeconds( footstepInterval );
		}
	}
}
