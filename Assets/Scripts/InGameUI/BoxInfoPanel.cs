using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxInfoPanel : MonoBehaviour
{
	public BoxData _Box;
	public int[] ItemsInfo;

	private void Start()
	{
		_Box = GetComponent<BoxData>();
	}

}
