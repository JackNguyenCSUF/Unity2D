using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour {

	public float speed = 0.1f;
	private Rigidbody2D rb2d;

	public GameObject player;

	public GameObject go;

	public float velocityx;
	public float velocityy;
	public float health = 1f;

	public int score = 0;

	public int lives;

	public bool shield = false;

	//create a list for storing items the player picks up
	public List<String> inventory;
	public GameObject[] item;
	
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		inventory = new List<String>();
		//Physics2D.gravity = Vector2.zero;

		GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
		Debug.Log("start weapon");

		weapon playerWeapon = player.GetComponent<weapon>();
		playerWeapon.numberBullets = settings.bullets;

		lives = settings.player_lives;
	

	}
	 
	// Update is called once per frame
	void Update () 
	{
		
		if(player.name == "player1"){
			velocityx = Input.GetAxis("p1_Horizontal") * speed;
			velocityy = Input.GetAxis("p1_Vertical") * speed;

		}
		else if (player.name == "player2"){
			velocityx = Input.GetAxis("p2_Horizontal") * speed;
			velocityy = Input.GetAxis("p2_Vertical") * speed;

		}
		
		Vector2 moveVector = new Vector2(velocityx,velocityy);
		
		rb2d.velocity = moveVector;

		//allow the character sprite to face the direction where you are walking towards
		rotate(moveVector);

		if(inventory.Count > 0)
		{
			//Debug.Log("test inventory item");
			//Debug.Log(inventory.Count);
			activateItem(inventory[0],moveVector);		
		}		
	}

	void activateItem(String name,Vector2 moveVector){
		
		//activate beacon on character
		if(name == "beacon")
		{
			go = Instantiate (item[0],rb2d.position, Quaternion.identity);
	  		go.transform.parent = gameObject.transform;
		}

		//need to finish code to activate other items
		if(name == "shield"){
			GameObject go = Instantiate (item[1],rb2d.position,Quaternion.identity);
			go.transform.parent = gameObject.transform;
			go.transform.localScale += new Vector3(0.3f, 0.3f, 0);
			shield = true;
			
		}
		if(name == "landmine"){

			weapon playerWeapon = player.GetComponent<weapon>();
			playerWeapon.numberMines += 3;		

		}

//		Debug.Log(name);
		
		
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