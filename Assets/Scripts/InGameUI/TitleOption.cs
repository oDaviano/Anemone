using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleOption : MonoBehaviour
{
    Button effectOn;
    Button effectOff;
    Button backGroundOn;
    Button backGroundOff;
    Button close;


    private void Start()
    {

        effectOn = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        effectOff = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        backGroundOn = transform.GetChild(1).GetChild(0).GetComponent<Button>();
        backGroundOff = transform.GetChild(1).GetChild(1).GetComponent<Button>();

        close = transform.GetChild(2).GetComponent<Button>();

        effectOn.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            effectOn.gameObject.GetComponent<Image>().color = Color.white;
            effectOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            effectOff.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            effectOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
            GameManager.instance.soundPlay = 1;
        });

        effectOff.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            effectOff.gameObject.GetComponent<Image>().color = Color.white;
            effectOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            effectOn.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            effectOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
            GameManager.instance.soundPlay = 0;
        });

        backGroundOn.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            backGroundOn.gameObject.GetComponent<Image>().color = Color.white;
            backGroundOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            backGroundOff.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            backGroundOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
            GameManager.instance.backGroundPlay = 1;


        });

        backGroundOff.onClick.AddListener(() =>
         {
             GameManager.instance.playSound("Button");
             backGroundOff.gameObject.GetComponent<Image>().color = Color.white;
             backGroundOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
             backGroundOn.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
             backGroundOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
             GameManager.instance.backGroundPlay = 0;

         });



        close.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            gameObject.SetActive(false);

        });



        if (GameManager.instance.soundPlay == 1)
        {

            effectOn.gameObject.GetComponent<Image>().color = Color.white;
            effectOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            effectOff.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            effectOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
        }
        else
        {
            effectOff.gameObject.GetComponent<Image>().color = Color.white;
            effectOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            effectOn.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            effectOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
        }


        if (GameManager.instance.backGroundPlay == 1)
        {

          backGroundOn.gameObject.GetComponent<Image>().color = Color.white;
          backGroundOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
          backGroundOff.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
          backGroundOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
        }
        else
        {
           backGroundOff.gameObject.GetComponent<Image>().color = Color.white;
           backGroundOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
           backGroundOn.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
           backGroundOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
        }



    }



}
