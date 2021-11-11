using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryWnd : MonoBehaviour
{

    private List<InventorySlot> _InventorySlots = new List<InventorySlot>();
    public PlayerCharacter playerCharacter;
    public UIManager gameUIInstance;
    public GameObject[]slot;

    private int slotLimit;
    public int itemCount;


    public PlayerInventory inventory { get; private set; }

    protected void Awake()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        ;
        inventory = playerCharacter.playerInventory;
    }

    private void Update()
    {
        slotLimit = inventory.slotLimit;
        InitializeInventoryWnd();
    }

    private void InitializeInventoryWnd()
    {
        //PlayerInventory의 inventoryItems 리스트를 참조하여 인벤토리 UI 설정
        for (int i = 0; i < 25; i++)
        {
            int index = i;
            slot[index] = transform.GetChild(index).gameObject;

            if (i < inventory.inventoryItems.Count)
           {
                string path = $"Images/Icons/{inventory.inventoryItems[index].itemName}";
                slot[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
                Color tempColor = slot[i].GetComponent<Image>().color;
                tempColor = Color.white;
                slot[i].GetComponent<Image>().color = tempColor;
                itemCount = inventory.inventoryItems[index].itemCount;

                //아이템 수량이 보이는 조건 - 아이템 종류(코드)
                if(int.Parse(inventory.inventoryItems[index].itemCode)/1000 ==10)
                    transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                else
                    transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().text = itemCount.ToString();
           }
            //빈 슬롯
            else if (i<slotLimit)
            {
          
                slot[i].GetComponent<Image>().sprite = null;
                Color tempColor = slot[i].GetComponent<Image>().color;
          
                tempColor.r = 0;
                tempColor.g = 0;
                tempColor.b = 0;
                tempColor.a = 255f;
                slot[i].GetComponent<Image>().color = tempColor;
                transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }
            //잠긴 슬롯
            else
            {
                slot[i].GetComponent<Image>().sprite = null;
                Color tempColor = slot[i].GetComponent<Image>().color;
                tempColor.r =255;
                tempColor.g =255;
                tempColor.b =255; 
                tempColor.a = 0f;
                slot[i].GetComponent<Image>().color = tempColor;
                transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
 
            }
        }
    }
}
