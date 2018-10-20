using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject flarePrefab;
	public int numberBullets = 3;
		
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			Debug.Log(numberBullets);
			if(numberBullets > 0)
			{
				shoot();
			}
		}
	}

	void shoot()
	{

		//shooting logic
		numberBullets -= 1;
		Instantiate(flarePrefab,firePoint.position,firePoint.rotation);
		
	}
}
