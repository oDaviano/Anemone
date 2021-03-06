using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class CombineScrollbar : MonoBehaviour
{
    private GameObject combinePanels;
    private GameObject primePanel;
    private Scrollbar scrollBar;
    private float scrollHeight;
    int count;

    Vector3 position;
    Vector3 positionOrg;

    void Awake()
    {
        combinePanels = transform.GetChild(0).gameObject;
        primePanel = combinePanels.transform.GetChild(0).gameObject;



        scrollBar = GameObject.Find("CombineScrollbar").GetComponent<Scrollbar>();
        positionOrg = combinePanels.transform.localPosition;
        List<Dictionary<int, CombineInfo>> combineInfoData = CSVReader.Read("CombineData");
        count = combineInfoData.Count;

        for (int i = 0; i < count - 3; i++)
        {


            Instantiate(primePanel, combinePanels.transform);



        }
        combinePanels.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 442 * (combinePanels.transform.childCount) / 2);
        scrollHeight = combinePanels.GetComponent<RectTransform>().rect.height;
    }

    void Update()
    {
        position.y = positionOrg.y + scrollHeight * scrollBar.value;
        combinePanels.transform.localPosition = position;
    }
}
