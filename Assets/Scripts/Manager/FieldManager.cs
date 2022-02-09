using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
public class FieldManager : MonoBehaviour
{
    [SerializeField] GameObject[] areas;
    [SerializeField] Button startButton;
    [SerializeField] GameObject stageInfo;
   [SerializeField] Text stageName;

    [SerializeField] TextMeshProUGUI dayCount;
    string sceneName;
    private List<StageDatas> stages;

    private GameObject target;

    [SerializeField] Button zoomIn;
    [SerializeField] Button zoomOut;


    [SerializeField] GameObject map;
    [SerializeField] Button back;
    Vector3 cameraDefaultPos;
    Camera camera;

    float cameraX;
    float cameraY;

    [SerializeField] GameObject diffStars;
    [SerializeField] GameObject itemStars;

  Sprite emptyStar;
  Sprite fullStar;

    int itemLevel;
    int dangerCount;

    private void Awake()
    {
        camera = Camera.main;
        cameraDefaultPos = camera.transform.position;

        emptyStar = Resources.Load<Sprite>("Images/UI/Buttons/Star_Empty");
        fullStar = Resources.Load<Sprite>("Images/UI/Buttons/Star_Full");

        areas = new GameObject[5];

        for (int i = 0; i < areas.Length; i++)
        {
            areas[i] = map.transform.GetChild(i).gameObject;

        }

        back.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            camera.transform.position = cameraDefaultPos;
            for (int i = 0; i < 5; i++)
            {
                //  areaButtons[i].gameObject.SetActive(true);
                zoomIn.gameObject.SetActive(true);
                zoomOut.gameObject.SetActive(true);

            }
            target = null;
            stageInfo.SetActive(false);
            startButton.gameObject.SetActive(false);

        });

        zoomIn.onClick.AddListener(() =>
        {

            GameManager.instance.playSound("Button");
            camera.transform.position = cameraDefaultPos + new Vector3(0, 0, 15);

        });

        zoomOut.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            camera.transform.position = cameraDefaultPos;


        });

        startButton.onClick.AddListener(() =>
        {
            GameManager.instance.playSound("Button");
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);//선택한 지역에 해당하는 씬을 호출
        });

    }
    private void Update()
    {
        dayCount.text = GameManager.instance.day.ToString();
        CastRay();


        if (target != null)
        {
            stageInfo.SetActive(true);
            startButton.gameObject.SetActive(true);
            SetStageInfo();
        }
    }

    void CastRay()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 pos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z));
            Ray2D ray = new Ray2D(pos, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                GameManager.instance.playSound("Button");
                target = hit.collider.gameObject;

                cameraX = target.transform.position.x;
                cameraY = target.transform.position.y;
                camera.transform.position = new Vector3(cameraX, cameraY, -10);
                zoomIn.gameObject.SetActive(false);
                zoomOut.gameObject.SetActive(false);
            }
        }
    }

    void SetStageInfo()
    {
        List<Dictionary<int, StageDatas>> stageDatas = CSVReader.Stage("Stage");//Stage.csv 파일에서 스테이지 데이터 호출
        int index = target.transform.GetSiblingIndex();

        sceneName = areas[index].name;
        stageName.text = stageDatas[index + 1][index].stageName;//스테이지 정보 창에 선택한 버튼의 자식 인덱스와 파일의 key를 비교
        

        int.TryParse(stageDatas[index + 1][index].Danger, out dangerCount);
        int.TryParse(stageDatas[index + 1][index].stageDifficulty, out itemLevel);


        for (int j = 0; j < 5; j++)
        {

            if (j < dangerCount)
                diffStars.transform.GetChild(j).GetComponent<Image>().sprite = fullStar;
            else
                diffStars.transform.GetChild(j).GetComponent<Image>().sprite = emptyStar;

            if (j < itemLevel)
                itemStars.transform.GetChild(j).GetComponent<Image>().sprite = fullStar;
            else
                itemStars.transform.GetChild(j).GetComponent<Image>().sprite = emptyStar;
        }

        // c# 클로져 기능
    }

}
