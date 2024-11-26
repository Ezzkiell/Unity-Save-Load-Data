using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoad
{
    //C

    //File location
    private static readonly string SaveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");

    //Save by JSON
    public static void Save(GameData data)
    {
        try
        {
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(SaveFilePath, json);
        }
        catch (Exception e)
        {
            Debug.LogError("Error with savedata" + e.Message);
        }
    }

    //Load by JSON 
    public static GameData Load()
    {
        try
        {
            if (File.Exists(SaveFilePath))
            {
                string json = File.ReadAllText(SaveFilePath);
                GameData data = JsonUtility.FromJson<GameData>(json);
                return data;

            }
            else
            {
                Debug.LogWarning("Save file dont exist. Create new DATA");
                return new GameData();
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error with load game. Create new DATA " + e.Message);
            return new GameData();
        }
    }
}

