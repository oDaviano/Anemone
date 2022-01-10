using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxData : MonoBehaviour
{

   [SerializeField] private int boxCode = 0;
   public List<ItemSlotInfo> boxItems  = new List<ItemSlotInfo>();
    string code="00000";

    

    void Start()
    {
      // SetBox();
      
    }

    void SetBox()
    {

        List<Dictionary<int, BoxDataInfo>> boxDataInfo = CSVReader.BoxItems("BoxData.csv");
        List<Dictionary<int, ItemInfo>> itemInfo = CSVReader.ItemRead("ItemInfo.csv");
        
               for (int i = 0; i < 8; i++)
               {
                   for (int j = 0; j < itemInfo.Count-1; j++) 
                   {
                       if (itemInfo[j+1][j].itemName == boxDataInfo[boxCode + 1][boxCode].itemList[i])
                       {

                           code = itemInfo[j + 1][j].itemCode;
                           break;
                       }
                   }


                   if (boxDataInfo[boxCode + 1][boxCode].itemList[i] != "null")
                   {
                        boxItems.Add(new ItemSlotInfo(boxDataInfo[boxCode + 1][boxCode].itemList[i], code));

                   }

                   else
                       break;
               }
    }

}






