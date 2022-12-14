using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_FadeIn : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip musicAudioclip;
    private bool isPlayed;

   
    public GameObject musicSourceGO;
    
    
    public GameObject familyMusicSourceGO;
    public AudioSource familymuiscaudioSource;
 
    
    public void Start()
    {
        musicSourceGO.SetActive(false); 
        familyMusicSourceGO.SetActive(false);   
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Red_Trigger")
        {
            musicSourceGO.SetActive(true);
            StartCoroutine(StartFade(musicAudioSource, 30f , 0.3f));

        }

    

        if (collision.gameObject.name == "familyPotrait_Trigger")
        {
            familyMusicSourceGO.SetActive(true);
            StartCoroutine(StartFade(familymuiscaudioSource, 30f, 0.4f));

        }
    }


  
        public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }


    

  



}