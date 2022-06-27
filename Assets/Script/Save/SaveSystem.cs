using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//fonction pour save

public static class SaveSystem 
{
    /*
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream fs = new FileStream(path, FileMode.Create);

        Player_Data playerData = new Player_Data(player);

        formatter.Serialize(fs, playerData);
        fs.Close();
    }

    public static Player_Data LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.save";

        if(File.Exists(path))
        {
            BinaryFormatter formatter =new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            Player_Data data = formatter.Deserialize(fs) as Player_Data;

            fs.Close();

            return data;
        }
        else
        {
            Debug.LogError("Les données sauvegarder n'ont pas été trouvé dans "+ path);
            return null;
        }
    }
    */
}
