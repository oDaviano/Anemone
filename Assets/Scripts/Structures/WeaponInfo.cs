using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct WeaponInfo
{
    public string itemName;
    public string itemCode;
    public int type;
    public int speed;
    public float range;
    public int damage;
    public int hit;
    public int price;
    public int itemCount;



    public bool isEmpty => string.IsNullOrEmpty(itemCode);


    public WeaponInfo(string itemName, string itemCode, int type, int speed, float range, int damage, int hit, int price,int itemCount = 1)
    {
        this.itemName = itemName;
        this.itemCode = itemCode;
        this.type = type;
        this.speed = speed;
        this.range = range;
        this.damage = damage;
        this.hit = hit;
        this.price = price;
        this.itemCount = itemCount;
    }






}
