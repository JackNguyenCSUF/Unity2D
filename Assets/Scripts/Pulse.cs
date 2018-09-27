using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour {
	
	public float PulseRadius;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float newScale = Mathf.Lerp(0.01f,PulseRadius,Time.deltaTime / 20);
		transform.localScale += new Vector3(newScale,newScale,1);

		if(transform.localScale.x > PulseRadius)
		{
			transform.localScale = new Vector3(newScale,newScale,1);
		}
				
	}
}
