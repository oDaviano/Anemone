using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _JoystickThumbImage;
     private float _JoystickRadius = 110.0f;
    public float _Speed = 1.0f;
   // private float turnSpeed = 10.0f;
    private GameObject joyStick;
    private GameObject spotLight;

    Vector3 oldPos;
    Quaternion rotation;
    public Vector2 direction;


    [SerializeField] private PlayerCharacter playerCharacter;
    SpriteRenderer playerSprite;
 

    public RectTransform rectTransform { get; private set; }

    public Vector2 inputAxis { get; private set; }

    public bool isInput { get; private set; }



    void Awake()
    {
        spotLight = GameObject.Find("LightBase");
        joyStick = GameObject.Find("Joystick");
        rectTransform = transform as RectTransform;
        oldPos = _JoystickThumbImage.transform.position;
        playerSprite = playerCharacter.GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        Vector2 sticktoChar = new Vector2((_JoystickThumbImage.transform.position - oldPos).x, (_JoystickThumbImage.transform.position - oldPos).y);
        direction = sticktoChar;

        float angle = Mathf.Atan2((_JoystickThumbImage.transform.position - oldPos).x, (_JoystickThumbImage.transform.position - oldPos).y) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(-angle, Vector3.forward);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, 10);

        if (sticktoChar != Vector2.zero)
        {

            spotLight.transform.rotation = rotation;
            playerCharacter.transform.Translate(sticktoChar.normalized*_Speed);
            if (angle > -45 && angle < 45)
            {
                playerSprite.sprite = Resources.Load<Sprite>("Images/Art/Character/PlayerBack");
            }
            else if (angle > 135 || angle < -135)
            {
                playerSprite.sprite = Resources.Load<Sprite>("Images/Art/Character/PlayerFront");
            }
            else if(angle<=-45 && angle>=-135)
            {
                playerSprite.sprite = Resources.Load<Sprite>("Images/Art/Character/PlayerLeft");
            }
            else if (angle >= 45 && angle <= 135)
            {
           
                playerSprite.sprite = Resources.Load<Sprite>("Images/Art/Character/PlayerRight");
            }

        }
    
    }

    public void OnDrag(PointerEventData eventData)
    {
        _JoystickThumbImage.transform.position = eventData.position;

        var distance = (_JoystickThumbImage.transform.position - joyStick.transform.GetChild(1).transform.position);
        var length = distance.magnitude;

        _JoystickThumbImage.transform.position = (length < _JoystickRadius)
            ? _JoystickThumbImage.transform.position : joyStick.transform.GetChild(1).transform.position + distance.normalized * _JoystickRadius;
        

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isInput = true;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        _JoystickThumbImage.rectTransform.anchoredPosition = inputAxis = Vector2.zero;
      //  playerCharacter.GetComponent<Animator>().SetBool("Moving", false);
        isInput = false;

    }


}
