using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 100;
    
    public Animator animator;

   
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        if (enemyHP <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
            Die();
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
    void Die()
    {
        Destroy(gameObject, 5);
    }
   
    
}
