using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacter : MonoBehaviour
{
    private Vector3 patrol1;
    [SerializeField] private Vector3 patrol2;
    private int moveFlag = 1;
     public bool inBattle = false;
    private int enemyType = (int)EnemyType.Light;
    [SerializeField] private float _Speed = 5.0f;
    //private float turnSpeed = 20;
    private NavMeshAgent agent;
   
    public int enemyHp = 10;
    public int enemyDamage=2;


    void Start()
    {
        patrol1 = gameObject.transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = _Speed;

    }

    void Update()
    {

        if (!inBattle)
            Patrol();

        if(enemyHp<=0)
        {
            Debug.Log("Death");
            GetComponent<Animator>().SetBool("Death",true);
            agent.speed = 0;
            Destroy(this.gameObject,10);
        }
    }

    private void Patrol()
    {
        // patrol1 = 시작위치  , m-1
        // patrol2 = 목표위치  , m1
        var destPos = moveFlag == 1 ? patrol2 : patrol1;

        var length = Vector3.Distance(destPos, transform.position);

        // if (Mathf.Approximately(length, 0.5f))
         if (length<0.5f)
        {
            moveFlag *= -1;
          //  destPos = moveFlag == 1 ? patrol2 : patrol1;
      
            agent.SetDestination(moveFlag == 1 ? patrol2 : patrol1);
        }
        else
        { 
            agent.SetDestination(destPos);
        }
         /*
       //if (transform.position == patrol1)
        //{

        //    moveFlag = 1;
        //    agent.SetDestination(patrol2);

        //}
        //else if (transform.position == patrol2)
        //{ 
        //    moveFlag = -1;
        //    agent.SetDestination(patrol1);
        //}

        //if (moveFlag == 1)
        //{

        //    Quaternion rotation = Quaternion.LookRotation(patrol2-transform.position);

        //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        //    transform.position = Vector3.MoveTowards(transform.position, patrol2, _Speed * Time.deltaTime);


        //}

        //else if (moveFlag == -1)
        //{

        //    Quaternion rotation = Quaternion.LookRotation(patrol1 - transform.position);

        //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        //    transform.position = Vector3.MoveTowards(transform.position, patrol1, _Speed * Time.deltaTime);

        //}
        */


    }
}
