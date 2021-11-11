using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerCharacter playerCharacter;
    public PlayerInventory playerInventory;
    public GameObject interactionTrigger;
    public GameObject bullet;
    public GameObject firePoint;
    private float delay=0;
    Animator animator;
  
    void Start()
    {
        interactionTrigger = GameObject.Find("InteractionTrigger");
        firePoint = GameObject.Find("FirePoint");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
  
        if (delay>0)
        {
            delay -= Time.deltaTime;
            animator.SetBool("Delaying", true);
        }

      //  Attack();
    }

    private void Attack()
    {
 
        Collider[] hitColliders = Physics.OverlapSphere(interactionTrigger.transform.position, 30, 1 << LayerMask.NameToLayer("Enemy"));
        //Debug.Log(hitColliders[0]);
        Random rand = new Random();
        if (Input.GetKeyDown(KeyCode.Mouse1) && delay<=0)
        {
            animator.SetBool("Delaying", false);
            delay = playerCharacter.attackSpeed;
            if (playerInventory.weaponType == 0)
            {
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    Debug.Log(hitColliders[i].GetComponentInParent<EnemyCharacter>().enemyHp);
                    int damage = Random.Range(playerCharacter.minDamage, playerCharacter.maxDamage + 1);
                    hitColliders[i].GetComponentInParent<EnemyCharacter>().enemyHp -= damage;
                    // Debug.Log(hitColliders[i].GetComponentInParent<EnemyCharacter>().enemyHp);

                }
            }
            else
            {
                Instantiate(bullet, firePoint.transform.position,Quaternion.identity);
            }

        }

    }
}
