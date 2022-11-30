using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMsg : MonoBehaviour
{
    public GameObject displayMsg;

    private void Start()
    {
        displayMsg.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {          
            displayMsg.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            displayMsg.SetActive(false);
        }
    }
}
