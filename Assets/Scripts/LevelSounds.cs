using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSounds : MonoBehaviour
{
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    private void Awake()
    {
        AS=GetComponent<AudioSource>();

    }
   
    public void WinMusic()
    {
        AS.Stop();
        AS.clip = winSound;
        AS.loop = false;
        AS.Play();
     
    }
    public void LoseMusic()
    {
     
        AS.Stop();
        AS.clip = loseSound;
        AS.loop = false;
        AS.Play();
    }


}
