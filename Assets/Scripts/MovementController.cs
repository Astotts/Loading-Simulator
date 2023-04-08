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
        this.LoadPlayer();
    }

    public void LoadPlayer(){
        PlayerData data = SaveGameState.LoadPlayer();
        Vector3 position = new Vector3(data.position[0],data.position[1],data.position[2]);
        transform.position = position;

        this.health = data.health;
    }

    public void SavePlayer(){
        SaveGameState.SavePlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(x, y, 0);

        if(Input.GetButtonDown("Cancel")){
            menu = !menu;
            if(menu){
                menuObject.SetActive(true);
                Time.timeScale = 0;
            }
            else{
                menuObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

        
    }
}
