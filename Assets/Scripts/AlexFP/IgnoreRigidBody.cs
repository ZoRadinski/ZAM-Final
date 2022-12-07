using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRigidBody : MonoBehaviour
{
    public Rigidbody player;

    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
