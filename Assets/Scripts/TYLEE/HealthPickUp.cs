using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public GameObject pickUp08;
    public GameObject player;
    public GameObject pickUpText;
    public GameObject cannotPickUpText;
    public float addHealth = 50f;
    private float currentHealth;

    public GameObject screenFX;

    public AudioSource healthsound;

    public bool inReach;

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
          
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
            cannotPickUpText.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = player.GetComponent<PlayerHealth>().health;
        cannotPickUpText.SetActive(false);
        pickUpText.SetActive(false);

        screenFX.SetActive(false);

        inReach = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerHealth>().health < 100)
        {
            inReach = false;
            player.GetComponent<PlayerHealth>().health += addHealth;
           screenFX.SetActive(true);
            pickUp08.GetComponent<BoxCollider>().enabled = false;
            pickUp08.GetComponent<MeshRenderer>().enabled = false;
            pickUpText.SetActive(false);
            StartCoroutine(TurnScreenFXOFF());
        
            healthsound.Play();


        }
        if (inReach && Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerHealth>().health == 100)
        {
            pickUpText.SetActive(false);
            cannotPickUpText.SetActive(true);
        }

        IEnumerator TurnScreenFXOFF()
        {
            yield return new WaitForSeconds(1.25f);
            screenFX.SetActive(false);
            pickUp08.SetActive(false);
        }
    }
}
