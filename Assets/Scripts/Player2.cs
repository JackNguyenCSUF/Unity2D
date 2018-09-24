using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player2 : MonoBehaviour {

	public float speed = 1;
	private Rigidbody2D rb2d;
	
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		Physics2D.gravity = Vector2.zero;
	}
	 
	// Update is called once per frame
	void Update () 
	{
		//turn off gravity from object
		
		//check right movement along with up or down
		if (Input.GetKey(KeyCode.D))
        {
			if(Input.GetKey(KeyCode.E))
			{
				rb2d.velocity = new Vector2(2,2);
			}
			else if (Input.GetKey(KeyCode.C))
			{
				rb2d.velocity = new Vector2(2,-2);
			}
			else
			{
				rb2d.velocity = new Vector2(2,0);
			}
        }
		else if (Input.GetKey(KeyCode.A))
		{
			if(Input.GetKey(KeyCode.E))
			{
				rb2d.velocity = new Vector2(-2,2);
			}
			else if (Input.GetKey(KeyCode.C))
			{
				rb2d.velocity = new Vector2(-2,-2);
			}
			else
			{
				rb2d.velocity = new Vector2(-2,0);
			}
		}
		else if(Input.GetKey(KeyCode.E))
		{
			rb2d.velocity = new Vector2(0,2);
		}
		else if(Input.GetKey(KeyCode.C))
		{
			rb2d.velocity = new Vector2(0,-2);
		}
		else
		{
			rb2d.velocity = new Vector2(0,0);
		}
	}
}