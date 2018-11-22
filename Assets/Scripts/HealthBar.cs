using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	public GameObject player;

	void Start () {

		Transform bar = transform.Find("Bar");
		Player playerComp = player.GetComponent<Player>();
		bar.localScale = new Vector3(playerComp.health,1f);
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform bar = transform.Find("Bar");
		Player playerComp = player.GetComponent<Player>();
		bar.localScale = new Vector3(playerComp.health,1f);
		
	}
}
