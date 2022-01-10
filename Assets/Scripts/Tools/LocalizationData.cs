using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LocalizationData
{
    
    public List <LocalizationItem> items;


}

[Serializable]
public class LocalizationItem
{
    public string key;
    public string value;

}
