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

    Sprite emptySlot;
    Sprite unableSlot;

    public PlayerInventory inventory { get; private set; }

    protected void Awake()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        inventory = playerCharacter.playerInventory;
        emptySlot = Resources.Load<Sprite>("Images/UI/Panel/ItemBox");
        unableSlot = Resources.Load<Sprite>("Images/UI/Panel/ItemBoxClose");
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
                string path = $"Images/Items/{inventory.inventoryItems[index].itemName}";
                slot[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
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
          
                slot[i].GetComponent<Image>().sprite = emptySlot;
  
                transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }
            //잠긴 슬롯
            else
            {
                slot[i].GetComponent<Image>().sprite = unableSlot;

                transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
 
            }
        }
    }
}
