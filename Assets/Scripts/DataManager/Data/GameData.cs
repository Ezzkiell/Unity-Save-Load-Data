using System;
using UnityEngine;


[Serializable]
public class GameData
{
    //C

    [Header("Game Info")]
    public string currentScene;
    public string saveTime;

    [Header("Player Stats")]
    public PlayerData playerData = new();

    [Header("World Data")]
    public WorldData worldData = new();
}


