using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FieldManager : MonoBehaviour
{
    int count = 0;

    [SerializeField] Button[] areaButtons;//지역 진입 버튼
    Button startButton;
    GameObject stageInfo;
    Text stageName;
    Text stageDiff;
    private List<StageDatas> stages;

    private string dangerLevel;
    private string itemLevel;
    private int dangerCount;
    private string star;



    private void Awake()
    {
   
        ButtonInitialize();

    }
    public void ButtonInitialize()
    {
        List<Dictionary<int, StageDatas>> stageDatas = CSVReader.Stage("Stage.csv");//Stage.csv 파일에서 스테이지 데이터 호출

        for (int i = 0; i < areaButtons.Length; i++)
        {
            int index = i;
         
            areaButtons[index].onClick.AddListener(() =>
            {
                star = "";
                stageInfo = GameObject.Find("StageInfo");
                stageName = GameObject.Find("StageName").GetComponent<Text>();
                stageDiff = GameObject.Find("StageDiff").GetComponent<Text>();
                stageName.text = areaButtons[index].name;//스테이지 정보 창에 선택한 버튼의 인덱스에 따라 csv 파일을 

                int.TryParse(stageDatas[index + 1][index].Danger, out dangerCount);

              for (int j=0;j< dangerCount;j++)
                {
                    star += "☆";
                }
                stageDiff.text = $"아이템: {stageDatas[index+1][index].stageDifficulty}\n위험도: {star}";//참조한 정보 출력

                // c# 클로져 기능
            });
            startButton = GameObject.Find("AreaStart").GetComponent<Button>();
            startButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(stageName.text, LoadSceneMode.Single);//선택한 진입 지역에 해당하는 씬을 호출
            });
        }
    }
}
