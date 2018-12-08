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
	public AudioClip bulletSound;

	void Start () {
		rb.velocity = transform.up *  speed;	

		GetComponent<AudioSource> ().playOnAwake = true;


		GetComponent<AudioSource> ().clip = bulletSound;

		GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        


		AudioSource asource = GetComponent<AudioSource>();
        asource.volume = settings.volume / 3f;

		AudioSource.PlayClipAtPoint(bulletSound, transform.position, settings.volume);

		//GetComponent<AudioSource> ().Play();
		
	}

	void Update(){
		timeLeft -= Time.deltaTime;	
		
		//get the velocity of the bullet
		//float x = Math.Abs(rb.velocity.x);
		//float y = Math.Abs(rb.velocity.y);
		
		//start the 5 second countdown for each individual bullet fired, after 5 seconds object will be destroyed.
		if(timeLeft <= 0)
		{

			GameObject player1 = GameObject.Find("player1");
			weapon wp = player1.GetComponent<weapon>();

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
			//Debug.Log(rb.velocity);
			rb.velocity = Vector3.zero;
		}

		if(hitInfo.name == "Fire"){
			//when the bullet makes contact with mine explosion get rid of it.
			Destroy(gameObject);
			GameObject player1 = GameObject.Find("player1");
			weapon wp = player1.GetComponent<weapon>();

			GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        	GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();

			if(wp.numberBullets < settings.bullets){
				wp.numberBullets += 1;
			}
			
		}
	}
}
