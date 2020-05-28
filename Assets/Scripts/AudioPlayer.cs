using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   public AudioClip[] playlist;

   public int currentTrack;

   void Start()
   {
      //currentTrack = 1;
      
      GetComponent<AudioSource>().clip = playlist[currentTrack];
      GetComponent<AudioSource>().Play();
   }

   void Update()
   {
      
     
      
      if (GetComponent<AudioSource>().isPlaying == false)
      {
         currentTrack++;
         
      }

      if (Input.GetKeyDown("o"))
      {
         GetComponent<AudioSource>().Stop();
         currentTrack--;
         if (currentTrack < 0)
         {
            currentTrack = playlist.Length-1;
            GetComponent<AudioSource>().clip = playlist[currentTrack];
            GetComponent<AudioSource>().Play();
         }
         else
         {
            GetComponent<AudioSource>().clip = playlist[currentTrack];
            GetComponent<AudioSource>().Play();
         }
        
      }
      
      if (Input.GetKeyDown("p"))
      {
         GetComponent<AudioSource>().Stop();
         currentTrack++;
         if (currentTrack >= playlist.Length)
         {
            currentTrack = 0;
            GetComponent<AudioSource>().clip = playlist[currentTrack];
            GetComponent<AudioSource>().Play();
         }
         else
         {
            GetComponent<AudioSource>().clip = playlist[currentTrack];
            GetComponent<AudioSource>().Play();
         }
        
      }
   }
}
