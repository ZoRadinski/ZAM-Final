﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorDoorOpening : MonoBehaviour
{
    public Animator door;
    public GameObject lockedText;
    public GameObject UnlockedText;
    public GameObject KeyInventory;

    private bool inReach;
    private bool unlocked;
    private bool locked;
    private bool hasKey;

    public AudioSource openDoorSound;

    void Start()
    {
        inReach = false;
        hasKey = false;
        locked = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            if (locked == true)
            {
                lockedText.SetActive(true);
            }
            else if (hasKey == true)
            {
                UnlockedText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        inReach = false;
        lockedText.SetActive(false);
        UnlockedText.SetActive(false);
    }

    void Update()
    {
        if (KeyInventory.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }
        
        if (hasKey == true && inReach == true && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
        }   
    }

    void DoorOpens()
    {
        openDoorSound.Play();
        GetComponent<Animator>().SetTrigger("Activate");
    }
}