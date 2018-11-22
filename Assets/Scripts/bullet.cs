using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class bullet : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody2D rb;
	public float timeLeft = 5;

	private float x;
	private float y;

	//public Flare flare;
	// Use this for initialization
	void Start () {
		rb.velocity = transform.up *  speed;	
	}

	void Update(){
		timeLeft -= Time.deltaTime;	

		//get the velocity of the bullet
		float x = Math.Abs(rb.velocity.x);
		float y = Math.Abs(rb.velocity.y);
		
		//start the 5 second countdown for each individual bullet fired, after 5 seconds object will be destroyed.
		if(timeLeft <= 0)
		{

			GameObject player1 = GameObject.Find("player1");
			weapon wp = player1.GetComponent<weapon>();

						
			if(wp.numberBullets < 3){
				wp.numberBullets += 1;
			
			}

			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{	
		//Debug.Log(hitInfo.name);

		if(hitInfo.name == "beacon" || hitInfo.name == "flamegun" || hitInfo.name == "shield" || hitInfo.name == "landmine" || hitInfo.name == "newFlare(Clone)")
		{
			//if bullets collides with items or other bullets, let it pass through
		}	
		else
		{
			//if it hits an object set bullet speed to 0
			//Debug.Log(rb.velocity);
			rb.velocity = Vector3.zero;
		}

		if(hitInfo.name == "Fire"){
			//when the bullet makes contact with mine explosion get rid of it.
			Destroy(gameObject);
			GameObject player1 = GameObject.Find("player1");
			weapon wp = player1.GetComponent<weapon>();
			if(wp.numberBullets < 3){
				wp.numberBullets += 1;
			}
			
		}

		if(hitInfo.name == "player2"){
			GameObject player2 = GameObject.Find("player2");

			Player player2Stats = player2.GetComponent<Player>();

			if(player2Stats.shield == false){
				player2Stats.health -= 0.1f;
			}
			
			if(player2Stats.health <= 0){
				player2Stats.health = 1f;

				//increase player 1 score
				GameObject player1 = GameObject.Find("player1");
				Player player1Stats = player1.GetComponent<Player>();
				player1Stats.score += 1;

			}

			
			
		}
		
	}
}
