using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float dist;
    private Vector3 MouseStart;
    private Vector3 derp;

    float minX = -5.1f;
    float minY =-4.1f;
    float maxX = 5.1f;
    float maxY = 4.1f;

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
        if (transform.position.z == -20)
        {

            if (transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            else if (transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            if (transform.position.y < minY) transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            else if (transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }


    }
}