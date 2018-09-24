using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour {

	public float speed = 0.1f;
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
		float velocityx = Input.GetAxis("Horizontal") * speed;
		float velocityy = Input.GetAxis("Vertical") * speed;

		Vector2 moveVector = new Vector2(velocityx,velocityy);

		rb2d.velocity = moveVector;

		rotate(moveVector);
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