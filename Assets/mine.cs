using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour {

	public Rigidbody2D rb;
	
	public GameObject explosionPrefab;

	public float speed = 0f;
	public float timeLeft = 5;
	
	// Use this for initialization
	void Start () {
		//rb.velocity = transform.up *  speed;	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		//start the 5 second countdown for each individual mine placed, after 5 seconds object will be destroyed.
		/*
		if(timeLeft <= 0)
		{
			GameObject player1 = GameObject.Find("player1");
			weapon wp = player1.GetComponent<weapon>();
			//wp.numberMines += 1;

			
		}
		*/	
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{	
		//Debug.Log("HELLO");
		//explode on contact with any rigidbody
		if (hitInfo){
			//Debug.Log(hitInfo.name);
			
			//get rid of mine sprite
			Destroy(gameObject);

			//create explosion prefab
			Instantiate(explosionPrefab,rb.transform.position,rb.transform.rotation);
			
		}
		
	}
}
