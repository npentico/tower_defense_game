using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    
    public static SceneManager instance;

    public GameObject levelCanvas;

    void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance = this;
           
        }
    }

    public void LoadLevel(string levelToLoad){
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);

    }

    public void LoadLevel(int levelToLoad){
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);

    }

    public void LoadTutorialLevel(){
        LoadLevel("Tutorial Scene");
    }

    public void LoadMainMenu(){
        LoadLevel("Title Screen");
    }

    public void LoadEndingScene(){
        LoadLevel("Ending Screen");
    }

    public void DisableLevelCanvas(){
        levelCanvas.SetActive(false);
    }

    public void EnableLevelCanvas(){
        levelCanvas.SetActive(true);
    }

}
