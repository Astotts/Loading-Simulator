using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Saving Game State Data (Saves actual game progress)
//https://www.youtube.com/watch?v=XOjd_qU2Ido&ab_channel=Brackeys

public static class SaveGameState{
    
    public static bool newGame;

    public static void SavePlayer(MovementController player){ //Save data to a file 
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.data"; //make a file path (You could set a specific file name using a UI TextInput then saved it to a dictionary in playerPrefs)
        FileStream stream = new FileStream(path, FileMode.Create); 
        //FileMode.Create, FileMode.Append, FileMode.Open

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(){ //Unpacks the file 
        string path = Application.persistentDataPath + "/player.data"; //You could grab the file name from playerPrefs

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
