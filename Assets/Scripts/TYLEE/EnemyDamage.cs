using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public GameObject player;
    private float damageRange;
    public float damageSet = 25f;
    public float minDamage;
    public float maxDamage;

    public GameObject gotHit;
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
            gotHurt();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gotHit != null)
        {
           if (gotHit.GetComponent<Image>().color.a > 0 )
            {
                var color = gotHit.GetComponent<Image>().color;
                color.a -= 0.01f;

                gotHit.GetComponent<Image>().color = color;
            }
            
        }
    }
    void gotHurt()
    {
        var color = gotHit.GetComponent<Image>().color;
        color.a = 0.8f;

        gotHit.GetComponent<Image>().color = color;
    }


}
