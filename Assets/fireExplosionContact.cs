using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireExplosionContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{	
		//Debug.Log(hitInfo.name);
		if(hitInfo.name == "player1"){
			GameObject player1 = GameObject.Find("player1");
			Player player = player1.GetComponent<Player>();
			player.health -= 0.5f;

			if(player.health <= 0){
				player.health = 1f;

				GameObject player2 = GameObject.Find("player2");
				Player player2Stats = player2.GetComponent<Player>();
				player2Stats.score += 1;
			}

			//Debug.Log(player.health);
			
		}

		if(hitInfo.name == "player2"){
			GameObject player2 = GameObject.Find("player2");
			Player player = player2.GetComponent<Player>();
			player.health -= 0.5f;

			if(player.health <= 0){
				player.health = 1f;
				
				GameObject player1 = GameObject.Find("player1");
				Player player1Stats = player1.GetComponent<Player>();
				player1Stats.score += 1;

			}

			//Debug.Log(player.health);
			
		}

		
	}
}
