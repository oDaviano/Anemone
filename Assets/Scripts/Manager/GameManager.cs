using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private GameObject timer;
    private GameObject exitUI;
    private GameObject invenIcon;
    private UIManager uiManager;
    private Image fade;
    private Color fadeColor;

    private int score;
    int maxTimeLimit = 300;
    private float timeLimit;
    private int dateCount;
    private int callInven = 0;

    public int day;
    public int soundPlay;
    public int backGroundPlay;
    public int slotLimit;
    PlayerInventory playerInventory;
   GameObject stage;

    public List<ItemSlotInfo> inventoryItems;
    public List<BoxRemains> conBoxList;
    public List<BoxRemains> apartBoxList;

    public AudioClip buttonSound;
    AudioSource audioSource;
    AudioSource backGroundAudioSource;

    void Awake()
    {
       //싱글톤
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        backGroundAudioSource = GetComponent<AudioSource>();

        //저장된 데이터 적용
        DataController.Instance.LoadGameData("Option");
        DataController.Instance.LoadGameData("DataFile");
        setDatas();
        
    }

    void Update()
    {
        audioSource = Camera.main.transform.GetComponent<AudioSource>();
        audioSource.volume = soundPlay;
        backGroundAudioSource.volume = backGroundPlay;

        //페이드 인 효과
        if (timeLimit > 0 && fade!=null)
        {
            Time.timeScale = 1.0f;
            fadeColor.a -= Time.deltaTime * 0.5f;
            fade.color = fadeColor;
        }

        if (stage != null)
        {
            StartTimer();
        }
    }

    public void setDatas()
    {

        inventoryItems = new List<ItemSlotInfo>();
        inventoryItems = DataController.Instance.gameData.inventoryItems;

        conBoxList = new List<BoxRemains>();
        conBoxList = DataController.Instance.gameData.conBoxList;

        day = DataController.Instance.gameData.day;
        slotLimit = DataController.Instance.gameData.slotLimit;
        soundPlay = DataController.Instance.optionData.sound;
        backGroundPlay = DataController.Instance.optionData.backGround;
        stage = GameObject.FindGameObjectWithTag("Stage");
    }

   public void playSound(string action)
    {
        switch(action)
        {
            case "Button"  :audioSource.clip = buttonSound;
                break;
        }
        audioSource.Play();


    }

    private void ExitIcon()
    {
        GameObject.Find("ExitIcon").GetComponent<Button>().onClick.AddListener(() =>
        {
            instance.playSound("Button");
            exitUI.SetActive(true);

        });

    }
    void StartTimer()
    {
        TimerCount();
        timeLimit -= Time.deltaTime;
        if (timeLimit > 0)
            if(exitUI!=null)
            exitUI.transform.GetChild(0).GetComponent<Text>().text = "탐색을 중단하고 지도로 돌아가시겠습니까?";

        //스테이지 종료시 페이드 아웃 효과
        if (timeLimit <= 0)
        {
            fadeColor.a += Time.deltaTime * 4f;
            fade.color = fadeColor;
            for (int i = 0; i < stage.transform.childCount; i++)
            {
                BoxRemains tempRemains = new BoxRemains(stage.transform.GetChild(i).GetComponent<BoxData>().boxItems);
                conBoxList.Add(tempRemains);
        
            }
            DataController.Instance.SaveGameData("DataFile");
            GameObject.Find("ExitIcon").GetComponent<Button>().interactable = false;
            invenIcon.GetComponent<Button>().interactable = false;

            timeLimit = 0;
            dateCount++;

            exitUI.transform.GetChild(0).GetComponent<Text>().text = "탐색 종료";
            exitUI.transform.GetChild(1).transform.localPosition = new Vector2(-100, -200);
            exitUI.SetActive(true);
            exitUI.transform.GetChild(2).gameObject.SetActive(false);

            if (fade.color.a >= 250)
                Time.timeScale = 0.0f;
        }

    }

    //타이머함수
    void TimerCount()
    {
        int minutes = (int)timeLimit / 60;
        int seconds = (int)timeLimit % 60;

        if (timer != null)
        {
            if (timeLimit <= 60)
            {
                timer.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/UI/Buttons/Timer_Button_timeover");
                timer.GetComponentInChildren<Text>().color = new Color32(255, 0, 50, 255);
            }


            timer.GetComponentInChildren<Text>().text = (minutes.ToString() + " : " + (seconds < 10 ? 0 + seconds.ToString() : seconds.ToString()));
        }
    
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Stage 태그가 달린 오브젝트가 존재할 때 => 로드된 씬이 지역 씬일 때
        stage = GameObject.FindGameObjectWithTag("Stage");
        if (stage!=null)
        {
            playerInventory = GameObject.Find("PlayerCharacter").GetComponent<PlayerInventory>();
 
            timeLimit = maxTimeLimit;
            playerInventory.slotLimit = slotLimit;
            playerInventory.inventoryItems = DataController.Instance.gameData.inventoryItems;

            for (int i = 0; i < stage.transform.childCount; i++)
            {
                stage.transform.GetChild(i).GetComponent<BoxData>().boxItems = DataController.Instance.gameData.conBoxList[i].conBox;

            }

            if (timer == null)
                timer = GameObject.Find("Timer");
            if (invenIcon == null)
            {
                invenIcon = GameObject.Find("InventoryIcon");
                invenIcon.GetComponent<Button>().onClick.AddListener(() =>
                {
                    instance.playSound("Button");
                    if (callInven == 1)
                        callInven = 0;
                    else if (callInven == 0)
                        callInven = 1;
                    uiManager.ShowInventory(callInven);

                });
            }
            //UI 매니저(필드)와 탈출 UI가 모두 null일때 Find
            if ((uiManager == null) && (exitUI == null))
            {
                var mainUI = GameObject.Find("MainUI");

                uiManager = mainUI.GetComponent<UIManager>();

                exitUI = mainUI.transform.GetChild(mainUI.transform.childCount - 1).gameObject;

                exitUI.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
                {
                    instance.playSound("Button");
                  
                 //   slotLimit = playerInventory.slotLimit;

                    conBoxList.Clear();
                    inventoryItems = playerInventory.inventoryItems;
                    //저장된 편의점 아이템 박스에 남은 아이템 데이터 적용
                    if (stage.name == "Convenience")
                    {
                        for (int i = 0; i < stage.transform.childCount; i++)
                        {
                            BoxRemains tempRemains = new BoxRemains(stage.transform.GetChild(i).GetComponent<BoxData>().boxItems);
                            conBoxList.Add(tempRemains);

                        }
                    }

                    DataController.Instance.SaveGameData("DataFile");

                    //1일차 대화 씬으로 넘어감
                    if (day <= 1)
                        SceneManager.LoadScene("Dialog", LoadSceneMode.Single);
                    else
                    {
                        SceneManager.LoadScene("FieldMap", LoadSceneMode.Single);
                        day++;
                    }


                });

                exitUI.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
                {
                    instance.playSound("Button");
                    exitUI.SetActive(false);
                });
            }

            ExitIcon();
            fade = uiManager.gameObject.GetComponent<Image>();
            fadeColor = fade.color;

        }
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
