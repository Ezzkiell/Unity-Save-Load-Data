using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject playerObject;

    public GameData gameData;

    public event System.Action<string> OnGameStateChanged;

    #region Zachowuje obiekt na scenie
    private static DataManager instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    
        FindPlayer();
    }
    #endregion

    // Zapisywanie
    public void SaveGame()
    {
        gameData.currentScene = SceneManager.GetActiveScene().name;
        gameData.saveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        FindPlayer();
        Vector3 position = playerObject.transform.position;

        // // Przypisz pozycjê gracza do GameData
        gameData.playerData.x = position.x;
        gameData.playerData.y = position.y;
        gameData.playerData.z = position.z;
   
        SaveLoad.Save(gameData);
       // OnGameStateChanged?.Invoke("Gra zapisana!");
    }
    // Wczytywanie
    public void LoadGame()
    {
        gameData = SaveLoad.Load();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(gameData.currentScene);
        FindPlayer();
    }
    // Metoda do znajdowania gracza
    private void FindPlayer()
    {
        playerObject = GameObject.FindWithTag("Player");
        
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Usuñ subskrypcjê, aby nie wywo³ywaæ ponownie
        OnGameStateChanged?.Invoke("Gra wczytana!");
        FindPlayer();
        Vector3 newPosition = new Vector3(gameData.playerData.x, gameData.playerData.y, gameData.playerData.z);
        playerObject.transform.position = newPosition;
    }

    public void ResetData()
    {
        gameData = new GameData();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
