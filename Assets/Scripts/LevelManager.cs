using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int level;
    public int distance;
    public int[] levelDistance = { 100, 200, 300 };
    public void Start()
    {
        InitLevel();
    }
    public void InitLevel()
    {
        level = PlayerPrefs.GetInt("level", 0);
        distance = levelDistance[level];
        Debug.Log(distance);
    }
    public void Update()
    {
        if(GameManager.vehicle.transform.position.x >= GameManager.VehicleStartPos + distance)
        {
            UpgradeLevel();
            Debug.Log("Completed!");
        }
    }
    public void UpgradeLevel()
    {
        PlayerPrefs.SetInt("level", level + 1);
        level = PlayerPrefs.GetInt("level");
        distance = levelDistance[level];
        Debug.Log(distance);
    }
}
