using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

	public Transform firePoint;

	public Transform minePoint;
	public GameObject flarePrefab;

	public GameObject minePrefab;

	public GameObject player;

	public int numberBullets;
	public int numberMines;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("p1_Fire1") && flarePrefab.name == "newFlare")
		{
			//Debug.Log(numberBullets);
			if(numberBullets > 0)
			{
				shoot();
			}
		}

		if(Input.GetButtonDown("p1_Fire2") && minePrefab.name == "mine" )
		{
			//Debug.Log(numberMines);
			if(numberMines > 0){
				placeMine();
			}
		}

		if(Input.GetButtonDown("p2_Fire1") && flarePrefab.name == "newFlare 1")
		{
			//Debug.Log(numberBullets);
			if(numberBullets > 0)
			{
				shoot();
			}
		}

		if(Input.GetButtonDown("p2_Fire2") && minePrefab.name == "mine 1")
		{
			//Debug.Log(numberMines);
			if(numberMines > 0){
				placeMine();
			}
		}
	}

	void placeMine(){
		//shooting logic
		numberMines -= 1;
		Instantiate(minePrefab,minePoint.position,minePoint.rotation);

	}

	void shoot()
	{

		//shooting logic
		numberBullets -= 1;
		Instantiate(flarePrefab,firePoint.position,firePoint.rotation);

	}
}
