using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody2D rb;
	public float timeLeft = 5;
	public Flare flare;
	// Use this for initialization
	void Start () {
		rb.velocity = transform.up *  speed;	
	}

	void Update(){
		timeLeft -= Time.deltaTime;
		
		//start the 5 second countdown for each individual bullet fired, after 5 seconds object will be destroyed.
		if(timeLeft <= 0)
		{

			GameObject player1 = GameObject.Find("player1");
			weapon wp = player1.GetComponent<weapon>();
			wp.numberBullets += 1;

			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if(hitInfo.name == "beacon" || hitInfo.name == "flamegun" || hitInfo.name == "shield" || hitInfo.name == "landmine" || hitInfo.name == "flare 1(Clone)")
		{
			//if bullets collides with items or other bullets, let it pass through
		}	
		else
		{
			//if it hits an object set bullet speed to 0
			rb.velocity = Vector3.zero;
		}

		Debug.Log(hitInfo);
	}
		


}
