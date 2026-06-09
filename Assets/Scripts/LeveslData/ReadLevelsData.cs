using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadLevelsData : MonoBehaviour
{
    public LevelsData lv;
    public int level;
    public GameObject bloqued, bronze, silver, gold; 
    
    void Awake()
    {
        if (lv.levels[level]==0)
        {
            bloqued.SetActive(true);
            bronze.SetActive(false);
            silver.SetActive(false);
            gold.SetActive(false);
        }
        else if (lv.levels[level]==1) 
        {
            bloqued.SetActive(false);
            bronze.SetActive(false);
            silver.SetActive(false);
            gold.SetActive(false);
        }
        else if (lv.levels[level]==2)
        {
            bloqued.SetActive(false);
            bronze.SetActive(true);
            silver.SetActive(false);
            gold.SetActive(false);
        }
        else if (lv.levels[level]==3)
        {
            bloqued.SetActive(false);
            bronze.SetActive(false);
            silver.SetActive(true);
            gold.SetActive(false);
        }
        else if (lv.levels[level]==4)
        {
            bloqued.SetActive(false);
            bronze.SetActive(false);
            silver.SetActive(false);
            gold.SetActive(true);
        }
    }
    
}
