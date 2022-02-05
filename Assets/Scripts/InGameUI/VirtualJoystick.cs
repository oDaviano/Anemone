using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Spine.Unity;

public class VirtualJoystick : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _JoystickThumbImage;
    private float _JoystickRadius = 110.0f;
    public float _Speed = 1.0f;
    private GameObject joyStick;
    private GameObject spotLight;

    [SerializeField] SkeletonAnimation skeletonAnimation;


    Vector3 oldPos;
    Quaternion rotation;
    public Vector2 direction;


    [SerializeField] private PlayerCharacter playerCharacter;

    SkeletonDataAsset skeletonDataAsset_1;
    SkeletonDataAsset skeletonDataAsset_2;

    public RectTransform rectTransform { get; private set; }

    public Vector2 inputAxis { get; private set; }

    public bool isInput { get; private set; }

    bool skeletonFlag;
    bool oldSkeletonFlag;

    Animator animator;



    void Awake()
    {

        spotLight = GameObject.Find("LightBase");
        joyStick = GameObject.Find("Joystick");
        rectTransform = transform as RectTransform;
        oldPos = _JoystickThumbImage.transform.position;

        skeletonDataAsset_1 = Resources.Load<SkeletonDataAsset>("Images/PlayerParts/Player/left_SkeletonData");
        skeletonDataAsset_2 = Resources.Load<SkeletonDataAsset>("Images/PlayerParts/left_Run/left_SkeletonData");
        animator = playerCharacter.GetComponent<Animator>();

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

            skeletonAnimation.skeletonDataAsset = skeletonDataAsset_2;
            spotLight.transform.rotation = rotation;
            playerCharacter.transform.Translate(sticktoChar.normalized * _Speed);
             skeletonAnimation.AnimationName = "Run";
            animator.SetBool("Flag", true);
            if (sticktoChar.x >= 0)
            {
                skeletonAnimation.skeleton.ScaleX = -Mathf.Abs(skeletonAnimation.skeleton.ScaleX);
           
            }
            else
            {
                skeletonAnimation.skeleton.ScaleX = Mathf.Abs(skeletonAnimation.skeleton.ScaleX);
            }

            skeletonFlag = false;
        }
        else
        {

            skeletonAnimation.skeletonDataAsset = skeletonDataAsset_1;
            animator.SetBool("Flag", false);
            skeletonAnimation.AnimationName = "animation";
            skeletonFlag = true;


        }

        if (skeletonFlag != oldSkeletonFlag)
        {
            skeletonAnimation.Initialize(true);
            oldSkeletonFlag = skeletonFlag;

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
        isInput = false;

    }


}
