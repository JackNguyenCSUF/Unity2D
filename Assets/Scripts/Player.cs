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

	private bool colorChange  = false;

	public bool shield = false;

	//create a list for storing items the player picks up
	public List<String> inventory;
	public GameObject[] item;

	public GameObject healthBar;
	public SpriteRenderer sr;
	private int colorChangeCounter = 0;

	
	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		inventory = new List<String>();
		//Physics2D.gravity = Vector2.zero;

		GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
		
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
			healthBar = GameObject.Find("BarSprite1");
			
			

		}
		else if (player.name == "player2"){
			velocityx = Input.GetAxis("p2_Horizontal") * speed;
			velocityy = Input.GetAxis("p2_Vertical") * speed;
			healthBar = GameObject.Find("BarSprite2");
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

		//revert healthbar back to green
		if(colorChange){
			colorChangeCounter++;

			if (colorChangeCounter == 5){
				colorChangeCounter = 0;
				Color newColor;

   				newColor.r = 0;
   				newColor.g = 255;
   				newColor.b = 0;
   				newColor.a = 1f;

   				sr.color = newColor;
				colorChange = false;
			}
		}
		
	}

	void activateItem(String name,Vector2 moveVector){
		
		//activate beacon on character
		if(name == "beacon" || name == "beacon(Clone)")
		{
			go = Instantiate (item[0],rb2d.position, Quaternion.identity);
	  		go.transform.parent = gameObject.transform;
		}

		//need to finish code to activate other items
		if(name == "shield" || name == "shield(Clone)"){
			GameObject go = Instantiate (item[1],rb2d.position,Quaternion.identity);
			go.transform.parent = gameObject.transform;
			go.transform.localScale += new Vector3(0.3f, 0.3f, 0);
			shield = true;
			
		}
		if(name == "landmine" || name == "landmine(Clone)"){

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

	//handle all player collisions with other game objects
	void OnTriggerEnter2D(Collider2D hitInfo)
	{	
		Debug.Log(hitInfo.name);
		sr = healthBar.GetComponent<SpriteRenderer>();

		if(hitInfo.name == "Fire" || hitInfo.name == "Fire(Clone)"){
			//fire from explosion has made contact with player, reduce health.
			if(!shield)
			{
				if (health == 0 && lives == 0){
					health = 0.0f;
				}
				else
				{
					health -= 0.3f;
					Color newColor;

   					newColor.r = 255;
   					newColor.g = 0;
   					newColor.b = 0;
   					newColor.a = 1f;

   					sr.color = newColor;
					colorChange = true;
				
				}
			}
			else if(shield){
				shield = false;
			}
			
		}

		//inflict damage of flare on corresponding player
		//prevent players own flare from doing damage to himself.
		if((hitInfo.name == "newFlare 1(Clone)" && player.name == "player1" ) || (hitInfo.name == "newFlare(Clone)" && player.name == "player2")  ){
			GameObject bullet = GameObject.Find(hitInfo.name);
			Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();

			//do damage to player2
			if(shield == false){
				//Debug.Log( rb2d.velocity);
				health -= 0.30f;
				Color newColor;

   				newColor.r = 255;
   				newColor.g = 0;
   				newColor.b = 0;
   				newColor.a = 1f;

   				sr.color = newColor;
				colorChange = true;

				//destroy the bullet if collides with players
				bullet.name = "unusedBullet";

			}
			else if(shield){
				shield = false;
			}
		}
		
		//when player health reaches 0 refresh health and reduce lives
		if(health <= 0 && lives >0){
				
				lives -= 1;
				health = 1f;		
		}		
		
		if(lives == 0){
			health = 0.0f;
		}

		
	}
}