
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SavePlayer(TutorialK Ttk)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = "F:/Save"
        string path = Application.persistentDataPath + "/number.int";
        FileStream stream = new FileStream(path, FileMode.Create);
        //SaveData data = new SaveData(sui);
        //PlayerData data = new PlayerData(sui);
        PlayerData data = new PlayerData(Ttk);
        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/number.int";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            //SaveData data = formatter.Deserialize(stream) as SaveData;
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in"+ path);
            return null;
        }
    }
}
