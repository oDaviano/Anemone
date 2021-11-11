using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePanel : MonoBehaviour
{
    private Button invenButton;
    private Button combineButton;
    private Button extendButton;
    private PlayerInventory playerInventory;
    [SerializeField]private GameObject extendUI;
    int extendCount;

    void Start()
    {
        playerInventory = GameObject.Find("PlayerCharacter").GetComponent < PlayerInventory > ();
        extendCount = playerInventory.slotLimit/5-2;
        invenButton = transform.GetChild(0).GetComponent<Button>();
        combineButton = transform.GetChild(1).GetComponent<Button>();
        ButtonInitialize();

    }
     void Update()
    {
        if ((playerInventory.slotLimit < 25) && (extendCount!=playerInventory.slotLimit))
        {
            extendButton = GameObject.Find($"SlotLock{playerInventory.slotLimit / 5 - 1}").GetComponent<Button>();
            extendButton.onClick.AddListener(() =>
            {
                extendUI.SetActive(true);

            });
            extendCount++;
        }
    }

    public void ButtonInitialize()
    {
   
          invenButton.onClick.AddListener(() =>
            {
                transform.parent.GetChild(1).gameObject.SetActive(true);
                transform.parent.GetChild(3).gameObject.SetActive(false);
            });

        combineButton.onClick.AddListener(() =>
        {
            transform.parent.GetChild(1).gameObject.SetActive(false);
            transform.parent.GetChild(3).gameObject.SetActive(true);

        });
        

    }
}
