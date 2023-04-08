using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Saving Game State Data (Saves actual game progress)
//https://www.youtube.com/watch?v=XOjd_qU2Ido&ab_channel=Brackeys

public static class SaveGameState{
    
    public static bool newGame;

    public static void SavePlayer(MovementController player){
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(){
        string path = Application.persistentDataPath + "/player.data";

        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else{
            Debug.LogError("Save File Not Found In " + path);
            return null;
        }
    }
}
