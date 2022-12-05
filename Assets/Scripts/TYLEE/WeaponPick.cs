using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponPick : MonoBehaviour
{
    public Transform equipPosition;
    public float distance = 10f;
    GameObject currentWeapon;
    GameObject wp;
    public GameObject cam;
    bool canGrab;
    
    

    public GunSystem gunScript;

    
    


    public bool equipped;

    public GameObject pickUpText;

    public TMP_Text ammotext;
   




    private void Start()
    {
        if (!equipped)
        {
            gunScript.enabled = false;
            


        }
        if (equipped)
        {
            gunScript.enabled = true;
           



        }
       


    }
   
    private void Update()
    {
        CheckWeapons();
        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentWeapon != null)
                    Drop();

                PickUp();
                
            }
        }

        if (currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Drop();
           

        }
    }

    private void CheckWeapons()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
                
            {
                pickUpText.SetActive(true);
                Debug.Log("I can grab it");
                canGrab = true;
                wp = hit.transform.gameObject;
            }
        }
        else
        {
            canGrab = false;
            pickUpText.SetActive(false);
        }

       
    }

    private void PickUp()
    {
        equipped = true;
        gunScript.enabled = true;
       

        ammotext.enabled = true;
        currentWeapon = wp;
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 100f, 0f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
       
    }

    private void Drop()
    {
        equipped = false;
        gunScript.enabled = false;
        
        ammotext.enabled = false;
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;


       
    }


}
