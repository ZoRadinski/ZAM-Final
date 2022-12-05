using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject inventoryOB;
    public GameObject pickUpText;

    private bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        inventoryOB.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact"))
        {
            keyOB.SetActive(false);
            inventoryOB.SetActive(true);
            pickUpText.SetActive(false);
        }
    }
}
