using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{

    private NavMeshAgent agent;
    public PlayerCharacter playerCharacter;
    public EnemyCharacter enemyCharacter;
    float enemyAttackSpeed = 3.0f;
    float delay;
    private Animator animator;


    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        agent = transform.GetComponentInParent<NavMeshAgent>();
        playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        enemyCharacter = transform.parent.GetComponent<EnemyCharacter>();
        delay = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.parent.GetComponent<EnemyCharacter>().inBattle = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GetComponentInParent<Animator>().SetFloat("CoolDown", delay);
        if (other.gameObject.CompareTag("Player"))
        {
            agent.updateRotation = false;
           // agent.SetDestination(other.transform.position);
            transform.parent.LookAt(other.transform.position);
            if (Vector3.Distance(other.transform.position, transform.parent.transform.position) < 22)
            {

                agent.updatePosition = false;
                agent.velocity = Vector3.zero;
                GetComponentInParent<Animator>().SetBool("Attack", true);
                if (delay <= 0)
                {

                   // agent.speed = 0.0f;
                    playerCharacter.hp -= enemyCharacter.enemyDamage;
                    // Debug.Log(playerCharacter.hp);
                    delay = enemyAttackSpeed;
                }
                else
                {
                    // agent.speed = 3;
                    delay -= Time.deltaTime;


                }

            }
            else
            {
                agent.updateRotation = true;
                agent.updatePosition = true;
                GetComponentInParent<Animator>().SetBool("Attack", false);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //  animator.SetBool("inBattle", false);
          agent.speed = 3.0f;
        transform.parent.GetComponent<EnemyCharacter>().inBattle = false;


    }
}
