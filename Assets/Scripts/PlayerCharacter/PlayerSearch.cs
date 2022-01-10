using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSearch : MonoBehaviour
{
    public GameObject interactObject;
    public BoxData BData;
    [SerializeField] public LayerMask _InteractableLayer;
    public UIManager _UIManager;
    [SerializeField] GameObject boxInfoPanel;
    private float Distance = 40.0f;
    private int CanSearch = 0;
    public Text boxName;
    public GameObject[] slot;
   // private Animator animator;

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            slot[i] = (boxInfoPanel.transform.GetChild(i).gameObject);
        }
      //  animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (interactObject != null)
        {
            ObjectSearch();
        }

        InitializeBoxWnd();
    }

    public void ObjectSearch()
    {
       // Debug.Log(Vector3.Distance(interactObject.transform.position, transform.position) <= Distance);
        if ((Vector3.Distance(interactObject.transform.position, transform.position) <= Distance))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
           
                switch (CanSearch)
                {
                    case 0:
                   
                        BData = interactObject.GetComponent<BoxData>();
                        _UIManager.SetBoxName(interactObject.name);
                        CanSearch = 1;
                      //  animator.SetBool("Searching", true);
                        break;
                    case 1:
                        CanSearch = 0;
                      //  animator.SetBool("Searching", false);
                        break;
                }
                _UIManager.ShowBoxPanel(CanSearch);
            }
        }
        else if (CanSearch == 1)
        {
            interactObject = null;
            BData = null;
            CanSearch = 0;
            _UIManager.ShowBoxPanel(CanSearch);
           // animator.SetBool("Searching", false);

        }
        else
        {
            interactObject = null;
            BData = null;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 17)
            interactObject = other.gameObject;
    }
    /*
    private bool CanSearchObject(GameObject gameObject)
    {
        return ((1 << gameObject.layer) & _InteractableLayer) != 0;
    }
    */

    public void InitializeBoxWnd()
    {
        if (BData != null)
        {
            for (int i = 0; i < 8; i++)
            {
                bool hasItem = i < BData.boxItems.Count;
                string path = null;
                var slotImage = slot[i].GetComponent<Image>();
                Color tempColor = slotImage.color;

                if (hasItem)
                {
                    path = $"Images/Icons/Items/{BData.boxItems[i].itemName}";
                    slotImage.sprite = Resources.Load<Sprite>(path);
                    tempColor = Color.white;
                }
                else
                {
                    slotImage.sprite = null;
                    tempColor = Color.black;
                }

                slotImage.color = tempColor;


            }
        }
    }



}





