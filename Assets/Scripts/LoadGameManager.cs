using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Saving and loading
//https://www.youtube.com/watch?v=yTCphBjHo-Y&ab_channel=SpeedTutor

public class LoadGameManager : MonoBehaviour
{
    [SerializeField] MovementController player;
    //private List<EnemyController> enemies;
    string activeScene;
    

    //The scene manager can only save the scene that you are in you will need to "manually" save other data 
    public void Save(){
        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LevelSaved", activeScene);
        Debug.Log(activeScene);
        SaveGameState.SavePlayer(player); //"Manually" saving player data
    }

    public void NewGame(){
        SaveGameState.newGame = true;
        Debug.Log("Loading New Game...");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void LoadGame(){
        SaveGameState.newGame = false;
        if(PlayerPrefs.HasKey("LevelSaved")){
            string levelName = PlayerPrefs.GetString("LevelSaved");
            SceneManager.LoadScene(levelName); 
        }
        //Player data is "Manually" loaded on Start()
        Time.timeScale = 1;
    }

    public void Exit(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); 
    }
}

//Ideally you would create a dictionary with the key/name pairs of the file locations for each save file and save that dictionary into PlayerPrefs 
//By that metric you could have a load select screen where not only can you load any scene but also an unique instances of that scene     