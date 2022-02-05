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

    RaycastHit2D hit;

   public float stayCount;
   public  float searchTime=3.5f;


    public PlayerSearch playerSearch => _PlayerSearch;
    public VirtualJoystick playerMovement;

    void Start()
    {
        playerMovement = GameObject.Find("MoveButton").GetComponent<VirtualJoystick>();

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
        Vector3 raycastPos = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
        hit = Physics2D.Raycast(raycastPos, playerMovement.direction, 20.0f, 1 << 17);
 
        Debug.DrawRay(raycastPos, playerMovement.direction.normalized*20.0f , Color.red);


        if (hit)

        {
            playerMovement._Speed = 0;
            /*
            if (hit.collider.gameObject.CompareTag("Box"))
            {

                if (stayCount < 3.5f)
                {
                    stayCount += Time.deltaTime;
                
                }
                else
                _PlayerSearch.interactObject = hit.collider.gameObject;


            }
            else
            {
                stayCount = 0;
            }
            */

        }
        else
        {
            playerMovement._Speed = 1.5f;
        }
    }












}
