using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float dist;
    private Vector3 MouseStart;
    private Vector3 derp;

    void Start()
    {
        dist = transform.position.z;  // Distance camera is above map
    }

    void Update()
    {
        if ((transform.position.z > -30 && transform.position.z<-10 ))
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseStart = new Vector3(-Input.mousePosition.x, -Input.mousePosition.y, dist);
                MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
                MouseStart.z = transform.position.z;

            }
            else if (Input.GetMouseButton(0))
            {
                var MouseMove = new Vector3(-Input.mousePosition.x, -Input.mousePosition.y, dist);
                MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
                MouseMove.z = transform.position.z;
                transform.position = transform.position - (MouseMove - MouseStart);
            }
        }

        if (transform.position.x < -5.1f) transform.position = new Vector3(-5.1f, transform.position.y, transform.position.z);
        else if(transform.position.x>8.1f) transform.position = new Vector3(8.1f, transform.position.y, transform.position.z);
        if (transform.position.y < -4.2f)   transform.position = new Vector3(transform.position.x, -4.3f, transform.position.z);
         else if(transform.position.y>8f) transform.position = new Vector3(transform.position.x,8f, transform.position.z);


    }
}