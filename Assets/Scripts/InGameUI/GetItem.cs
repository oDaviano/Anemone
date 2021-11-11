using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GetItem : MonoBehaviour, IPointerClickHandler
{
    public PlayerCharacter playerCharacter;
    public PlayerInventory inventory;
    public PlayerSearch playerSearch;

    void Start()
    {
        inventory = playerCharacter.playerInventory;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
     
        bool itemNotExist = true;
        ItemSlotInfo tempBox = playerSearch.interactObject.transform.GetComponentInParent<BoxData>().boxItems[transform.GetSiblingIndex()];
        playerSearch.interactObject.transform.GetComponentInParent<BoxData>().boxItems.Remove(playerSearch.interactObject.transform.GetComponentInParent<BoxData>().boxItems[transform.GetSiblingIndex()]);
        if (inventory.inventoryItems.Count <= inventory.slotLimit)
        {
         
            for (int i = 0; i < inventory.inventoryItems.Count; i++)
            {
                if ((tempBox.itemCode == inventory.inventoryItems[i].itemCode))
                {
                    ItemSlotInfo tempInventory = inventory.inventoryItems[i];
                    tempInventory.itemCount += tempBox.itemCount;
                    inventory.inventoryItems[i] = tempInventory;
                    itemNotExist = false;

                    break;

                }


            }
            if (itemNotExist)
            {
                inventory.inventoryItems.Add(tempBox);

            }


        }

    }
}
