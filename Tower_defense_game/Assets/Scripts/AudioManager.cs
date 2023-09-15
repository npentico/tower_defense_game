using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource myAudioSource;

    [SerializeField] AudioSource sfxPlayer;
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

   public void PlaySFX(AudioClip clip, float volume){
        sfxPlayer.PlayOneShot(clip,volume);
   }
}
