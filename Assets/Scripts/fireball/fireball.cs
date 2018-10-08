using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
	public castFireBall caster;
	public int damage;
	public float lifeTime;
	public Collider2D player;
	private float currentLife;
	public Vector3 speed;
	public bool flying;

	// Use this for initialization
	void Start () {
		currentLife = 0;
		flying = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(flying) {
			currentLife += Time.deltaTime;
			transform.position += speed;
		} else {
			// follow caster
			transform.position = caster.transform.position;
		}

		if( currentLife > lifeTime) {
			Destroy(this.gameObject);
			caster.fireBallDestroyed(this);
		}
	}

	
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "enemy")
		{
			print("hit!");
			Destroy(this.gameObject);
			caster.fireBallDestroyed(this);
		}
		
    }
}
