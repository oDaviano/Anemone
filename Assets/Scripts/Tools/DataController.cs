using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataController : MonoBehaviour
{
    //GameManager gameManager;
    static GameObject container;
    static GameObject _Container
    {
        get
        {
            return container;
        }
    }
    static DataController instance;
    public static DataController Instance
    {
        get
        {
            if(!instance)
            {
                container = new GameObject();
                container.name = "DataController";
                instance = container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(container);

            }
            return instance;
        }
    }
    public string GameDataFileName = "DataFile.json";
    public GameData gameData;

    /*
    public GameData gameData
    {
        get
        {


            return _gameData;
        }
    }
    */
    public void LoadGameData()
    {
        Debug.Log("Loaded");
        string filePath = Application.persistentDataPath + GameDataFileName;
        if (File.Exists(filePath))
        {
            string fromJsonData = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(fromJsonData);
        }
        else
        {
            gameData = new GameData();
        }
    }
    public void SaveGameData()
    {
        gameData.sound = GameManager.instance.soundPlay;
        gameData.day = GameManager.instance.day;
        gameData.inventoryItems = GameManager.instance.inventoryItems;
        gameData.conBoxList = GameManager.instance.conBoxList;

        string toJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, toJsonData);

    }


    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
