using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	public Renderer rend;
	
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
