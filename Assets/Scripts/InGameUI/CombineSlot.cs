using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombineSlot : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private Button combineButton;
    //인벤토리에서 재료 아이템이 있는 슬롯 인덱스
    private int m1Index;
    private int m2Index;
    private int m3Index;
    private int m4Index;
    //재료 수량
    private int m1Count;
    private int m3Count;
    private int m2Count;
    private int m4Count;

    public int keyIndex;
    //재료 요구량
    private int m1Needs;
    private int m2Needs;
    private int m3Needs;
    private int m4Needs;


    private CombineInfo combineInfo;

    private List<Dictionary<int, WeaponInfo>> weaponData;

    void Start()
    {
        playerInventory = GameObject.Find("PlayerCharacter").GetComponent<PlayerInventory>();
        combineButton = transform.GetChild(0).GetComponent<Button>();

        List<Dictionary<int, CombineInfo>> combineInfoData = CSVReader.Read("CombineData");
        weaponData = CSVReader.WeaponRead("Weapon");

        keyIndex = transform.GetSiblingIndex();

        combineInfo = combineInfoData[keyIndex + 1][keyIndex];

        m1Needs = combineInfo.m1Count;
        m2Needs = combineInfo.m2Count;
        m3Needs = combineInfo.m3Count;
        m4Needs = combineInfo.m4Count;

        SetCombineData();
        SetButton();
        ValueUpdate();
    }


    //재료&결과물 아이콘, 재료 요구량
    private void SetCombineData()
    {
        transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Icons/Items/{combineInfo.resultName}");
        transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Items/{combineInfo.m1Name}");
        transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Items/{combineInfo.m2Name}");
        transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Items/{combineInfo.m3Name}");
        if (combineInfo.m4Name != "null")
        {
            transform.GetChild(2).GetChild(3).GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Items/{combineInfo.m4Name}");
        }
        else
        {
            transform.GetChild(2).GetChild(3).gameObject.SetActive(false);
        }
    }

    private void SetButton()
    {
        combineButton.onClick.AddListener(() =>
        {
            Combine();
        });
    }
    private void RemoveEmpty()
    {

        for (int i = 0; i < playerInventory.inventoryItems.Count; i++)
        {

            if (playerInventory.inventoryItems[i].itemCount <= 0)
            {
                playerInventory.inventoryItems.Remove(playerInventory.inventoryItems[i]);


                if (i == m1Index)
                {
                    m1Count = 0;
                    //   m1Index = 25;
                }
                else if (i == m2Index)
                {
                    m2Count = 0;
                    //    m2Index = 25;
                }
                else if (i == m3Index)
                {
                    m3Count = 0;
                    //  m3Index = 25;
                }

                else if (i == m4Index)
                {
                    //  m4Index = 25;
                    m4Count = 0;
                }

                --i;

            }
        }
    }

    private void Update()
    {
        ValueUpdate();
    }
    //인벤토리의 재료 수량 업데이트
    private void ValueUpdate()
    {
        if (playerInventory.inventoryItems.Exists(x => x.itemName == combineInfo.m1Name))
        {
            m1Index = playerInventory.inventoryItems.FindIndex(x => x.itemName == combineInfo.m1Name);
            m1Count = playerInventory.inventoryItems[m1Index].itemCount;
        }
        else
        {
            m1Count = 0;
            m1Index = -1;
        }
        if (playerInventory.inventoryItems.Exists(x => x.itemName == combineInfo.m2Name))
        {
            m2Index = playerInventory.inventoryItems.FindIndex(x => x.itemName == combineInfo.m2Name);
            m2Count = playerInventory.inventoryItems[m2Index].itemCount;
        }
        else
        {
            m2Count = 0;
            m2Index = -1;
        }
        if (playerInventory.inventoryItems.Exists(x => x.itemName == combineInfo.m3Name))
        {
            m3Index = playerInventory.inventoryItems.FindIndex(x => x.itemName == combineInfo.m3Name);
            m3Count = playerInventory.inventoryItems[m3Index].itemCount;
        }
        else
        {
            m3Count = 0;
            m3Index = -1;
        }
        /*
         *    for (int i = 0; i < playerInventory.inventoryItems.Count; i++)
    {
        if (playerInventory.inventoryItems[i].itemName == combineInfo.m1Name)
        {
            m1Count = playerInventory.inventoryItems[i].itemCount;
            m1Index = i;

        }


        else if (playerInventory.inventoryItems[i].itemName == combineInfo.m2Name)
        {
            m2Count = playerInventory.inventoryItems[i].itemCount;
            m2Index = i;

        }


        else if (playerInventory.inventoryItems[i].itemName == combineInfo.m3Name)
        {
            m3Count = playerInventory.inventoryItems[i].itemCount;
            m3Index = i;
        }
        else if (!(combineInfo.m4Name == "null") && playerInventory.inventoryItems[i].itemName == combineInfo.m4Name)
        {

            m4Count = playerInventory.inventoryItems[i].itemCount;
            m4Index = i;

        }
        }
        */


        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = $"{m1Count}/{m1Needs}";
        transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = $"{m2Count}/{m2Needs}";
        transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Text>().text = $"{m3Count}/{m3Needs}";
        if (!(combineInfo.m4Name == "null"))
        {
            transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<Text>().text = $"{m4Count}/{m4Needs}";
        }
    }

    private void Combine()
    {
        //수량 변경시 슬롯 대체
        ItemSlotInfo tempm1 = playerInventory.inventoryItems[m1Index];
        ItemSlotInfo tempm2 = playerInventory.inventoryItems[m2Index];
        ItemSlotInfo tempm3 = playerInventory.inventoryItems[m3Index];
        ItemSlotInfo tempm4 = playerInventory.inventoryItems[m4Index];

        //모든 재료 보유량이 요구량 이상일 시 조합
        if ((playerInventory.inventoryItems[m1Index].itemCount >= m1Needs) && (playerInventory.inventoryItems[m2Index].itemCount >= m2Needs)
            && (playerInventory.inventoryItems[m3Index].itemCount >= m3Needs) && (playerInventory.inventoryItems[m4Index].itemCount >= m4Needs)
            && playerInventory.inventoryItems.Count < playerInventory.slotLimit)
        {
            tempm1.itemCount -= m1Needs;
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = $"{tempm1.itemCount}/{m1Needs}";
            playerInventory.inventoryItems[m1Index] = tempm1;
            m1Count = tempm1.itemCount;

            tempm2.itemCount -= m2Needs;
            playerInventory.inventoryItems[m2Index] = tempm2;
            transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = $"{ tempm2.itemCount}/{m2Needs}";
            m2Count = tempm2.itemCount;

            tempm3.itemCount -= m3Needs;
            playerInventory.inventoryItems[m3Index] = tempm3;
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = $"{tempm3.itemCount}/{m3Needs}";
            m3Count = tempm3.itemCount;

            if (!(combineInfo.m4Name == "null"))
            {
                tempm4.itemCount -= m4Needs;
                playerInventory.inventoryItems[m4Index] = tempm4;
                transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>().text = $"{tempm4.itemCount}/{m4Needs}";
                m4Count = tempm4.itemCount;
            }

            for (int i = 0; i < weaponData.Count - 1; i++)
            {
                if (combineInfo.resultName == weaponData[i + 1][i].itemName)
                    playerInventory.inventoryItems.Add(new ItemSlotInfo(combineInfo.resultName, weaponData[i + 1][i].itemCode));
            }
        }
        ValueUpdate();
    }
}
