using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActive : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistance;
    bool active = false;
    public GameObject InteractionMsg;
   
    private void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);
    
        if(Input.GetKeyDown(KeyCode.E) && active == true)
        {
            if(hit.transform.GetComponent<Animator>() != null)
            {
                hit.transform.GetComponent<Animator>().SetTrigger("Activate");
            }
        }
    }
}
