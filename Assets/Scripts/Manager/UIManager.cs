using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    [SerializeField] private VirtualJoystick _MoveJoyStick;
    [SerializeField] private GameObject boxInfoPanel;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject exitPanel;


    private Button openInvenButton;
    private ItemDrop itemDropPanel;

    public void ShowBoxPanel(int callPanel)
    {
        ShowPanel(callPanel, boxInfoPanel);
    }

    public void ShowInventory(int callInven)
    {
        ShowPanel(callInven, inventoryPanel);
    }

    public void ShowDropPanel(int callDrop)
    {
        ShowPanel(callDrop, itemDropPanel.gameObject);
    }


    public void ShowExitPanel(int callExit)
    {

        ShowPanel(callExit, exitPanel);
    }

    public void SetBoxName(string name)
    {
        boxInfoPanel.transform.GetChild(8).GetComponent<Text>().text = name;
    }
    private void ShowPanel(int isOpen, GameObject panel)
    {
        if (isOpen == 1)
        {
            panel.gameObject.SetActive(true);
        }
        else if (isOpen == 0)
        {
            panel.gameObject.SetActive(false);
        }
    }
}
