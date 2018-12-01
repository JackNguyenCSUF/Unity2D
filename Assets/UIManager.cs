using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

	GameObject[] pauseObjects;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
	}

	void Update () {

		GameObject player1 = GameObject.Find("player1");
		Player player1Stats = player1.GetComponent<Player>();

		GameObject player2 = GameObject.Find("player2");
		Player player2Stats = player2.GetComponent<Player>();
		
		//uses the p button to pause and unpause the game
		//if(Input.GetKeyDown(KeyCode.P))
		if(player1Stats.lives <= 0){
			
		
			//player 2 wins, pause menu
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
					GameObject pauseText = GameObject.Find("PauseText");
					Text text = pauseText.GetComponent<Text>();
					text.text = "PLAYER 2 WINS";

			} 
		}
		else if(player2Stats.lives <= 0){

			
			//player 1 wins, pause menu
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
				GameObject pauseText = GameObject.Find("PauseText");
				Text text = pauseText.GetComponent<Text>();
				text.text = "PLAYER 1 WINS";

			}
		}
		else if(Input.GetButtonDown("p1_Fire3") || Input.GetButtonDown("p2_Fire3"))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
		
		
	}

	//Reloads the Level
	public void Reload(){
    
	    Application.LoadLevel(Application.loadedLevel);
	}

	//controls the pausing of the scene
	public void pauseControl(){
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level){
		Application.LoadLevel(level);
	}
}
