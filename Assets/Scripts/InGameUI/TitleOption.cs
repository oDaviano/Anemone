using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleOption : MonoBehaviour
{
     Button smallScreen;
     Button bigScreen;
    // Start is called before the first frame update
    void Awake()
    {
        smallScreen = GameObject.Find("Small").GetComponent<Button>() ;
        bigScreen = GameObject.Find("Big").GetComponent<Button>();
        smallScreen.onClick.AddListener(ScreenSizeControl);


    }

    
    void ScreenSizeControl()
    {
        Screen.SetResolution(720, 1280, true);

     }
}
