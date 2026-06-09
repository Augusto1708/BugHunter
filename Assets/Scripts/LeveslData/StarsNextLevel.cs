using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsNextLevel : MonoBehaviour
{
    [SerializeField] LevelsData lv;
    [SerializeField] int actualLevel, nextLevel;
    [SerializeField] int scoreToBronze, scoreToSilver, scoreToGold;
    [SerializeField] GameObject[] stars=new GameObject[3];
  


    public void ActualScore(int score)
    {
        if(score >= scoreToBronze&&score<scoreToSilver)
        {
            if (lv.levels[actualLevel] < 3)
            {
                lv.levels[actualLevel] = 2;
                if (stars[0]!=null)
                {
                    stars[0].gameObject.SetActive(true);
                }
               
            }
        }
        else if (score>=scoreToSilver && score<scoreToGold)
        {
            if (lv.levels[actualLevel] < 4)
            {
                lv.levels[actualLevel] = 3;
                if (stars[1] != null)
                {
                    stars[1].gameObject.SetActive(true);
                }
            
            }
        }
        if(score >= scoreToGold)
        {
            lv.levels[actualLevel] = 4;
            if (stars[2] != null)
            {
                stars[2].gameObject.SetActive(true);
            }

        }
        SaveSystem.SaveLevels(lv);
    }
    public void UnlockNextLevel()
    {
        if(lv!=null)
        {
            if(lv.levels[nextLevel] == 0)
            {
                lv.levels[nextLevel] = 1;
            }
       
            SaveSystem.SaveLevels(lv);
        }
        
      
    }

}
