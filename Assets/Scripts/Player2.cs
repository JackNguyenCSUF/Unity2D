using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player2 : MonoBehaviour {

	public float speed = 0.1f;
	private Rigidbody2D rb2d;
	public float velocityx;
	public float velocityy;
	public int health;

	//create a list for storing items the player picks up
	public List<String> inventory;
	public GameObject[] item;
	
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		inventory = new List<String>();
		//Physics2D.gravity = Vector2.zero;
	}
	 
	// Update is called once per frame
	void Update () 
	{
		velocityx = Input.GetAxis("Horizontal") * speed;
		velocityy = Input.GetAxis("Vertical") * speed;

		Vector2 moveVector = new Vector2(velocityx,velocityy);
		
		rb2d.velocity = moveVector;

		//allow the character sprite to face the direction where you are walking towards
		rotate(moveVector);

		if(inventory.Count > 0)
		{
			activateItem(inventory[0]);		
		}
		
	}

	void activateItem(String name){

		//activate beacon on character
		if(name == "beacon")
		{
			GameObject go = Instantiate (item[0],rb2d.position, Quaternion.identity);
	  		go.transform.parent = gameObject.transform;
		}
		
		//need to finish code to activate other items
		
		inventory.RemoveAt(0);		
	}

	void rotate(Vector2 moveVector)
	{
		//Debug.Log(moveVector);
		if(moveVector != Vector2.zero)
		{
			transform.rotation = Quaternion.LookRotation(Vector3.forward,moveVector);
		}
		
	}
}