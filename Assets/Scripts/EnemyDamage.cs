using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject player;
    private float damageRange;
    public float damageSet = 25f;
    public float minDamage;
    public float maxDamage;
    // Start is called before the first frame update
    void Start()
    {
        damageRange = Random.Range(minDamage, maxDamage);
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().health -= damageRange;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
