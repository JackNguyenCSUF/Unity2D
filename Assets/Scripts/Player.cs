using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour {

	public float speed = 0.1f;
	private Rigidbody2D rb2d;
	public float velocityx;
	public float velocityy;
	
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		//Physics2D.gravity = Vector2.zero;
	}
	 
	// Update is called once per frame
	void Update () 
	{
		velocityx = Input.GetAxis("Horizontal") * speed;
		velocityy = Input.GetAxis("Vertical") * speed;

		Vector2 moveVector = new Vector2(velocityx,velocityy);
		
		rb2d.velocity = moveVector;

		//if(moveVector.x >= speed && moveVector.y >= speed)
		//{
			rotate(moveVector);
		//}

		
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