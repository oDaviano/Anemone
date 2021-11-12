using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemDrop : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    private PlayerInventory inventory;
    Button ok;
    Button cancel;
    public int itemIndex;
    Slider slider;
    Text dropCountText;
    public int itemCount;
    public Image dropIcon;

    void Start()
    {
        playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        inventory = playerCharacter.playerInventory;
        slider = transform.GetChild(2).GetComponent<Slider>();
        dropCountText = transform.GetChild(0).GetComponent<Text>();

    }

    void Awake()
    {
       
        
        ok = transform.GetChild(3).GetComponent<Button>();
        cancel = transform.GetChild(4).GetComponent<Button>();
        ok.onClick.AddListener(PanelOff);
        ok.onClick.AddListener(DropItem);
        cancel.onClick.AddListener(PanelOff);
    }

    private void DropItem()
    {
        ItemSlotInfo temp = inventory.inventoryItems[itemIndex];
        temp.itemCount -= (int)transform.GetChild(2).GetComponent<Slider>().value;
        if (temp.itemCount <= 0)
            inventory.inventoryItems.Remove(inventory.inventoryItems[itemIndex]);
        else
        inventory.inventoryItems[itemIndex] = temp;
    }

    private void PanelOff()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.GetChild(1).GetComponent<Image>().sprite=dropIcon.sprite;
        int value = (int)transform.GetChild(2).GetComponent<Slider>().value;
         slider.minValue = 0;
         slider.maxValue = itemCount;
        dropCountText.text = value.ToString() +"/" +  itemCount.ToString();

    }

 


}
