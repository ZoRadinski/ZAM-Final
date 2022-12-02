﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorDoorOpening : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public bool inReach;

    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()
    {

        if (inReach == true && Input.GetButtonDown("Interact"))
        {
            GetComponent<Animator>().SetTrigger("Activate");
        }
    }

    void DoorOpens()
    {
        door.SetBool("Open", true);
        door.SetBool("Closed", false);

    }

    void DoorCloses()
    {
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
    }
}