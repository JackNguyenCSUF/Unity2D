using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour {

    public EventSystem es;

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

        GameObject gObject = GameObject.Find("StartButton");
        //Set this GameObject you clicked as the currently selected in the EventSystem
        es.SetSelectedGameObject(gObject);
    }

    public void RulesMenu(){
        GameObject gObject = GameObject.Find("BackButtonRules");
        //Set this GameObject you clicked as the currently selected in the EventSystem
        es.SetSelectedGameObject(gObject);
    }

    public void ReturnMainMenu(){
        GameObject gObject = GameObject.Find("StartButton");
        //Set this GameObject you clicked as the currently selected in the EventSystem
        es.SetSelectedGameObject(gObject);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();
        
        GameObject canvas = GameObject.Find("Canvas");
        AudioSource asource = canvas.GetComponent<AudioSource>();
        settings.volume = asource.volume;
    }

    public void OptionsMenu(){
        GameObject gObject = GameObject.Find("Slider");
        //Set this GameObject you clicked as the currently selected in the EventSystem
        es.SetSelectedGameObject(gObject);
    }

    public void CreditsMenu(){
        GameObject gObject = GameObject.Find("BackButtonCredits");
        //Set this GameObject you clicked as the currently selected in the EventSystem
        es.SetSelectedGameObject(gObject);
    }

    public void Lives3(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();


        //set color of  lives6 and lives9 back to white "unselected"
        GameObject l3 = GameObject.Find("Lives3");
        GameObject l6 = GameObject.Find("Lives6");
        GameObject l9 = GameObject.Find("Lives9");
        
        Image but3 = l3.GetComponent<Image>();
        Image but6 = l6.GetComponent<Image>();
        Image but9 = l9.GetComponent<Image>();
        
        but3.color = Color.blue;
        but6.color = Color.white;
        but9.color = Color.white;
        


        
        settings.player_lives = 3;

    }

    public void Lives6(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();

        //set color of  lives6 and lives9 back to white "unselected"
        GameObject l3 = GameObject.Find("Lives3");
        GameObject l6 = GameObject.Find("Lives6");
        GameObject l9 = GameObject.Find("Lives9");
        
        Image but3 = l3.GetComponent<Image>();
        Image but6 = l6.GetComponent<Image>();
        Image but9 = l9.GetComponent<Image>();
        
        but3.color = Color.white;
        but6.color = Color.blue;
        but9.color = Color.white;
        
        
        settings.player_lives = 6;
    }

    public void Lives9(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();

        //set color of  lives6 and lives9 back to white "unselected"
        GameObject l3 = GameObject.Find("Lives3");
        GameObject l6 = GameObject.Find("Lives6");
        GameObject l9 = GameObject.Find("Lives9");
        
        Image but3 = l3.GetComponent<Image>();
        Image but6 = l6.GetComponent<Image>();
        Image but9 = l9.GetComponent<Image>();
        
        but3.color = Color.white;
        but6.color = Color.white;
        but9.color = Color.blue;
        
        
        settings.player_lives = 9;
    }

    public void Bullets3(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();

        //set color of  lives6 and lives9 back to white "unselected"
        GameObject b3 = GameObject.Find("Bullets3");
        GameObject b6 = GameObject.Find("Bullets6");
        GameObject b9 = GameObject.Find("Bullets9");
        
        Image bul3 = b3.GetComponent<Image>();
        Image bul6 = b6.GetComponent<Image>();
        Image bul9 = b9.GetComponent<Image>();
        
        bul3.color = Color.blue;
        bul6.color = Color.white;
        bul9.color = Color.white;
        
        settings.bullets = 3;

    }

    public void Bullets6(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();

        //set color of  lives6 and lives9 back to white "unselected"
        GameObject b3 = GameObject.Find("Bullets3");
        GameObject b6 = GameObject.Find("Bullets6");
        GameObject b9 = GameObject.Find("Bullets9");
        
        Image bul3 = b3.GetComponent<Image>();
        Image bul6 = b6.GetComponent<Image>();
        Image bul9 = b9.GetComponent<Image>();
        
        bul3.color = Color.white;
        bul6.color = Color.blue;
        bul9.color = Color.white;
        
        
        settings.bullets = 6;

    }

    public void Bullets9(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("globalSettings");
        GlobalMenuSettings settings = objs[0].GetComponent<GlobalMenuSettings>();

        //set color of  lives6 and lives9 back to white "unselected"
        GameObject b3 = GameObject.Find("Bullets3");
        GameObject b6 = GameObject.Find("Bullets6");
        GameObject b9 = GameObject.Find("Bullets9");
        
        Image bul3 = b3.GetComponent<Image>();
        Image bul6 = b6.GetComponent<Image>();
        Image bul9 = b9.GetComponent<Image>();
        
        bul3.color = Color.white;
        bul6.color = Color.white;
        bul9.color = Color.blue;
        
        
        settings.bullets = 9;
    }
    
}
