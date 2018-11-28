using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMenuSettings : MonoBehaviour {

	// Use this for initialization
	public int player_lives = 3;
	public bool single_player_mode;

	public int bullets = 3;

	void Awake()
    {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
		DontDestroyOnLoad(this.gameObject);
    }
}
