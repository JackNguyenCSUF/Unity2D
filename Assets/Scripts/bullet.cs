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
		
		if(timeLeft <= 0)
		{

			GameObject ball = GameObject.Find("ball");
			weapon wp = ball.GetComponent<weapon>();
			wp.numberBullets += 1;

			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		//Debug.Log(hitInfo);
		if(hitInfo.name == "diamond" || hitInfo.name == "flare 1(Clone)")
		{
			//rb.velocity = Vector3.zero;
		}	
		else
		{
			rb.velocity = Vector3.zero;
		}
	}
		


}
