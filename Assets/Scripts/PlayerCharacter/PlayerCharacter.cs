using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerCharacter : MonoBehaviour
{

    [SerializeField] private PlayerInventory _PlayerInventory;
    [SerializeField] private PlayerSearch _PlayerSearch;

    public PlayerInventory playerInventory => _PlayerInventory;
    public int hp;
    public int stamina;
    public int staminaGen;

    public int armor;
    public int minDamage;
    public int maxDamage;
    public int attackSpeed;
    public int attackRange;

    public float crit;
    public int speed;
    public float evasion;

    private Vector3 oldPos;
    private float oldPosX;
    private float oldPosY;
    Rigidbody2D rigidbody;

    RaycastHit2D hit;

    float stayCount;


    public PlayerSearch playerSearch => _PlayerSearch;
    public VirtualJoystick playerMovement;

    void Start()
    {
        playerMovement = GameObject.Find("MoveButton").GetComponent<VirtualJoystick>();
        rigidbody = GetComponent<Rigidbody2D>();
        //  DontDestroyOnLoad(gameObject);

    }

    private void Awake()
    {
        hp = 10;
        stamina = 10;
        staminaGen = 1;

        armor = 1;
        minDamage = 2;
        maxDamage = 3;
        attackSpeed = 2;
        attackRange = 1;

        crit = 0.1f;
        speed = 3;
        evasion = 0.3f;
 
    }


    private void FixedUpdate()
    {
        //Debug.Log(playerMovement.direction.normalized);
        //Debug.Log(transform.position);
        hit = Physics2D.Raycast(transform.position,playerMovement.direction, 20.0f, 1 << 17);
        Debug.DrawRay(transform.position, playerMovement.direction.normalized*30.0f , Color.red);
        // Debug.Log(hit.collider);


        if (hit)

        {
            playerMovement._Speed = 0;

        }
        else
        {
            playerMovement._Speed = 1.5f;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
       


    }










}
