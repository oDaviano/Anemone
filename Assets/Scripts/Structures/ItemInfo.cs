using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemInfo
{
    public string itemName;
    public string itemCode;
    public string price;

    public ItemInfo(string itemName, string itemCode, string price)
    {
        this.itemName=itemName;
        this.itemCode=itemCode;
        this.price= price;


    }
    /*
    public static string GetBasicItemCode(ItemType itemType)
    { 
    switch(itemType)
        {

            case ItemType.Bat: return "1000";
            case ItemType.Knife: return "1200";
            case ItemType.Gun: return "1300";
            case ItemType.Fist: return "1400";
            case ItemType.Head: return "1500";
            case ItemType.Cloth: return "1600";
            case ItemType.Food: return "1700";
            case ItemType.Drink: return "1800";
            case ItemType.Material: return "1900";
            case ItemType.Quest: return "2000";
            default: return null;
        }
    
    }
    */

}