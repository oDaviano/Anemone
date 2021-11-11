using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemSlotInfo
{
    public string itemName;
    public string itemCode;

    public int itemCount;
    


    public bool isEmpty => string.IsNullOrEmpty(itemCode);


    public ItemSlotInfo(string itemName, string itemCode, int itemCount = 1)
    {
        this.itemName = itemName;
        this.itemCode = itemCode;
        this.itemCount = itemCount;
    }
}
