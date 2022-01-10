using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleOption : MonoBehaviour
{
    Button close;
    Button korean;
    Button english;
    Button soundOn;
    Button soundOff;
    Button joyStick;
    Button button;

    private void Start()
    {
        korean = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        english = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        soundOn = transform.GetChild(1).GetChild(0).GetComponent<Button>();
        soundOff = transform.GetChild(1).GetChild(1).GetComponent<Button>();
        joyStick = transform.GetChild(2).GetChild(0).GetComponent<Button>();
        button = transform.GetChild(2).GetChild(1).GetComponent<Button>();
        close = transform.GetChild(3).GetComponent<Button>();

        korean.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            korean.gameObject.GetComponent<Image>().color = Color.white;
            korean.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            english.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            english.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
        });

        english.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            english.gameObject.GetComponent<Image>().color = Color.white;
            english.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            korean.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            korean.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
        });

        soundOn.onClick.AddListener(() =>
        {

            soundOn.gameObject.GetComponent<Image>().color = Color.white;
            soundOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            soundOff.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            soundOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
            GameManager.instance.soundPlay= 1;
            GameManager.instance.playSound("Button");
        });

        soundOff.onClick.AddListener(() =>
         {

             soundOff.gameObject.GetComponent<Image>().color = Color.white;
             soundOff.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
             soundOn.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
             soundOn.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
             GameManager.instance.soundPlay = 0;
             GameManager.instance.playSound("Button");
         });


        joyStick.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            joyStick.gameObject.GetComponent<Image>().color = Color.white;
            joyStick.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            button.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            button.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
        });

        button.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            button.gameObject.GetComponent<Image>().color = Color.white;
            button.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.black;
            joyStick.gameObject.GetComponent<Image>().color = new Color32(20, 37, 34, 255);
            joyStick.gameObject.transform.GetChild(0).GetComponent<Text>().color = Color.white;
        });



        close.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            gameObject.SetActive(false);

        });
    }



}
