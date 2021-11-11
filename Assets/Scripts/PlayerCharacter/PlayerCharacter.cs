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


    public PlayerSearch playerSearch => _PlayerSearch;
    public PlayerMovement playerMovement { get; private set; }

    void Start()
    {
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
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       oldPos = transform.position;
   
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == 17) && 
            Vector2.Distance(collision.transform.position, gameObject.transform.position)< Vector2.Distance(collision.transform.position, oldPos))
        {
            transform.position = oldPos;
        }
    }

}
