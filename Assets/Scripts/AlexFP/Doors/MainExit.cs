using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class MainExit : MonoBehaviour
{
    public GameObject player;
    public GameObject keyPadOB;
    public GameObject canvas;
    public GameObject inventory;
    public GameObject Cam;
    public GameObject gunny;

    public GameObject animatOBRight;
    public Animator aniRight;
    public GameObject animatOBLeft;
    public Animator aniLeft;

    public AudioSource buttonSound;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public AudioSource openGateSound;
    public AudioSource FootstepsSound;

    [SerializedField] public TextMeshProUGUI textOB;

    public string answer = "12345";

    public bool animate;

    void start()
    {
        keyPadOB.SetActive(false);
    }

    public void Number(int number)
    {
        buttonSound.Play();
        if (textOB.text != "Wrong")
        {           
            textOB.text += number.ToString();
        }
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
            correctSound.Play();
            textOB.text = "Right";
        }
        else
        {
            wrongSound.Play();
            textOB.text = "Wrong";
        }
    }

    public void Clear()
    {
        {
            buttonSound.Play();
            textOB.text = "";
        }
    }

    public void Exit()
    {
        keyPadOB.SetActive(false);
        inventory.SetActive(true);
        canvas.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<FootSteps>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cam.GetComponent<MouseLook>().enabled = true;
        gunny.GetComponent<GunSystem>().enabled = true;
    }

    public void Update()
    {
        if (textOB.text == "Right")
        {
            openGateSound.Play();
            Exit();
            logic();
            aniRight.GetComponent<Animator>().SetTrigger("Activate");
            aniLeft.GetComponent<Animator>().SetTrigger("Activate");
        }

        if (keyPadOB.activeInHierarchy)
        {
            canvas.SetActive(false);
            inventory.SetActive(false);
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<FootSteps>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cam.GetComponent<MouseLook>().enabled = false;
            gunny.GetComponent<GunSystem>().enabled = false;
        }
    }
    
    public void logic()
    {
        Destroy(keyPadOB);
        gunny.GetComponent<GunSystem>().enabled = false;
    }
}