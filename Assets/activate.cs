using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour {

	private Light light;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
		
		light.intensity = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
