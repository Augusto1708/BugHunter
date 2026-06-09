using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour, ILevelController
{
    [SerializeField] Instanciador instanciador;
    [SerializeField] int numBugs;
    [SerializeField] int eliminatedBugs, scapeBugs; 
    [SerializeField] int maxScapedBugs;
    [SerializeField] TextMeshProUGUI scapeBugsText;
    [SerializeField] GameObject YouLose,win;
    [Header("Win")]
    [SerializeField] int sonOfBugs=0;

   
    public StarsNextLevel SNL;
    [Header("Sonido")]
    [SerializeField] LevelSounds levelSounds;
   

    private void  Awake()
    {
        GameObject objetoSonido = GameObject.Find("SoundLevel");

        if (objetoSonido != null)
        {
           
            levelSounds = objetoSonido.GetComponent<LevelSounds>();
        }
        
    }
        
    void Start()
    {
       
        if(instanciador != null)
        {
            numBugs = instanciador.bugs.Length;
        }
        
        scapeBugsText.text = scapeBugs + " / " + maxScapedBugs;
    }

    
    public void KillBug()
    {
        eliminatedBugs++;
        WinCondition();
    }
    public void BugIsScaped(int bugsScaped)
    {
        scapeBugs=scapeBugs+bugsScaped;
        scapeBugsText.text = scapeBugs + "/" + maxScapedBugs;
        if(scapeBugs >= maxScapedBugs)
        {
         #if UNITY_EDITOR
            Debug.Log("se escaparon todos");
         #endif

            Lose();
        }
        else
        {
            WinCondition();
        }
      
           
        
    }

     void WinCondition()
    {
      if (eliminatedBugs + scapeBugs == numBugs+sonOfBugs)
        {
            Win();
        }
    }
    void Lose()
    {
        if(YouLose!=null)
        {
            YouLose.SetActive(true);
            if(levelSounds!=null)
            {
                levelSounds.LoseMusic();
            }
           
            Time.timeScale = 0;

        }
        
    }
    void Win()
    {
        if(levelSounds!=null)
        {
            levelSounds.WinMusic();
        }
        
        SNL.ActualScore(eliminatedBugs);
        SNL.UnlockNextLevel();
        win.SetActive(true);
        Time.timeScale = 0;


    }
   
}
