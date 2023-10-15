using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUIScript : MonoBehaviour
{
    [SerializeField] GameObject settingsCanvas;
    [SerializeField] AudioClip buttonAudio;

    public void EnableSettingsCanvas(){
        settingsCanvas.SetActive(true);
    }
     public void DisableSettingsCanvas(){
        settingsCanvas.SetActive(true);
    }

    public void ToggleSettingsCanvas(){
        settingsCanvas.SetActive(!settingsCanvas.activeSelf);
      AudioManager.instance.PlaySFX(buttonAudio);
        
    }
}
