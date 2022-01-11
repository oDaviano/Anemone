using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class PlayerInventory : MonoBehaviour
{
    private PlayerCharacter _PlayerCharacter;

    private InventoryWnd _InventoryWnd;
    public UIManager gameUIInstance;
    private GameObject clickedObject;
    private bool handEquiping;
    public int weaponType;
    public WeaponInfo fist = new WeaponInfo("Fist", "10999", 0, 1, 1, 1, 1, 0);
    public WeaponInfo equipedWeaponInfo;
    // List<Dictionary<int, WeaponInfo>> itemSlotInfoData;

    [SerializeField] private GameObject slotLock1;
    [SerializeField] private GameObject slotLock2;
    [SerializeField] private GameObject slotLock3;
    public int slotLimit;

    public List<ItemSlotInfo> inventoryItems = new List<ItemSlotInfo>();


    private void Start()
    {

      //  itemSlotInfoData = CSVReader.WeaponRead("Weapon.csv");
       // slotLimit = 10;
       // InitializeInventory();
    }

    private void Awake()
    {
        _PlayerCharacter = GetComponent<PlayerCharacter>();
        // InitializeInventory();
    }

    private void Update()
    {


        if (slotLimit >= 15)
        {
            slotLock1.SetActive(false);
        }
        if (slotLimit >= 20)
        {
            slotLock2.SetActive(false);
        }
        if (slotLimit >= 25)
        {
            slotLock3.SetActive(false);
        }
        weaponType = equipedWeaponInfo.type;
        RemoveEmpty();

    }

    private void RemoveEmpty()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].itemCount <= 0)
            {
                inventoryItems.Remove(inventoryItems[i]);
            }
        }
    }
    private void InitializeInventory()
    {

        if (inventoryItems.Count <= 0)
        {
            inventoryItems.Add(new ItemSlotInfo("Lumber", "19004", 2));
            inventoryItems.Add(new ItemSlotInfo("Wood", "19002", 99));
            inventoryItems.Add(new ItemSlotInfo("OAE", "19001", 99));
            inventoryItems.Add(new ItemSlotInfo("Leather", "19005", 99));
            inventoryItems.Add(new ItemSlotInfo("Rubber", "19006", 99));
            inventoryItems.Add(new ItemSlotInfo("KitchenKnife", "10007", 1));
            inventoryItems.Add(new ItemSlotInfo("Pistol", "10010", 1));
            equipedWeaponInfo = (new WeaponInfo("Pistol", "10010", 1, 3, 5f, 30, 40, 45, 1));

        }

    }


}
