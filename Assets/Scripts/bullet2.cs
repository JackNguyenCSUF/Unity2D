using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class bullet2 : MonoBehaviour {

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

			GameObject player2 = GameObject.Find("player2");
			weapon wp = player2.GetComponent<weapon>();

			GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        	GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();

			if(wp.numberBullets < settings.bullets){
				wp.numberBullets += 1;
			
			}
			

			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{	
		//Debug.Log(hitInfo.name);

		if(hitInfo.name == "beacon" || hitInfo.name == "flamegun" || hitInfo.name == "shield" || hitInfo.name == "landmine" || hitInfo.name == "newFlare(Clone)" || hitInfo.name == "newFlare 1(Clone)")
		{
			//if bullets collides with items or other bullets, let it pass through
		}	
		else
		{
			//if it hits an object set bullet speed to 0
			rb.velocity = Vector3.zero;
		}

		if(hitInfo.name == "Fire"){
			//when the bullet makes contact with mine explosion get rid of it.
			Destroy(gameObject);
			GameObject player2 = GameObject.Find("player2");
			weapon wp = player2.GetComponent<weapon>();

			GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        	GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();


			if(wp.numberBullets < settings.bullets){
				wp.numberBullets += 1;
			}
			
			
		}

		if(hitInfo.name == "player1"){
			GameObject player1 = GameObject.Find("player1");
			Player player1Stats = player1.GetComponent<Player>();
			
			if(player1Stats.shield == false){
				player1Stats.health -= 0.1f;
			}
			else if(player1Stats.shield){
				player1Stats.shield = false;
			}

			if(player1Stats.health <= 0){
				player1Stats.health = 1f;
				
				//increase player 1 score
				GameObject player2 = GameObject.Find("player2");
				Player player2Stats = player2.GetComponent<Player>();
				player2Stats.score += 1;

			}
			
		}		
	}
}
