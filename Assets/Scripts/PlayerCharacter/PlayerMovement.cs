using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float _Speed = 20.0f;
    private float turnSpeed = 10.0f;
    Vector3 oldPos;
    Rigidbody rigidbody;
    private Sprite playerFigure;
    private GameObject handLight;
    private GameObject spotLight;

    private VirtualJoystick joyStick;

    private void Start()
    {
        playerFigure = GameObject.Find("PlayerFigure").GetComponent<SpriteRenderer>().sprite;
        spotLight = GameObject.Find("Spot Light");
        rigidbody = GetComponent<Rigidbody>();
        playerFigure= Resources.Load<Sprite>("Images/Art/Character/PlayerBack");
    }

    private void Movement()
    {

        float lookX = Input.GetAxisRaw("Vertical");
        float lookZ = Input.GetAxisRaw("Horizontal");


        Vector3 targetRotation = lookX * Vector3.forward + lookZ * Vector3.right;

        oldPos = transform.position;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {


            transform.Translate(Vector3.forward * _Speed * Time.deltaTime);
            Quaternion rotation = Quaternion.LookRotation(targetRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
            // spotLight.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);



        }
    }
    private void Movement2()
    {
        

        float lookX = Input.GetAxisRaw("Vertical");
        float lookZ = Input.GetAxisRaw("Horizontal");

        Vector3 targetRotation = lookX * Vector3.forward + lookZ * Vector3.right;

        oldPos = transform.position;

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
        {

            Debug.Log("Moving");
            transform.Translate(targetRotation * _Speed * Time.deltaTime);
            Quaternion rotation = Quaternion.LookRotation(targetRotation);
            spotLight.transform.rotation = Quaternion.Slerp(spotLight.transform.rotation, rotation, turnSpeed * Time.deltaTime);

          
            if(165>spotLight.transform.eulerAngles.y && spotLight.transform.eulerAngles.y > 105 )
            {
                playerFigure = Resources.Load<Sprite>("Images/Art/Character/PlayerFront");
            }
            else if((360 > spotLight.transform.eulerAngles.y && spotLight.transform.eulerAngles.y > 270) || spotLight.transform.eulerAngles.y<75)
            {
                playerFigure= Resources.Load<Sprite>("Images/Art/Character/PlayerBack");
            }
            else if (105 > spotLight.transform.eulerAngles.y && spotLight.transform.eulerAngles.y > 75)
            {
                playerFigure= Resources.Load<Sprite>("Images/Art/Character/PlayerRight");
            }
            else if ((195 > spotLight.transform.eulerAngles.y && spotLight.transform.eulerAngles.y > 165))
            {
                playerFigure = Resources.Load<Sprite>("Images/Art/Character/PlayerLeft");
            }
        }
    }


   void Update()
    {
       // Movement2();

    }
}
