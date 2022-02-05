using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScriptController : MonoBehaviour
{
    [SerializeField] Button nextButton;
    [SerializeField] Text talker;
    [SerializeField] Text script;

    [SerializeField] GameObject player;
    [SerializeField] GameObject researcher;

    [SerializeField] Button option1;
    [SerializeField] Button option2;

    [SerializeField] GameObject grad1;
    [SerializeField] GameObject grad2;
    int index;
    int eventIndex;
    List<Dictionary<int, DialogInfo>> dialogDataInfo;

   Sprite[]playerSprites;
  Sprite[] researcherSprites;


    void Start()
    {

        researcherSprites = Resources.LoadAll<Sprite>("Images/Character/Researcher");

        playerSprites = Resources.LoadAll<Sprite>("Images/Character/Player");


        int day = GameManager.instance.day;
        dialogDataInfo = CSVReader.DialogScript($"/ScriptData/Day{day}");

        talker.text = dialogDataInfo[1][0].talker;
        script.text = dialogDataInfo[1][0].script;


        spriteActivate();
        index = 1;
        option1.onClick.AddListener(() => { eventIndex = 0; });
        option1.onClick.AddListener(nextButtonEvent);
  
        option2.onClick.AddListener(() => { eventIndex = 1; });
        option2.onClick.AddListener(nextButtonEvent);
    
        nextButton.onClick.AddListener(nextButtonEvent);

        
    }
    void nextButtonEvent()
    {
        if (index < dialogDataInfo.Count - 1)
        {
            if(GameManager.instance.day==1)
            {
                if(index==13)
                {
                    script.fontSize = 18;
                }
                else
                {
                    script.fontSize = 30;
                }
            }

            else if (GameManager.instance.day == 2)
            {
                if (index==14)
                {
                    script.fontSize = 10;
                }
                else
                {
                    script.fontSize = 30;
                }

                if (index == 20)
                {
                    grad1.SetActive(true);

                }
                else if (index == 21)
                {
                    grad2.SetActive(true);
                }
                else
                {
                    grad1.SetActive(false);
                    grad2.SetActive(false);
                }
            }
            string[] split = new string[2];
            talker.text = dialogDataInfo[index + 1][index].talker;
            if (dialogDataInfo[index + 1][index].script.Contains("/"))
            {
                split = dialogDataInfo[index + 1][index].script.Split(new char[] { '/' });
                script.text = split[eventIndex];
            }
            else if (talker.text != "선택지")
            {
                script.text = dialogDataInfo[index + 1][index].script;
            }

            script.text = script.text.Replace("\\n", "\n");


            if (talker.text == "주인공")
            {
                player.SetActive(true);
                researcher.SetActive(false);
                option1.gameObject.SetActive(false);
                option2.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);

                player.GetComponent<Image>().sprite = playerSprites[dialogDataInfo[index + 1][index].expression];

            }
            else if (talker.text == "연구원")
            {
                player.SetActive(false);
                researcher.SetActive(true);
                option1.gameObject.SetActive(false);
                option2.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
                researcher.GetComponent<Image>().sprite = researcherSprites[dialogDataInfo[index + 1][index].expression];
            }
            else if (talker.text == "선택지")
            {
                talker.text = dialogDataInfo[index][index - 1].talker;
                script.text = dialogDataInfo[index][index - 1].script;
                option1.gameObject.SetActive(true);
                option2.gameObject.SetActive(true);
                option1.transform.GetChild(0).GetComponent<Text>().text = split[0];
                option2.transform.GetChild(0).GetComponent<Text>().text = split[1];
                nextButton.gameObject.SetActive(false);

            }
            else
            {
                talker.text = null;
                player.SetActive(false);
                researcher.SetActive(false);
            }
            index++;
        }
        else
        {
            if (GameManager.instance.day == 2)
                GameManager.instance.day = 7;
            else
                GameManager.instance.day++;

            SceneManager.LoadScene("FieldMap", LoadSceneMode.Single);
        }
    }

    void spriteActivate()
    {

        if (talker.text == "주인공")
        {
            player.SetActive(true);
            researcher.SetActive(false);
            nextButton.gameObject.SetActive(true);
            player.GetComponent<Image>().sprite = playerSprites[dialogDataInfo[index + 1][index].expression];
        }
        else if (talker.text == "연구원")
        {
            player.SetActive(false);
            researcher.SetActive(true);
            nextButton.gameObject.SetActive(true);
            researcher.GetComponent<Image>().sprite = researcherSprites[dialogDataInfo[index + 1][index].expression];

        }
        else if (talker.text != "선택지")
        {

            player.SetActive(false);
            researcher.SetActive(false);
        
        }
        

    }

}






