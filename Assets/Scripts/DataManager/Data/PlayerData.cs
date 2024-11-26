using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    //C

    [Header("Stats")]
    public int level = 1;

    [Header("Health")]
    public int health = 100;
    public int maxhealt = 100;

    [Header("Player Position")]
    public float x;
    public float y;
    public float z;
}
