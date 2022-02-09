using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryExtend : MonoBehaviour
{
    PlayerInventory playerInventory;

    private int m1Count = 0;
    private int m3Count = 0;
    private int m2Count = 0;
    private int m4Count = 0;

    private int keyIndex;

    private int m1Index;
    private int m2Index;
    private int m3Index;
    private int m4Index;

    private int m1Needs;
    private int m2Needs;
    private int m3Needs;
    private int m4Needs;

    GameObject slot1;
    GameObject slot2;
    GameObject slot3;
    GameObject slot4;

  [SerializeField]private Button extendButton;
  [SerializeField]private Button cancelButton;


    void Start()
    {
        playerInventory = GameObject.Find("PlayerCharacter").GetComponent<PlayerInventory>();
        extendButton = gameObject.transform.GetChild(5).GetComponent<Button>();
        cancelButton = gameObject.transform.GetChild(6).GetComponent<Button>();

        extendButton.onClick.AddListener(() =>
        {
            Extend();
            gameObject.SetActive(false);
        });
        cancelButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        slot1 = gameObject.transform.GetChild(0).gameObject;
        slot2 = gameObject.transform.GetChild(1).gameObject;
        slot3 = gameObject.transform.GetChild(2).gameObject;
        slot4 = gameObject.transform.GetChild(3).gameObject;

        slot1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/OAE");
        slot2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Wood");
        slot3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Leather");
        slot4.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Items/Rubber");

        slot3.gameObject.SetActive(false);
        slot4.gameObject.SetActive(false);

    }
    void Update()
    {

        ExtendMat();

        var index = playerInventory.slotLimit / 5 - 1;
        // GameObject.Find($"SlotLock{index}").GetComponent<Button>().interactable = true;
        /*
        if ((playerInventory.slotLimit == 10) && m1Count >= m1Needs && m2Count >= m2Needs)
        {
            extendButton.interactable = true;
        }
        else if ((playerInventory.slotLimit == 15) && m1Count >= m1Needs && m2Count >= m2Needs && m3Count >= m3Needs)
        {
            extendButton.interactable = true;
        }
        else if ((playerInventory.slotLimit == 20) && m1Count >= m1Needs && m2Count >= m2Needs && m3Count >= m3Needs && m4Count >= m4Needs)
        {
            extendButton.interactable = true;
        }
        else
            extendButton.interactable = false;
            */

    }


    private void ExtendMat()
    {


        for (int i = 0; i < playerInventory.inventoryItems.Count; i++)
        {
            if (playerInventory.inventoryItems[i].itemName == "OAE")
            {
                m1Count = playerInventory.inventoryItems[i].itemCount;
                m1Index = i;
            }

            else if (playerInventory.inventoryItems[i].itemName == "Wood")
            {
                m2Count = playerInventory.inventoryItems[i].itemCount;
                m2Index = i;
            }

            else if (playerInventory.inventoryItems[i].itemName == "Leather")
            {
                m3Count = playerInventory.inventoryItems[i].itemCount;
                m3Index = i;
            }

            else if (playerInventory.inventoryItems[i].itemName == "Rubber")
            {
                m4Count = playerInventory.inventoryItems[i].itemCount;
                m4Index = i;
            }

        }

        switch (playerInventory.slotLimit)
        {
            case 10:
                m1Needs = 15;
                m2Needs = 10;

                slot1.transform.GetChild(0).GetComponent<Text>().text = $"{m1Count}/{m1Needs}";
                slot1.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, 0);
                slot2.transform.GetChild(0).GetComponent<Text>().text = $"{m2Count}/{m2Needs}";
                slot2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-50, 0);
                break;

            case 15:
                m1Needs = 25;
                m2Needs = 15;
                m3Needs = 5;

                slot1.transform.GetChild(0).GetComponent<Text>().text = $"{m1Count}/{m1Needs}";
                slot1.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, 50);
                slot2.transform.GetChild(0).GetComponent<Text>().text = $"{m2Count}/{m2Needs}";
                slot2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-50, 50);
                slot3.transform.GetChild(0).GetComponent<Text>().text = $"{m3Count}/{m3Needs}";
                slot3.gameObject.SetActive(true);
                break;

            case 20:
                m1Needs = 35;
                m2Needs = 20;
                m3Needs = 5;
                m4Needs = 5;

                slot1.transform.GetChild(0).GetComponent<Text>().text = $"{m1Count}/{m1Needs}";

                slot2.transform.GetChild(0).GetComponent<Text>().text = $"{m2Count}/{m2Needs}";

                slot3.transform.GetChild(0).GetComponent<Text>().text = $"{m3Count}/{m3Needs}";

                slot4.transform.GetChild(0).GetComponent<Text>().text = $"{m4Count}/{m4Needs}";
                slot4.gameObject.SetActive(true);

                break;

            default:
                break;

        }
    }


    private void Extend()
    {
        var index = playerInventory.slotLimit / 5 - 1;
        if ((playerInventory.slotLimit == 10) && m1Count >= m1Needs && m2Count >= m2Needs)
        {
            extendButton.interactable = true;
            ItemSlotInfo temp = playerInventory.inventoryItems[m1Index];
            temp.itemCount = m1Count - m1Needs;
            playerInventory.inventoryItems[m1Index] = temp;
            temp = playerInventory.inventoryItems[m2Index];
            temp.itemCount = m2Count - m2Needs;
            playerInventory.inventoryItems[m2Index] = temp;

            playerInventory.slotLimit = 15;
        }
        else if ((playerInventory.slotLimit == 15) && m1Count >= m1Needs && m2Count >= m2Needs && m3Count >= m3Needs)
        {
            extendButton.interactable = true;
            ItemSlotInfo temp = playerInventory.inventoryItems[m1Index];
            temp.itemCount = m1Count - m1Needs;
            playerInventory.inventoryItems[m1Index] = temp;
            temp = playerInventory.inventoryItems[m2Index];
            temp.itemCount = m2Count - m2Needs;
            playerInventory.inventoryItems[m2Index] = temp;

            temp = playerInventory.inventoryItems[m3Index];
            temp.itemCount = m3Count - m3Needs;
            playerInventory.inventoryItems[m3Index] = temp;

            playerInventory.slotLimit = 20;
        }
        else if ((playerInventory.slotLimit == 20) && m1Count >= m1Needs && m2Count >= m2Needs && m3Count >= m3Needs && m4Count >= m4Needs)
        {
            extendButton.interactable = true;
            ItemSlotInfo temp = playerInventory.inventoryItems[m1Index];
            temp.itemCount = m1Count - m1Needs;
            playerInventory.inventoryItems[m1Index] = temp;
            temp = playerInventory.inventoryItems[m2Index];
            temp.itemCount = m2Count - m2Needs;
            playerInventory.inventoryItems[m2Index] = temp;

            temp = playerInventory.inventoryItems[m3Index];
            temp.itemCount = m3Count - m3Needs;
            playerInventory.inventoryItems[m3Index] = temp;

            temp = playerInventory.inventoryItems[m4Index];
            temp.itemCount = m4Count - m4Needs;
            playerInventory.inventoryItems[m4Index] = temp;


            playerInventory.slotLimit = 25;
        }

        GameManager.instance.slotLimit = playerInventory.slotLimit;


    }
}
