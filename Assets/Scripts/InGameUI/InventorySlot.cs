using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public sealed class InventorySlot : ItemSlot
{

    [SerializeField] private TextMeshProUGUI _textItemCount;

    public int inventorySlotIndex { get; set; }

    public override void UpdateItemSlot()
    {
        base.UpdateItemSlot();

        if(slotInfo.isEmpty)
        {
            _textItemCount.text = null;
        }
        else
        {

            _textItemCount.text = slotInfo.itemCount == 1 ? null : slotInfo.itemCount.ToString();
        }
    }


}
