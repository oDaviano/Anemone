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

    private bool lock1 = true;
    private bool lock2 = true;
    private bool lock3 = true;

    private Button extendButton;
    private Button cancelButton;

    void Start()
    {
        playerInventory = GameObject.Find("PlayerCharacter").GetComponent<PlayerInventory>();
        extendButton = gameObject.transform.GetChild(5).GetComponent<Button>();
        cancelButton = gameObject.transform.GetChild(6).GetComponent<Button>();

        extendButton.onClick.AddListener(() =>
        {
            Extend();
        });
        cancelButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        var slot1 = gameObject.transform.GetChild(0);
        var slot2 = gameObject.transform.GetChild(1);
        var slot3 = gameObject.transform.GetChild(2);
        var slot4 = gameObject.transform.GetChild(3);
        slot3.gameObject.SetActive(false);
        slot4.gameObject.SetActive(false);

    }
    void Update()
    {
        ExtendMat();

        var index = playerInventory.slotLimit / 5 - 1;
        GameObject.Find($"SlotLock{index}").GetComponent<Button>().interactable = true;
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

    }


    private void ExtendMat()
    {

        var slot1 = gameObject.transform.GetChild(0);
        var slot2 = gameObject.transform.GetChild(1);
        var slot3 = gameObject.transform.GetChild(2);
        var slot4 = gameObject.transform.GetChild(3);

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
                slot1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/OAE");
                slot1.GetChild(0).GetComponent<Text>().text = $"{m1Count}/{m1Needs}";
                slot1.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, 0);

                slot2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Wood");
                slot2.GetChild(0).GetComponent<Text>().text = $"{m2Count}/{m2Needs}";
                slot2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-50, 0);
                if ((m1Count >= m1Needs) && (m2Count >= m2Needs))
                {
                    lock1 = false;
                }

                break;

            case 15:
                m1Needs = 25;
                m2Needs = 15;
                m3Needs = 5;
                slot1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/OAE");
                slot1.GetChild(0).GetComponent<Text>().text = $"{m1Count}/{m1Needs}";
                slot1.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, 50);
                slot2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Wood");
                slot2.GetChild(0).GetComponent<Text>().text = $"{m2Count}/{m2Needs}";
                slot2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-50, 50);
                slot3.gameObject.SetActive(true);
                slot3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Leather");
                slot3.GetChild(0).GetComponent<Text>().text = $"{m3Count}/{m3Needs}";


                if ((m1Count >= m1Needs) && (m2Count >= m2Needs) && (m3Count >= m3Needs))
                {
                    lock2 = false;
                }
                break;

            case 20:
                m1Needs = 35;
                m2Needs = 20;
                m3Needs = 5;
                m4Needs = 5;
                slot1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/OAE");
                slot1.GetChild(0).GetComponent<Text>().text = $"{m1Count}/{m1Needs}";
                slot2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Wood");
                slot2.GetChild(0).GetComponent<Text>().text = $"{m2Count}/{m2Needs}";
                slot3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Leather");
                slot3.GetChild(0).GetComponent<Text>().text = $"{m3Count}/{m3Needs}";
                slot4.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Rubber");
                slot4.GetChild(0).GetComponent<Text>().text = $"{m4Count}/{m4Needs}";
                slot4.gameObject.SetActive(true);
                if ((m1Count >= m1Needs) && (m2Count >= m2Needs) && (m3Count >= m3Needs) && (m4Count >= m4Needs))
                {
                    lock3 = false;
                }

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
            GameObject.Find($"SlotLock{index}").SetActive(false);
            GameObject.Find("ExtendUI").SetActive(false);
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

            GameObject.Find($"SlotLock{index}").SetActive(false);
            GameObject.Find("ExtendUI").SetActive(false);
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
            GameObject.Find($"SlotLock{index}").SetActive(false);
            GameObject.Find("ExtendUI").SetActive(false);
            playerInventory.slotLimit = 25;
        }
    }
}
