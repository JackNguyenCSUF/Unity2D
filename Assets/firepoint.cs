using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firepoint : MonoBehaviour {

	public Transform firePoint;

	public GameObject flameThrowerPrefab;

	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Fire1"))
		{
			//Debug.Log("flametrhower initiated");
			flame();
		}
		
	}

	void flame()
	{

		//shooting logic
		Instantiate(flameThrowerPrefab,firePoint.position,firePoint.rotation);
		
	}
}
