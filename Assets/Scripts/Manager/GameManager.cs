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
    [SerializeField] private PlayerPrefs optionUI;

    private int score;
    int maxTimeLimit = 300;
    private float timeLimit;
    private int dateCount;
    private int callInven = 0;

    public int day;
    public int soundPlay;
    PlayerInventory playerInventory;
   GameObject stage;

    public List<ItemSlotInfo> inventoryItems = new List<ItemSlotInfo>();
    public List<BoxRemains> conBoxList;
    public List<BoxRemains> apartBoxList;

    public AudioClip buttonSound;
    AudioSource audioSource;
    


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
  
        stage = GameObject.FindGameObjectWithTag("Stage");
    }

    void Update()
    {
     audioSource.volume = soundPlay;


        if (timeLimit > 0 && fade!=null)
        {
            Time.timeScale = 1.0f;
            fadeColor.a -= Time.deltaTime * 0.5f;
            fade.color = fadeColor;

        }

        //Scene scene = SceneManager.GetActiveScene();
        if(stage!=null)
        StartTimer();
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
        //uiManager.ShowExitPanel();

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

        if (timeLimit <= 0)
        {
            fadeColor.a += Time.deltaTime * 4f;
            fade.color = fadeColor;
            for (int i = 0; i < stage.transform.childCount; i++)
            {
                BoxRemains tempRemains = new BoxRemains(stage.transform.GetChild(i).GetComponent<BoxData>().boxItems);
                conBoxList.Add(tempRemains);
        
            }
            DataController.Instance.SaveGameData();
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

    void TimerCount()
    {
        int minutes = (int)timeLimit / 60;
        int seconds = (int)timeLimit % 60;

        if (timer != null)
        {
            if (timeLimit <= 60)
            {
                timer.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Art/UI/Button/Timer_Button_timeover");
                timer.GetComponentInChildren<Text>().color = new Color32(255, 0, 50, 255);
            }


            timer.GetComponentInChildren<Text>().text = (minutes.ToString() + " : " + (seconds < 10 ? 0 + seconds.ToString() : seconds.ToString()));
        }
    
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FieldMap")
        {
            /*
            inventoryItems.Clear();
            inventoryItems = playerInventory.inventoryItems;
            */

        }

        else if (scene.name != "Title")
        {
            playerInventory = GameObject.Find("PlayerCharacter").GetComponent<PlayerInventory>();
            stage = GameObject.FindGameObjectWithTag("Stage");
            timeLimit = maxTimeLimit;

            playerInventory.inventoryItems = new List<ItemSlotInfo>();
            conBoxList = new List<BoxRemains>();

            DataController.Instance.LoadGameData();
            playerInventory.inventoryItems = DataController.Instance.gameData.inventoryItems;
            if(stage.name == "Convenience")
            conBoxList = DataController.Instance.gameData.conBoxList;

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

            if ((uiManager == null) && (exitUI == null))
            {
                var mainUI = GameObject.Find("MainUI");

                uiManager = mainUI.GetComponent<UIManager>();

                exitUI = mainUI.transform.GetChild(mainUI.transform.childCount - 1).gameObject;

                exitUI.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
                {
                    instance.playSound("Button");
                    day += 1;
                    if(stage.name == "Convenience")
                    for (int i = 0; i < stage.transform.childCount; i++)
                    {
                        BoxRemains tempRemains = new BoxRemains(stage.transform.GetChild(i).GetComponent<BoxData>().boxItems);
                        conBoxList.Add(tempRemains);

                    }

                    inventoryItems.Clear();
                    inventoryItems = playerInventory.inventoryItems;

                    DataController.Instance.SaveGameData();
                    SceneManager.LoadScene("FieldMap", LoadSceneMode.Single);
          

                });

                exitUI.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
                {
                    instance.playSound("Button");
                    exitUI.SetActive(false);
                });
            }

            //StartTimer();
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
