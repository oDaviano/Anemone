using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour
{
    public string key;


    private void Update()
    {
        Text text = GetComponent<Text>();
        text.text = LocalizeManager.instance.GetLocalizedValue(key);
    }
}
