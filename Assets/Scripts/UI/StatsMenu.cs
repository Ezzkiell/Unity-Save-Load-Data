using UnityEngine;

public class StatsMenu : MonoBehaviour {

    public DataManager dataManager;

    public void Awake()
    {
        dataManager = FindFirstObjectByType<DataManager>();
    }

    public void AddHealth()
    {
        dataManager.gameData.playerData.health+=10;
    }

    public void RemoveHealth()
    {
        dataManager.gameData.playerData.health-=10;
    }

    public void AddLevel()
    {
        dataManager.gameData.playerData.level++;
    }
}
