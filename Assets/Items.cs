using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

	public GameObject item;
	private float x;
	
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

		//if the item is yet to be picked up, keep it rotating
		if(item.name == "diamond")
		{
			x += 1;
			Quaternion target = Quaternion.Euler(0, x, 0);

        	// Dampen towards the target rotation
        	transform.rotation = Quaternion.Slerp(transform.rotation, target,  1f);

		}
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		Debug.Log(hitInfo.name);
		if(hitInfo.name == "ball")
		{
			//add to player inventory


			//destroy object to remove from screen

			Destroy(gameObject);

		}		
		
	}
}
