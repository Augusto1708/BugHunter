using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class LinealMovement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] bool canScape=false;
    [SerializeField] ILevelController levelController;
    [SerializeField] int bugsScaped = 1;
    [Header("Sonidos")]
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
            Debug.LogWarning("no encontre nada con ILevelController en la escena.");
         #endif

        }
        canScape = false;
    }

   
    void Update()
    {
        rb2d.velocity = transform.up * speed;
    }

    
    
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Limits"))
        {
            if (!canScape) 
            {
                canScape = true;

            }

           else if (canScape == true)
            {
                CS.PlayScape();
              #if UNITY_EDITOR
                Debug.Log("yuju me escapo, perdedor");
              #endif

                levelController.BugIsScaped( bugsScaped);
                gameObject.SetActive(false);
            }

        }

    }
}
