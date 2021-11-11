using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]public PlayerCharacter playerCharacter;
    GameObject spotLight;
    int bulletSpeed=250;
    void Start()
    {
       spotLight  = GameObject.Find("Light");
        playerCharacter = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(spotLight);
        //   Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1);

        //    Debug.Log(hitColliders.Length);

        // transform.position += Vector3.forward*Time.deltaTime*bulletSpeed;
        transform.position += spotLight.transform.forward * Time.deltaTime * bulletSpeed;
        //  Debug.Log(playerCharacter.transform.position);
        // Debug.Log(transform.position);



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Box"))
        {

            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.gameObject.transform.GetComponentInParent<EnemyCharacter>().enemyHp -= 2;
            Destroy(this.gameObject);
        }
    }
}
