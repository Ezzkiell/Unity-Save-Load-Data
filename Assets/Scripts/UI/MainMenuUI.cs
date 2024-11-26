using UnityEngine;

public class MainMenu : MonoBehaviour {

    public DataManager dataManager;

    public void Awake()
    {
        dataManager = FindFirstObjectByType<DataManager>();
    }

    public void SaveGame()
    {
        dataManager.SaveGame();
    }
    
    public void LoadGame() 
    { 
        dataManager.LoadGame();
    }

    public void RestartGame()
    {
        dataManager.ResetData();
    }
}
