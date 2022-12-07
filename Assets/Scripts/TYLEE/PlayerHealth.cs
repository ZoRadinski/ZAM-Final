using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public GameObject player;

    public GameObject hitEffect;

   
   

    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            player.GetComponent<PlayerMovementScript>().enabled = false;

            hitEffect.GetComponent<Image>().enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            OnPlayerDeath?.Invoke();
        }
        if (health > 100)
        {
            health = 100;
        }
    }
}
