using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Saving and loading
//https://www.youtube.com/watch?v=yTCphBjHo-Y&ab_channel=SpeedTutor


public class SaveManager : MonoBehaviour
{

    string activeScene;
    
    public void Save(){
        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LevelSaved", activeScene);
        Debug.Log(activeScene);
    }

    public void NewGame(){
        Debug.Log("Loading New Game");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void LoadGame(){
        if(PlayerPrefs.HasKey("LevelSaved")){
            string levelName = PlayerPrefs.GetString("LevelSaved");
            SceneManager.LoadScene(levelName); 
        }
    }

    public void Exit(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); 
    }
}
