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
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject dropPanel;
    Button itemOp;
    [SerializeField] Button use;
    [SerializeField] Button dis;
    [SerializeField] ItemMenu itemMenu;

    public ItemSlotInfo selectedItem;

    int itemCount;
    int itemIndex;
    int itemCode;




    List<Dictionary<int, WeaponInfo>> itemSlotInfoData;

    private void Start()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        playerInventory = playerCharacter.playerInventory;
        itemOp = transform.GetComponent<Button>();


           itemOp.onClick.AddListener(CallPanel);
           use.onClick.AddListener(Use);
            dis.onClick.AddListener(CallDropPanel);

        itemSlotInfoData = CSVReader.WeaponRead("Weapon");
    }


    public void CallPanel()
    {

        if (!playerInventory.inventoryItems[transform.GetSiblingIndex()].isEmpty)
        {
            Debug.Log(this);
            itemMenu.itemOption = this;
            itemMenu.gameObject.SetActive(true);

            //  itemMenu.transform.SetAsLastSibling();

            selectedItem = playerInventory.inventoryItems[transform.GetSiblingIndex()];
            itemMenu.GetComponent<ItemMenu>().selectedItem = selectedItem;

            if (playerInventory.equipedWeaponInfo.itemCode == selectedItem.itemCode)
            {
                use.gameObject.transform.GetComponentInChildren<Text>().text = "사용해제";
            }
            else
                use.gameObject.transform.GetComponentInChildren<Text>().text = "사용";

            var itemDrop = dropPanel.transform.GetComponent<ItemDrop>();
            itemDrop.itemIndex = transform.GetSiblingIndex();
            itemDrop.itemCount = playerInventory.inventoryItems[transform.GetSiblingIndex()].itemCount;
            itemDrop.dropIcon = gameObject.GetComponent<Image>();


        }


    }

    public void Use()
    {

        itemMenu.gameObject.SetActive(false);

        int.TryParse(selectedItem.itemCode, out itemCode);
        if (use.gameObject.transform.GetComponentInChildren<Text>().text == "사용")
        {

            if (itemCode / 1000 < 11)
            {
                for (int i = 0; i < itemSlotInfoData.Count - 1; i++)
                {

                    if (itemSlotInfoData[i + 1][i].itemCode == selectedItem.itemCode)
                    {
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
        itemMenu.gameObject.SetActive(false);
        callDropPanel = !callDropPanel;
        callPanel = !callPanel;
        transform.GetChild(0).gameObject.SetActive(callPanel);
        dropPanel.SetActive(true);
        // dropPanel.transform.GetComponent<ItemDrop>().itemCount = transform.GetComponentInParent<InventoryWnd>().itemCount;

    }



}
