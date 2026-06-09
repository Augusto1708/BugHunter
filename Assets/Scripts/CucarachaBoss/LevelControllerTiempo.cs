using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelControllerTiempo : MonoBehaviour, ILevelController
{
    [SerializeField] float levelCounter=0;
    [SerializeField]  StarsNextLevel SNL;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float bronzeTime, silverTime;
    [SerializeField] int score;
    
    
    [SerializeField] GameObject winPanel,losePanel;
    [Header("Sound")]

    [SerializeField] LevelSounds levelSounds;
    
    void Update()
    {
            levelCounter += Time.deltaTime;
            timeText.text = levelCounter.ToString("F1");
        
      
    }
    public void KillBug()
    {
        winPanel.SetActive(true);
        if(levelCounter>=bronzeTime)
        {
            score = 1;
        }
        else if(levelCounter>=silverTime&&levelCounter<bronzeTime)
        {
            score = 2;
        }
        else if (levelCounter<silverTime )
        {
            score = 3;
        }
        if(levelSounds!=null) 
        {
            levelSounds.WinMusic();
        }
        SNL.ActualScore(score);
        SNL.UnlockNextLevel();

    }
    public void BugIsScaped(int bugsScaped)
    {
       #if UNITY_EDITOR
        Debug.Log("seactivaBUgScaped");
       #endif

        Lose();
    }
    public void Lose()
    {
        if (levelSounds != null)
        {
            levelSounds.LoseMusic();
        }
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
  
}
