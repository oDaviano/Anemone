using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemDrop : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    private PlayerInventory inventory;
    [SerializeField] Button ok;
    [SerializeField] Button cancel;

    [SerializeField] Button dropInc;
    [SerializeField] Button dropDec;
    public int itemIndex;
    // Slider slider;
   [SerializeField] Text dropCountText;
    private int dropCount;
    public int itemCount;
    public Image dropIcon;

    void Start()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        inventory = playerCharacter.playerInventory;


    }

    void Awake()
    {
        ok.onClick.AddListener(DropItem);
        ok.onClick.AddListener(PanelOff);

        cancel.onClick.AddListener(PanelOff);

        dropInc.onClick.AddListener(() =>
        {
            if(dropCount<inventory.inventoryItems[itemIndex].itemCount)
            dropCount++;
        });

        dropDec.onClick.AddListener(() =>
        {
            if (dropCount >0)
                dropCount--;
        });
    }

    private void DropItem()
    {
        ItemSlotInfo temp = inventory.inventoryItems[itemIndex];
        temp.itemCount -= dropCount;
        if (temp.itemCount <= 0)
            inventory.inventoryItems.Remove(inventory.inventoryItems[itemIndex]);
        else
            inventory.inventoryItems[itemIndex] = temp;
    }
 

    private void PanelOff()
    {
        gameObject.SetActive(false);
        dropCount = 0;
    }

    private void Update()
    {
        transform.GetChild(1).GetComponent<Image>().sprite = dropIcon.sprite;
        dropCountText.text = dropCount.ToString();

    }




}
