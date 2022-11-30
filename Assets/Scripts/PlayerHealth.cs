using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public GameObject player;

   

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
           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (health > 100)
        {
            health = 100;
        }
    }
}
