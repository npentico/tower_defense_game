using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelScript : MonoBehaviour
{
    [SerializeField] int Score;

    [SerializeField] string sceneToLoad;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start(){
        scoreText.text = Score + ""; 
    }

    public void LoadThisScene(){
        SceneManager.instance.LoadLevel(sceneToLoad);
    }
}
