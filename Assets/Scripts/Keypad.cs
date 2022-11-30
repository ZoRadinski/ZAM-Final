using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject hud;
   


    public GameObject animateOB;
    public Animator ANI;


    public TextMeshProUGUI textOB;
    public string answer = "12345";

   

    public bool animate;


    void Start()
    {
        keypadOB.SetActive(false);

    }


    public void Number(int number)
    {
        textOB.text += number.ToString();
       
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
          
            textOB.text = "Right";

        }
        else
        {
           
            textOB.text = "Wrong";
        }


    }

    public void Clear()
    {
        {
            textOB.text = "";
            
        }
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
       
        hud.SetActive(true);
        player.GetComponent<PlayerMovementScript>().enabled = true;
    }

    public void Update()
    {
        if (textOB.text == "Right" && animate)
        {
            ANI.SetBool("Open", true);
            Debug.Log("its open");
        }


        if (keypadOB.activeInHierarchy)
        {
            hud.SetActive(false);
           
            player.GetComponent<PlayerMovementScript>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }


}
