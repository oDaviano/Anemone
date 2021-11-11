using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDragger : MonoBehaviour
{
    private PlayerInventory _Inventory;

    private InventoryWnd _InventoryWnd;

    private ItemSlot _DraggingSlot;

    private Image _DragImage;

    public PlayerCharacter _PlayerCharacter;

    public bool isItemDragging => _DragImage != null;
    public ItemSlot overlappedSlot { get; set; }

    private void Awake()
    {
        _Inventory = _PlayerCharacter.playerInventory;
        _InventoryWnd = GetComponent<InventoryWnd>();
    }

    private void Update()
    {
        OnItemDragging();
    }

    private void OnItemDragging()
    {

        if (!isItemDragging) return;
       // _DragImage.rectTransform.anchoredPosition = InputManager.Instance.mousePosition;

    }
}
