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
    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if(_gameData == null)
            {
                LoadGameData();
               // SaveGameData();
            }
            return _gameData;
        }
    }

    private void Start()
    {
       // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        LoadGameData();
       // SaveGameData();
    }
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;
        if (File.Exists(filePath))
        {
            Debug.Log("불러오기");
            string fromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(fromJsonData);
           // gameManager.inventoryItems = gameData.inventoryItems;
        
        }
        else
        {
            Debug.Log("새 파일 생성");
            _gameData = new GameData();
        }
    }
    public void SaveGameData()
    {
        gameData.inventoryItems = GameManager.instance.inventoryItems ;
        string toJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, toJsonData);

        Debug.Log("Saved");
        //Debug.Log(filePath);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
