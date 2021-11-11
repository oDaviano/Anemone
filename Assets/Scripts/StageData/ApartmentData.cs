using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class ApartmentData : MonoBehaviour
{

    private Dictionary<string, int> boxData = new Dictionary<string, int>();

    private void setBoxes()
    {
        boxData.Add("Shelf", 2);
        boxData.Add("shoesCloset", 4);
        boxData.Add("Shelf", 2);
        boxData.Add("Shelf", 2);
        boxData.Add("Shelf", 10);
        boxData.Add("Shelf", 10);
        boxData.Add("Shelf", 10);


    }

    private void setItems(int enumData)
    {
        switch (enumData)
        {
            case (int)ApartmentItems.shelf:
                break;
            case (int)ApartmentItems.shoesCloset:
                break;
            case (int)ApartmentItems.Closet:
                break;
            case (int)ApartmentItems.refrigerator:

                break;
            case (int)ApartmentItems.bookShelf:
                break;
            case (int)ApartmentItems.kitchen:
                break;
            case (int)ApartmentItems.backpack:
                break;


        }


    }

}