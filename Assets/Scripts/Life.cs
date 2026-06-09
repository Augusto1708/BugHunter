using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Life : MonoBehaviour
{
    private ILevelController levelController;
    [SerializeField] RandomMovement movementScript;//cambiar por una interface
    [SerializeField] LinealMovement linealMovementScript;
    [SerializeField] GameObject alive,dead;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Collider2D col;
    public int life=1;
    public bool isArmored=false;
    [Header("SpiderMother")]
    [SerializeField] SpiderFather SF;
    [Header("Sound")]
    [SerializeField] CriatureSounds CS;
    

    private void Awake()
           
    {
        CS = GetComponent<CriatureSounds>();

        MonoBehaviour[] todosLosScripts = FindObjectsOfType<MonoBehaviour>();

 
        foreach (MonoBehaviour script in todosLosScripts)
        {
            if (script is ILevelController)
            {
                levelController = (ILevelController)script;
                break; 
            }
        }

        if (levelController == null)
        {
          #if UNITY_EDITOR
            Debug.LogWarning("Oye, no encontré nada con ILevelController en la escena.");
         #endif

        }
    }

    public void GetHit()
    {
        if(isArmored==false)
        {
         #if UNITY_EDITOR
            Debug.Log("¡Mosca golpeada de verdad!");
         #endif


            life--;
            if(life<=0)
            {
                col.enabled = false;
                alive.SetActive(false);
                if (movementScript != null)
                {
                    movementScript.CancelInvoke();
                    movementScript.enabled = false;
                }
                else if (linealMovementScript != null)
                {
                 #if UNITY_EDITOR
                    Debug.Log("MuereLineal");
                 #endif

                    linealMovementScript.enabled=false;
                }
                
                rb2d.velocity = Vector3.zero;
                rb2d.angularVelocity = 0;
                dead.SetActive(true);
                Invoke("Desaparece", 2.5f);
                if(CS!=null)
                {
                    CS.PlayDead();
                }
                
            }
            
           
        }
        else
        {
         #if UNITY_EDITOR
            Debug.Log("¡no me duele!");
         #endif
        }
       
    }
    private void Desaparece()
    {
     if(SF!=null)
        {
            SF.Born();
        }
        gameObject.SetActive(false);
        levelController.KillBug();

    }
}

