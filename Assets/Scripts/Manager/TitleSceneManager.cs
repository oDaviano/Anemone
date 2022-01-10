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


    void Awake()
    {

        ButtonInitialize();
    }
    public void ButtonInitialize()
    {
        
        startButton.onClick.AddListener(() =>
        {

            GameManager.instance.playSound("Button");
            SceneManager.LoadScene("FieldMap",LoadSceneMode.Single);

        });

        optionButton.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            optionWnd.SetActive(true);

        });




        
    }



 
}
