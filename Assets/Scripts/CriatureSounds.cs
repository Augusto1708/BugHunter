using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class CriatureSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip scapeClip;
    public AudioClip deadClip;

    private void Awake()
    {
       audioSource= GetComponent<AudioSource>();
    }
  
    public void PlayDead()
    {
        audioSource.PlayOneShot(deadClip);
    }
    public void PlayScape()
    {
        Debug.Log("debesonarescape");
     
        AudioSource.PlayClipAtPoint(scapeClip, Camera.main.transform.position);
    }
}
