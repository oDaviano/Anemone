using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class ConvenienceData : MonoBehaviour
{
    public int difficulty = 3;
    public int danger = 3;
    public int completion = 0;

    private Dictionary<string, int> boxData = new Dictionary<string, int>();

    private void setBoxes()
    {



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