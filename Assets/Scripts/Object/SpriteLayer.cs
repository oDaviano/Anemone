using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayer : MonoBehaviour
{
     void Start()
    {
        // transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
    void Update()
    {
       // transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
