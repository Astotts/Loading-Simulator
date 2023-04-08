using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=XOjd_qU2Ido&ab_channel=Brackeys

[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] position;
    //Cannot Save Unity Specific Data Types meaning no Vector3 but you can save individual variables that comprise the data types as such
    //Vector3 = (float, float, float)

    public PlayerData(MovementController player){
        health = player.health;
        position = new float[3];

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
