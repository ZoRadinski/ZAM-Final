using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 100;
    
    public Animator animator;

    public GameObject en;

   
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if (enemyHP <= 0)
        {
            animator.SetTrigger("death");
            
            en.GetComponent<CapsuleCollider>().enabled = false;
            en.GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Die();
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
    
    void Die()
    {
        Destroy(en, 10);
        Destroy(gameObject, 10);
    }
   
    
}
