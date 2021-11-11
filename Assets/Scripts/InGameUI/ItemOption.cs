using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemOption : MonoBehaviour
{
    private bool callPanel = false;
    private bool callDropPanel = false;
     PlayerCharacter playerCharacter;
   // public PlayerInventory playerInventory;
    [SerializeField] private GameObject dropPanel;
    Button itemOp;
    Button use;
    Button dis;

    public ItemSlotInfo selectedItem;

    int itemCount;
    int itemIndex;
    int itemCode;
    [SerializeField] GameObject itemMenu;

    public PlayerInventory inventory { get; private set; }

    List<Dictionary<int, WeaponInfo>> itemSlotInfoData;

    private void Start()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        inventory = playerCharacter.playerInventory;
        itemOp = transform.GetComponent<Button>();

        use = itemMenu.transform.GetChild(0).GetComponent<Button>();
        dis = itemMenu.transform.GetChild(1).GetComponent<Button>();
        itemOp.onClick.AddListener(CallPanel);
     //   use.onClick.AddListener(Use);
     //   dis.onClick.AddListener(CallDropPanel);
        itemSlotInfoData = CSVReader.WeaponRead("Weapon.csv");
    }


    public void CallPanel()
    {
        //Debug.Log(gameObject);
        if (!inventory.inventoryItems[transform.GetSiblingIndex()].isEmpty)
        {
            callPanel = !callPanel;
            itemMenu.gameObject.SetActive(callPanel);
            itemMenu.transform.position = transform.position;
            itemMenu.transform.SetAsLastSibling();

            selectedItem = inventory.inventoryItems[transform.GetSiblingIndex()];
            itemMenu.GetComponent<ItemMenu>().selectedItem = selectedItem;
            //Debug.Log(selectedItem.itemName);
            if (inventory.equipedWeaponInfo.itemCode == selectedItem.itemCode)
            {
                use.gameObject.transform.GetComponentInChildren<Text>().text = "사용해제";
            }
            else
                use.gameObject.transform.GetComponentInChildren<Text>().text = "사용";

            var itemDrop = dropPanel.transform.GetComponent<ItemDrop>();
            itemDrop.itemIndex = transform.GetSiblingIndex();
            itemDrop.itemCount = inventory.inventoryItems[transform.GetSiblingIndex()].itemCount;
            itemDrop.dropIcon = gameObject.GetComponent<Image>();
            dropPanel.transform.GetChild(2).GetComponent<Slider>().value = 0;

        }


    }

    /*public void Use()
    {
        Debug.Log(gameObject);
        itemMenu.gameObject.SetActive(false);
 
            int.TryParse(selectedItem.itemCode, out itemCode);
            if (use.gameObject.transform.GetComponentInChildren<Text>().text == "사용")
            {
                //  Debug.Log("activate1");
                //   Debug.Log(selectedItem.itemCode);
                if (itemCode / 1000 < 11)
                {
                    for (int i = 0; i < itemSlotInfoData.Count - 1; i++)
                    {
                     //   Debug.Log(i);
                     //   Debug.Log(itemSlotInfoData[i + 1][i].itemCode == selectedItem.itemCode);
                        if (itemSlotInfoData[i + 1][i].itemCode == selectedItem.itemCode)
                        {
                            // Debug.Log("activate2");
                            playerInventory.equipedWeaponInfo = itemSlotInfoData[i + 1][i];
                            break;
                        }
                    }
                }
            }
            else if (use.gameObject.transform.GetComponentInChildren<Text>().text == "사용해제")
            {
                playerInventory.equipedWeaponInfo = playerInventory.fist;
            }

        

    }



    public void CallDropPanel()
    {
        Debug.Log(gameObject);
        itemMenu.gameObject.SetActive(false);
        callDropPanel = !callDropPanel;
        callPanel = !callPanel;
        transform.GetChild(0).gameObject.SetActive(callPanel);
        dropPanel.SetActive(true);
        // dropPanel.transform.GetComponent<ItemDrop>().itemCount = transform.GetComponentInParent<InventoryWnd>().itemCount;

    }
    */

}
