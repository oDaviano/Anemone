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
    [SerializeField] Image searchBar;
    public GameObject[] slot;
    PlayerCharacter playerCharacter;

    private void Start()
    {
        playerCharacter = transform.GetComponent<PlayerCharacter>();
        for (int i = 0; i < 8; i++)
        {
            slot[i] = (boxInfoPanel.transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        _UIManager.ShowBoxPanel(CanSearch);

        ObjectSearch();
        InitializeBoxWnd();
    }

    public void ObjectSearch()
    {

        if (interactObject != null)
        {
            if (playerCharacter.stayCount < 3.5f)
            {
                playerCharacter.stayCount += Time.deltaTime;
      

            }
            else
            {
                CanSearch = 1;

                playerCharacter.stayCount = 3.5f;
            }
        }

        searchBar.transform.GetChild(0).GetComponent<Image>().fillAmount = playerCharacter.stayCount / 3.3f;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((interactObject == null) && (other.gameObject.CompareTag("Box")))
        {
            interactObject = other.gameObject;
            BData = interactObject.transform.GetComponent<BoxData>();
            searchBar.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactObject = null;
        playerCharacter.stayCount = 0;
        BData = null;
        CanSearch = 0;
        searchBar.gameObject.SetActive(false);
        searchBar.transform.GetChild(0).GetComponent<Image>().fillAmount = 0;

    }


    public void InitializeBoxWnd()
    {

        if (BData != null)
        {
            _UIManager.SetBoxName(BData.boxName);
            for (int i = 0; i < 8; i++)
            {
                bool hasItem = i < BData.boxItems.Count;
                string path = null;
                var slotImage = slot[i].GetComponent<Image>();
                Color tempColor = slotImage.color;

                if (hasItem)
                {
                    path = $"Images/Items/{BData.boxItems[i].itemName}";
                    slotImage.sprite = Resources.Load<Sprite>(path);
        
                }
                else
                {

                    slotImage.sprite = Resources.Load<Sprite>("Images/UI/Panel/ItemBox");
                 
                }

                slotImage.color = tempColor;


            }
        }
    }



}





