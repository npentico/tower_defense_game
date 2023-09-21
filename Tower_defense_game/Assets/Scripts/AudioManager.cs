using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource myAudioSource;

    [SerializeField] AudioSource sfxPlayer;
    [SerializeField] AudioSource musicPlayer;
    
        void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance= this;
            DontDestroyOnLoad(gameObject);
        }

        myAudioSource =  GetComponent<AudioSource>();
    }
   
   public void PlaySoundClip(AudioClip clip, float volume){
            myAudioSource.PlayOneShot(clip,volume);
   }

   public void PlaySFX(AudioClip clip, float volume){
        sfxPlayer.PlayOneShot(clip);
   }

   public void UpdateMusicVolume(float volume){
        musicPlayer.volume = volume;
   }
   public void UpdateSFXVolume(float volume){
        sfxPlayer.volume = volume;
   }
}
