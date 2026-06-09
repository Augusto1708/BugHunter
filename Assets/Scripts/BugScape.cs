using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugScape : MonoBehaviour
{
    [SerializeField] LevelController levelController;
    [SerializeField] int bugsScaped=1;//cuando es un padre y escapa con sus hijos

 
    public bool firstExit=true;
    [Header("Sound")]
    [SerializeField] CriatureSounds CS;
    private void Awake()
    {
        CS = GetComponent<CriatureSounds>();

        levelController = FindObjectOfType<LevelController>();
    }
  
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Limits"))
        {
           
             if(firstExit==false)
            {
                CS.PlayScape();
                Debug.Log("yuju me escapo, perdedor");
                levelController.BugIsScaped(bugsScaped);
              
                gameObject.SetActive(false);
           
            }

        }
        
    }
   
}
