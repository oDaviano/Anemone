using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BoxDataInfo
{
    public string boxName, slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8;
    public List<string> itemList;

    public BoxDataInfo(string boxName, string slot1, string slot2, string slot3, string slot4, string slot5, string slot6, string slot7, string slot8)
    {
        itemList = new List<string>();
        this.boxName = boxName;
        this.slot1 = slot1;
        itemList.Add(slot1);

        this.slot2 = slot2;
        itemList.Add(slot2);

        this.slot3 = slot3;
        itemList.Add(slot3);

        this.slot4 = slot4;
        itemList.Add(slot4);

        this.slot5 = slot5;
        itemList.Add(slot5);

        this.slot6 = slot6;
        itemList.Add(slot6);

        this.slot7 = slot7;
        itemList.Add(slot7);

        this.slot8 = slot8;
        itemList.Add(slot8);



    }
}
