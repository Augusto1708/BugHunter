using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayMenu : MonoBehaviour
{
    [SerializeField] GameObject menu, choseLevel,firstPlay,secondPlay;
    [SerializeField] float timeToChangue;
   
    public void PlayMenu()
    {
        firstPlay.SetActive(false);
        secondPlay.SetActive(true);
        Invoke("ChoseLevel", timeToChangue);
    }
    public void ChoseLevel()
    { 
        secondPlay.SetActive(false);
        firstPlay.SetActive(true);
        menu.SetActive(false);
        choseLevel.SetActive(true);
    } 
}
