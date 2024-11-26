using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfoUI : MonoBehaviour
{
    [Header("Game Data")]
    public TextMeshProUGUI currentData;
    public TextMeshProUGUI saveData;

    // Example GameData
    public DataManager dataManager;

    void Start()
    {
        dataManager = FindFirstObjectByType<DataManager>();
        
    }

    private void Update()
    {
        DisplayGameData();
    }

    void DisplayGameData()
    {
        currentData.text = $"Current Data\n" +
                               $"Current Scene: {SceneManager.GetActiveScene().name}\n" +
                               $"Save Time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n\n" +
                               $"Player Stats:\n" +
                               $"HP: {dataManager.gameData.playerData.health}\n" +
                               $"Level: {dataManager.gameData.playerData.level}\n" +
                               $"Pozycja: ({dataManager.playerObject.transform.position.x:F2}, {dataManager.playerObject.transform.position.y:F2}, {dataManager.playerObject.transform.position.z}) ";

        saveData.text = $"Saved Data\n" +
                              $"Current Scene: {dataManager.gameData.currentScene}\n" +
                              $"Save Time: {dataManager.gameData.saveTime}\n\n" +
                              $"Player Stats:\n" +
                              $"HP: {dataManager.gameData.playerData.health}\n" +
                              $"Level: {dataManager.gameData.playerData.level}\n" +
                              $"Pozycja: ({dataManager.gameData.playerData.x}, {dataManager.gameData.playerData.y}, {dataManager.gameData.playerData.z}) ";

    }
}
