using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBattle : MonoBehaviour {

	public Collider2D player;
	private bool immune = false;

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "enemy")
		{
			if (!immune) {
				StartCoroutine(tempImmune(collision));
			}
		}
    }

    IEnumerator tempImmune(Collision2D collision) {
        immune = true;
        Collider2D enemy = collision.collider;

	    Physics2D.IgnoreCollision(enemy, player);

        yield return new WaitForSeconds(2);
        
        Physics2D.IgnoreCollision(enemy, player, false);
        immune = false;
    }
		
}
