using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    
    public float instanceTime;
    public GameObject[] bugs;
    public int bugsCounter=-1;
  
    void Start()
    {
       
        for(int i = 0; i < bugs.Length; i++) 
        {
            bugs[i].SetActive(false);
        }
        Invoke("Instance", instanceTime);

    }

    void Instance()
    {
        bugsCounter++;
        if(bugsCounter < bugs.Length)
        {
            bugs[bugsCounter].SetActive(true);
            Invoke("Instance", instanceTime);
        }
        
    }
}
