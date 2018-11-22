using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D hitInfo){
		Debug.Log(hitInfo.name);
		if(hitInfo.name == "Fire" || hitInfo.name == "mine(Clone)" || hitInfo.name == "newFlare(Clone)"){
			Destroy(gameObject);
		}
			
	}
}
