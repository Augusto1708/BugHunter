using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFather : MonoBehaviour
{
    [SerializeField] GameObject[] spidersSons; 
   
    void Update()
    {
        
    }
    public void Born()
    {
        for(int i = 0; i < spidersSons.Length; i++) 
        {
           #if UNITY_EDITOR
            Debug.Log("creaHijo");
           #endif

            if (spidersSons[i]!=null)
            {
                spidersSons[i].gameObject.SetActive(true);
                spidersSons[i].transform.SetParent(null);
            }
           
        }
    }
}
