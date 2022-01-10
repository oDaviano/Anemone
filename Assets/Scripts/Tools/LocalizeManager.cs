using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizeManager : MonoBehaviour
{
    public static LocalizeManager instance;
    [SerializeField]private Dictionary<string, string> localizedText;
    private string missingTextString = "Not Found";
    public List<LocalizationItem> items;
 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        LoadLocalizedText("LocalizeText_Kor");

    }

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        filePath += ".json";
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData =  JsonUtility.FromJson<LocalizationData>(dataAsJson);
     

    
            for (int i = 0; i < loadedData.items.Count; i++)
            {

                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
           
            }


        }
        else
        {
            Debug.LogError("Cannot find file");
        }

    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }

}
