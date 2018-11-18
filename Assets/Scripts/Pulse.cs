using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour {
	
	public float PulseRadius;
	public float pulseSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float newScale = Mathf.Lerp(pulseSpeed,PulseRadius,Time.deltaTime / 10);
		transform.localScale += new Vector3(newScale,newScale,1);

		if(transform.localScale.x > PulseRadius)
		{
			transform.localScale = new Vector3(newScale,newScale,1);
		}
				
	}
}
