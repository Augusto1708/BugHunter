using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public LevelsData lv;
   
    void Start()
    {
        SaveSystem.LoadLevels(lv); 
    }

  
   
}
