using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleSceneManager : MonoBehaviour
{

    [SerializeField] Button startButton;
    [SerializeField] Button optionButton;
    [SerializeField] GameObject optionWnd;

    [SerializeField] Button newGame;
    [SerializeField] Button loadGame;

    void Awake()
    {

        ButtonInitialize();
    }
    public void ButtonInitialize()
    {
        
        startButton.onClick.AddListener(() =>
        {
            startButton.gameObject.SetActive(false);

            newGame.gameObject.SetActive(true);
            loadGame.gameObject.SetActive(true);
            GameManager.instance.playSound("Button");


        });

        optionButton.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            optionWnd.SetActive(true);

        });

       newGame.onClick.AddListener(() =>
        {
            DataController.Instance.ResetData();
            GameManager.instance.setDatas();
            GameManager.instance.playSound("Button");
            SceneManager.LoadScene("Intro", LoadSceneMode.Single);
        });


        loadGame.onClick.AddListener(() =>
        {

            GameManager.instance.playSound("Button");
            SceneManager.LoadScene("FieldMap", LoadSceneMode.Single);
        });



        
    }



 
}
