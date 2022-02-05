using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class IntroManager : MonoBehaviour
{
    [SerializeField]Image backGround;
    [SerializeField] Button button;
    [SerializeField] Text infoText;

    Sprite[] backGrounds;
    string[] infos;
    int index = 0;

    private void Awake()
    {

        infos = new string[6];
        backGrounds = Resources.LoadAll<Sprite>("Images/SceneArts");
       backGround.sprite =  backGrounds[index];
 
        infos[0] = "어느 날, 도심 속에 퍼진 의문의 바이러스 X";
        infos[1] = "태양광에 노출되면 인체에 치명적인 영향을 끼치는데";
        infos[2] = "감염된 사람의 공격성을 높여 주변 사람들을 무차별적으로 공격하게 된다.";
        infos[3] = "하지만 히키코모리인 주인공은 바이러스에 대해 전혀 신경쓰지 않는데";
        infos[4] = "배달을 시키기 위해 핸드폰을 집어들었을 때조차 심각성을 인지하지 못한다.";
        infos[5] = "배가 고픈 주인공은 태평하게도 편의점에나 가자는 생각을 하게 된다.";

        infoText.text = infos[index];

        button.onClick.AddListener(()=>
        {
            if (index < 5)
            {
                index++;
                backGround.sprite = backGrounds[index];

                infoText.text = infos[index];
            }
            else
            {
                SceneManager.LoadScene("FieldMap", LoadSceneMode.Single);
            }

        });
     
   
    }

   

}
