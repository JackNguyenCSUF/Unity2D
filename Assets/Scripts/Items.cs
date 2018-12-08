using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

	public GameObject item;
	public float rotationSpeed = 5;
	private float x;
	
	
	//player colliding with item
	private GameObject player;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

		//if the item is yet to be picked up, keep it rotating
		if(item.name != null)
		{
			x += 1;
			//Quaternion target = Quaternion.Euler(0, 0, x);

        	// Dampen towards the target rotation
        	//transform.rotation = Quaternion.Slerp(transform.rotation, target,  700f);
			transform.Rotate(Vector3.up, 45 * Time.deltaTime * rotationSpeed);
			

		}
	}
	
	//when something collides with the item execute this.
	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		//Debug.Log(hitInfo.name);
		if(hitInfo.name == "player1" || hitInfo.name == "player2" /* change this code to detect both player1 and player2*/)
		{
			//reference the player and add the item to his inventory list.
			player = GameObject.Find(hitInfo.name);

			//refernce the players "Player.cs" script file and access its vector list.
			Player inventory = player.GetComponent<Player>();

			//add item to playes inventory list
			inventory.inventory.Add(item.name);

			//remove item once the player pick it up.
			Destroy(gameObject);

		}		
		
	}
}
