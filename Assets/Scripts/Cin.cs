using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cin : MonoBehaviour
{

    void OnEnable()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }


}