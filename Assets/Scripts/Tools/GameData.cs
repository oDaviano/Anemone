using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{

    public int day = 1;
    public int slotLimit = 10;
    public List<ItemSlotInfo> inventoryItems = new List<ItemSlotInfo>();
    public List<BoxRemains> conBoxList = new List<BoxRemains>();


}
[Serializable]
public class BoxRemains
{
    public List<ItemSlotInfo> conBox;

    public  BoxRemains(List<ItemSlotInfo> conBox)
    {

        this.conBox  = conBox;
    }

}


