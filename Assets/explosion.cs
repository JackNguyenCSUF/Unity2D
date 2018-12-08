using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

	public float timeLeft = 0.6f;
	public GameObject go;
	// Use this for initialization
	void Start () {
		//Debug.Log("explosion triggered");
		GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
		AudioSource asource = GetComponent<AudioSource>();
        asource.volume = settings.volume * 1.2f;

		
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if(timeLeft <= 0){
			Destroy(go);
		}	
	}
}
