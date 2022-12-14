using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OptionsScreen : MonoBehaviour
{
    
   
    public TMP_Text resolutionLabel;
    private int selectResolution;
    public List<ResItem> resolutions = new List<ResItem>();
    public Toggle fullscreenTog, vsyncTog;
    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectResolution = i;

                UpdateResLabel();
            }
        }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectResolution = resolutions.Count - 1;

            UpdateResLabel();
        }

       
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResLeft()
    {
        selectResolution--;
        if (selectResolution < 0)
        {
            selectResolution = 0;
        }

        UpdateResLabel();
    }
    public void ResRight()
    {
        selectResolution++;
        if (selectResolution > resolutions.Count - 1)
        {
            selectResolution = resolutions.Count - 1;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectResolution].horizontal.ToString() + " x " + resolutions[selectResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {


        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        Screen.SetResolution(resolutions[selectResolution].horizontal, resolutions[selectResolution].vertical, fullscreenTog.isOn);
    }
  
   
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
