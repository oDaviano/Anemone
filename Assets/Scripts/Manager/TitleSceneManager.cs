using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleSceneManager : MonoBehaviour
{

    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button quitButton;


    private void Awake()
    {
        ButtonInitialize();
    }
    public void ButtonInitialize()
    {
        
        startButton.onClick.AddListener(() =>
        {
        
            SceneManager.LoadScene("FieldMap",LoadSceneMode.Single);
        });

        optionButton.onClick.AddListener(() =>
        {
            Debug.Log("옵션");

        });

        
    }

    private void Update()
    {
       
      // if (RectTransformUtility.RectangleContainsScreenPoint((RectTransform)startButton.gameObject.transform, cursorPos.transform.position))
      //  {
        //    Debug.Log("act");
           // cursorPos.transform.position = startButton.transform.position;
       // }
    }


 
}
