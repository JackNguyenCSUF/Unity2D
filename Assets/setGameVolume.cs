using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setGameVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        


		AudioSource asource = GetComponent<AudioSource>();
        asource.volume = settings.volume / 5f;
		
	}
}
	
	
