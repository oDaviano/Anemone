using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour

{
    [SerializeField] public Image _ImageItemSprite;

    public InventoryWnd inventoryWnd { get; set; }

    public Image itemSprite => _ImageItemSprite;

 public ItemSlotInfo slotInfo
    {
        get=> inventoryWnd.inventory.inventoryItems[(this as InventorySlot).inventorySlotIndex];


    }


    public virtual void UpdateItemSlot()
    {
    }

    public virtual void InitializeInventorySlot(InventoryWnd inventoryWnd)
    {
        // InventoryWnd 객체 설정
        this.inventoryWnd = inventoryWnd;
    }


}
