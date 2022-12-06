using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeypad : MonoBehaviour
{
    public GameObject keypadOb;
    public GameObject keypadText;

    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {          
            inReach = true;
            keypadText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inReach = false;
        keypadText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            keypadOb.SetActive(true);           
        }
    }
}
