using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
   

    public void PusePlay(bool isPlay)
    {
        if (isPlay) 
        {
         
            StartCoroutine(WaitToPlay());

        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void LetsPLay()
    {
     #if UNITY_EDITOR
        Debug.Log("se activa mariposa");
     #endif

        Time.timeScale = 1;
        MenuPanel.SetActive(false);
    }
    IEnumerator WaitToPlay()
    {
      
        yield return new WaitForSecondsRealtime(1f);

        LetsPLay();
    }
}
