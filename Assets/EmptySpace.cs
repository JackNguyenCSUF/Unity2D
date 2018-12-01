using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpace : MonoBehaviour {

	public float waitTimeShield = 10f;
	public float waitTimeLandmine = 20f;

	public GameObject shieldItem;

	public GameObject mineItem;
 
	float timerShield;
	float timerLandmine;
 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timerShield += Time.deltaTime;
		if (timerShield > waitTimeShield) {
			timerShield = 0f;
			Vector3 pos = EmptySpacePosition();
			
			if(checkIfPosEmpty(pos))
			{
				Debug.Log("empty space, spawn shield item");
				transform.position = pos;
    			Instantiate(shieldItem, pos, Quaternion.identity);
			}
			else{
				Debug.Log("obstacle in space provided, try again");
			}
		}

		timerLandmine += Time.deltaTime;
		if (timerLandmine > waitTimeLandmine) {
			timerLandmine = 0f;
			Vector3 pos = EmptySpacePosition();
			
			if(checkIfPosEmpty(pos))
			{
				Debug.Log("empty space, spawn mine item");
				transform.position = pos;
    			Instantiate(mineItem, pos, Quaternion.identity);
			}
			else{
				Debug.Log("obstacle in space provided, try again");
			}
		}
	}

	bool checkIfPosEmpty(Vector3 targetPos){
    	
		GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("obstaclePiece");
    	foreach(GameObject current in allMovableThings)
    	{
        	if(current.transform.position == targetPos)
            	return false;
    	}
    	return true;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{	
		Debug.Log("Empty Space Collision with " + hitInfo.name);		
	}

	Vector3 EmptySpacePosition(){

		float x = Random.Range(32,96);
		float y = Random.Range(20,59);
		
		Vector3 newPos = new Vector3(x, y, 0);
		return newPos;
	}

	

	void SpawnShieldItem(){

	}
}