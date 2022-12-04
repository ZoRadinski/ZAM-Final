using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterPlay : MonoBehaviour
{

    void OnEnable()
    {
        SceneManager.LoadScene("Cinematic", LoadSceneMode.Single);
    }


}