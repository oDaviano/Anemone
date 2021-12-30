using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class FieldManager : MonoBehaviour
{
    int count = 0;

    [SerializeField] Button[] areaButtons;//지역 진입 버튼
    [SerializeField] GameObject[] areas;
    [SerializeField] Button startButton;
    [SerializeField] GameObject stageInfo;
    Text stageName;
    Text stageDiff;
    string sceneName;
    private List<StageDatas> stages;

    private GameObject target;

    [SerializeField] Button zoomIn;
    [SerializeField] Button zoomOut;


    [SerializeField] GameObject map;
    [SerializeField] Button back;
    Vector3 cameraDefaultPos;

    private string dangerLevel;
    private string itemLevel;
    private int dangerCount;
    private string star;

    private void Awake()
    {
        cameraDefaultPos = Camera.main.transform.position;


        areas = new GameObject[5];
        for (int i = 0; i < areas.Length; i++)
        {
            areas[i] = map.transform.GetChild(i).gameObject;
        }

        back.onClick.AddListener(() =>
        {

            Camera.main.transform.position = cameraDefaultPos;
            for (int i = 0; i < 5; i++)
            {
                areaButtons[i].gameObject.SetActive(true);
                zoomIn.gameObject.SetActive(true);
                zoomOut.gameObject.SetActive(true);

            }
            target = null;
            stageInfo.SetActive(false);

        });

        zoomIn.onClick.AddListener(() =>
        {


            Camera.main.transform.position = cameraDefaultPos + new Vector3(0, 0, 15);

        });

        zoomOut.onClick.AddListener(() =>
        {

            Camera.main.transform.position = cameraDefaultPos;

        });
        // ButtonInitialize();
    }
    private void Update()
    {
        startButton.onClick.AddListener(() =>
        {

            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);//선택한 지역에 해당하는 씬을 호출
        });

        CastRay();
        if (target != null)
        {
            stageInfo.SetActive(true);
            SetStageInfo();
        }
    }

    void CastRay()
    {

        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (Input.GetMouseButtonDown(0))
            if (hit.collider != null)
            {
                target = hit.collider.gameObject;

                Camera.main.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
                zoomIn.gameObject.SetActive(false);
                zoomOut.gameObject.SetActive(false);
            }

    }

    void SetStageInfo()
    {
        List<Dictionary<int, StageDatas>> stageDatas = CSVReader.Stage("Stage.csv");//Stage.csv 파일에서 스테이지 데이터 호출
        int index = target.transform.GetSiblingIndex();
 
        star = "";

        stageName = GameObject.Find("StageName").GetComponent<Text>();
        stageDiff = GameObject.Find("StageDiff").GetComponent<Text>();
        sceneName = areaButtons[index].name;
        stageName.text = " " + areaButtons[index].name;//스테이지 정보 창에 선택한 버튼의 인덱스에 따라 csv 파일을 

        int.TryParse(stageDatas[index + 1][index].Danger, out dangerCount);

        for (int j = 0; j < 5; j++)
        {
            if (j < dangerCount)
                star += "★";
            else
                star += "☆";
        }
        stageDiff.text = $"  아이템: {stageDatas[index + 1][index].stageDifficulty}\n 위험도: {star}";//참조한 정보 출력

        // c# 클로져 기능
    }


    public void ButtonInitialize()
    {
        List<Dictionary<int, StageDatas>> stageDatas = CSVReader.Stage("Stage.csv");//Stage.csv 파일에서 스테이지 데이터 호출


        for (int i = 0; i < areaButtons.Length; i++)
        {
            int index = i;

            areaButtons[index].onClick.AddListener(() =>
            {
                stageInfo.SetActive(true);
                Camera.main.transform.position = new Vector3(areas[index].transform.position.x, areas[index].transform.position.y, -10);
                star = "";

                stageName = GameObject.Find("StageName").GetComponent<Text>();

                stageDiff = GameObject.Find("StageDiff").GetComponent<Text>();
                sceneName = areaButtons[index].name;
                stageName.text = " " + areaButtons[index].name;//스테이지 정보 창에 선택한 버튼의 인덱스에 따라 csv 파일을 

                int.TryParse(stageDatas[index + 1][index].Danger, out dangerCount);

                for (int j = 0; j < 5; j++)
                {
                    areaButtons[j].gameObject.SetActive(false);
                    if (j < dangerCount)
                        star += "★";
                    else

                        star += "☆";

                }
                stageDiff.text = $" 아이템: {stageDatas[index + 1][index].stageDifficulty}\n 위험도: {star}";//참조한 정보 출력



            });
            // c# 클로져 기능

            //   startButton = GameObject.Find("AreaStart").GetComponent<Button>();


        }
    }


}
