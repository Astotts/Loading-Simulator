using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    float x;
    float y;
    float speed = 15;
    public bool menu = false;

    public int health = 20;

    [SerializeField] GameObject menuObject;

    private void Start(){
        if(SaveGameState.newGame){
            return;
        }
        else{
            this.LoadPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Test Update");
        y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(x, y, 0);

        if(Input.GetButtonDown("Cancel")){ //When escape is pressed
            menu = !menu; //Simple inversion to make 
            if(menu){
                menuObject.SetActive(true);
                Time.timeScale = 0;
                //Time.deltaTime = 0;
            }
            else{
                menuObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

        
    }

    /*void FixedUpdate(){
        Debug.Log("Test Update");
    }*/


    public void LoadPlayer(){ //Doesnt load data just grabs it from SaveGameState and puts it back into the players variables
        PlayerData data = SaveGameState.LoadPlayer();
        Vector3 position = new Vector3(data.position[0],data.position[1],data.position[2]);
        transform.position = position;

        this.health = data.health;
    }

    public void SavePlayer(){
        SaveGameState.SavePlayer(this);
    }
}
