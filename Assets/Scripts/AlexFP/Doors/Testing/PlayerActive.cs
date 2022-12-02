using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActive : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public bool inReach;
    public void OntriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }
    public void OntriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }
    public void Update()
    {
        if (inReach == true && Input.GetButtonDown("Interact")) 
        { 
            if (GetComponent<Animator>() != null)
            {
                GetComponent<Animator>().SetTrigger("Activate");
            }
        }
    }
}
