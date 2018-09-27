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
		//Debug.Log("timeLeft" + timeLeft);

		if(timeLeft <= 0)
		{
			if(GameObject.Find("flare 1(Clone)"))
			{
				Debug.Log("found flare");
			}

			GameObject ball = GameObject.Find("ball");
			weapon wp = ball.GetComponent<weapon>();
			wp.numberBullets += 1;

			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		//Debug.Log(hitInfo.name);

		rb.velocity = Vector3.zero;
		//Destroy(gameObject);
	}


}
