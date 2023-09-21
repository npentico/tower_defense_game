using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUIScript : MonoBehaviour
{
    [SerializeField] GameObject settingsCanvas;

    public void EnableSettingsCanvas(){
        settingsCanvas.SetActive(true);
    }
     public void DisableettingsCanvas(){
        settingsCanvas.SetActive(true);
    }

    public void ToggleSettingsCanvas(){
        settingsCanvas.SetActive(!settingsCanvas.activeSelf);
    }
}
