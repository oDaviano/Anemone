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
    private float timeLimit = 300;
    private int dateCount = 0;
    private int callInven = 0;

    public List<ItemSlotInfo> inventoryItems = new List<ItemSlotInfo>();
    


    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        inventoryItems = DataController.Instance.gameData.inventoryItems;

    }

    void Update()
    {
        if (timeLimit > 0)
        {
            Time.timeScale = 1.0f;
            fadeColor.a -= Time.deltaTime * 0.5f;
            fade.color = fadeColor;

        }
        StartTimer();

    }


    private void ExitIcon()
    {
        //uiManager.ShowExitPanel();

        GameObject.Find("ExitIcon").GetComponent<Button>().onClick.AddListener(() =>
        {
            exitUI.SetActive(true);

        });

    }

    void StartTimer()
    {
     
        TimerCount();
        timeLimit -= Time.deltaTime;
        if (timeLimit > 0)
            exitUI.transform.GetChild(0).GetComponent<Text>().text = "탐색을 중단하고 지도로 돌아가시겠습니까?";

        if (timeLimit <= 0)
        {
            fadeColor.a += Time.deltaTime * 4f;
            fade.color = fadeColor;


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

        if (timeLimit <= 60)
        {
            timer.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Art/UI/Button/Timer_Button_timeover");
            timer.GetComponentInChildren<Text>().color = new Color32(255, 0, 50, 255);
        }
        timer.GetComponentInChildren<Text>().text = (minutes.ToString() + " : " + (seconds < 10 ? 0 + seconds.ToString() : seconds.ToString()));
        //timer.GetComponentInChildren<Text>().text = string.Format("{0:N0}",timeLimit);
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerInventory playerInventory = GameObject.Find("PlayerCharacter").GetComponent<PlayerInventory>();

        if (scene.name == "FieldMap")
        {
            inventoryItems.Clear();
            inventoryItems = playerInventory.inventoryItems;
        }

        else if (scene.name != "Title")
        {
            timeLimit = 300;
            playerInventory.inventoryItems.Clear();
            playerInventory.inventoryItems = inventoryItems;
            if (timer == null)
                timer = GameObject.Find("Timer");
            if (invenIcon == null)
            {
                invenIcon = GameObject.Find("InventoryIcon");
                invenIcon.GetComponent<Button>().onClick.AddListener(() =>
                {
                    uiManager.ShowInventory(callInven);
                    if (callInven == 1)
                        callInven = 0;
                    else if (callInven == 0)
                        callInven = 1;

                });
            }

            if ((uiManager == null) && (exitUI == null))
            {

                var mainUI = GameObject.Find("MainUI");

                uiManager = mainUI.GetComponent<UIManager>();

                exitUI = mainUI.transform.GetChild(mainUI.transform.childCount - 1).gameObject;

                exitUI.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
                {

                    SceneManager.LoadScene("FieldMap", LoadSceneMode.Single);

                });

                exitUI.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() =>
                {
                    exitUI.SetActive(false);
                });
            }


            //StartTimer();
            ExitIcon();
            fade = uiManager.gameObject.GetComponent<Image>();
            fadeColor = fade.color;

   
        }

    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
