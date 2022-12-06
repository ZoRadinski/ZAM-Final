using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keyPadOB;
    public GameObject canvas;
    public GameObject inventory;
    public GameObject Cam;
    public GameObject TurnOff;

    public GameObject animatOB;
    public Animator ani;

    [SerializedField] public TextMeshProUGUI textOB;

    public string answer = "12345";

    public bool animate;

    void start()
    {
        keyPadOB.SetActive(false);
    }

    public void Number(int number)
    {
        if(textOB.text != "Wrong")
        {
            textOB.text += number.ToString();
        }
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
        keyPadOB.SetActive(false);
        inventory.SetActive(true);
        canvas.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cam.GetComponent<MouseLook>().enabled = true;
    }

    public void Update()
    {
        if (textOB.text == "Right")
        {
            ani.GetComponent<Animator>().SetTrigger("Activate");
            Exit();
            logic();
        }

        if (keyPadOB.activeInHierarchy)
        {
            canvas.SetActive(false);
            inventory.SetActive(false);
            player.GetComponent<CharacterController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cam.GetComponent<MouseLook>().enabled = false;
        }
    }

    public void logic()
    {
        Destroy(keyPadOB);
    }
}