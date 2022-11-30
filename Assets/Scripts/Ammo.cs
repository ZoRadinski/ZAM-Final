using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject theAmmo;
    public GameObject weaponOB;
    public GameObject pickUpText;

   

    public int ammoBoxAmount;

    public bool inreach;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inreach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inreach = false;
            pickUpText.SetActive(false);
        }
    }



    void Update()
    {
        if (inreach && Input.GetKeyDown(KeyCode.E))
        {
            weaponOB.GetComponent<GunSystem>().ammoCache += ammoBoxAmount;
            pickUpText.SetActive(false);
            theAmmo.SetActive(false);
            
        }


    }
}
