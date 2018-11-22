using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

	public float timeLeft = 0.6f;
	public GameObject go;
	// Use this for initialization
	void Start () {
		//Debug.Log("explosion triggered");
		
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if(timeLeft <= 0){
			Destroy(go);
		}	
	}
}
