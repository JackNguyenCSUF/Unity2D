using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        //SceneManager.GetActiveScene().buildIndex + 1

        //if this is clicked, only single player mode
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
        settings.single_player_mode = true;

        SceneManager.LoadScene("scene1");
    }

    public void MultiPlayerGame()
    {
        //if this is clicked, vs player mode
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
        settings.single_player_mode = false;

        //need to create scene2 for single player survival mode
        //SceneManager.LoadScene("scene1");
    }



    public void MainScreen(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Lives3(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
        settings.player_lives = 3;

    }

    public void Lives6(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
        settings.player_lives = 6;
    }

    public void Lives9(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
        settings.player_lives = 9;
    }

    public void Bullets3(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
        settings.bullets = 3;

    }

    public void Bullets6(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
        settings.bullets = 6;

    }

    public void Bullets9(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
        settings.bullets = 9;
    }
    
}
