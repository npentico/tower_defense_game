using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource myAudioSource;
    void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance= this;
        }

        myAudioSource =  GetComponent<AudioSource>();
    }
   
   public void PlaySoundClip(AudioClip clip, float volume){
            myAudioSource.PlayOneShot(clip,volume);
   }
}
