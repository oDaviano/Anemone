using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemMenu : MonoBehaviour
{
    private bool callPanel = false;
    private bool callDropPanel = false;
    public PlayerCharacter playerCharacter;
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject dropPanel;
    public ItemOption itemOption;

    [SerializeField] Button use;
    [SerializeField] Button dis;
    [SerializeField] Button close;
    public ItemSlotInfo selectedItem;

    [SerializeField] GameObject itemName;
    [SerializeField] GameObject itemSprite;


    int itemCount;
    int itemIndex;
    int itemCode;

    public PlayerInventory inventory { get; private set; }

    List<Dictionary<int, WeaponInfo>> itemSlotInfoData;

    private void Start()
    {
        inventory = playerCharacter.playerInventory;

        use.onClick.AddListener(Use);
        dis.onClick.AddListener(CallDropPanel);
        close.onClick.AddListener(() => { gameObject.SetActive(false); });
        itemSlotInfoData = CSVReader.WeaponRead("Weapon");
    }

void Update()
    {
        itemName.GetComponent<Text>().text = selectedItem.itemName;
        itemSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Items/{selectedItem.itemName}");
    }

    public void Use()
    {
        gameObject.SetActive(false);
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

        gameObject.SetActive(false);
        callDropPanel = !callDropPanel;
        callPanel = !callPanel;
        //  transform.GetChild(0).gameObject.SetActive(callPanel);
        dropPanel.SetActive(true);
        // dropPanel.drop

    }

}
