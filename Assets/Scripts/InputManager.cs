using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InputManager : MonoBehaviour
{
    public TipoArma tipoArma = TipoArma.Dedo;
    [Header("raycast")]
    Vector2 mousePos2D;
    Collider2D hit;
    [Header("martillo")]
    [SerializeField] Image barraImagen;
    [SerializeField] GameObject martillazo;
    [SerializeField] bool aumentafill=false;
    [SerializeField] float tiempoRecarga;
    


    public void CambioArmaDedo()
    {
        tipoArma = TipoArma.Dedo;
    }
    public void CambioArmaMartillo()
    {
        tipoArma = TipoArma.Martillo;
    }


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)&&Time.timeScale!=0)
        {
            DetectarObjeto();
        }
      
        if (barraImagen !=null &&barraImagen.fillAmount > 0f&&aumentafill)
        {
           
            barraImagen.fillAmount -= Time.deltaTime / tiempoRecarga;
        }
    }
    void GolpeMartillo()
    {
        aumentafill = false;
        if(barraImagen!=null)
        {
            barraImagen.fillAmount = 1;
        }
        if(martillazo!=null) 
        {
            martillazo.gameObject.SetActive(false);
        }
       
       
        if(hit!=null)
        {
            if (hit.gameObject.layer == LayerMask.NameToLayer("Shield"))
            {
             #if UNITY_EDITOR
                Debug.Log("Escudo!");
             #endif
                
                return;

            }

            if (hit.gameObject.layer == LayerMask.NameToLayer("BugMartillo"))
            {
             #if UNITY_EDITOR
                Debug.Log("BugMartillo");

             #endif
                hit.GetComponent<Life>().GetHit();
                return;

            }

            if (hit.gameObject.layer == LayerMask.NameToLayer("Bug"))
            {

                hit.GetComponent<Life>().GetHit();
              #if UNITY_EDITOR
                Debug.Log("¡Mosca golpeada en teoria!");
              #endif

            }
           // tipoArma = TipoArma.Dedo;
        }
       
    }

    void DetectarObjeto()
    {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         mousePos2D = new Vector2(mousePos.x, mousePos.y);

        
         hit = Physics2D.OverlapPoint(mousePos2D);
        if (tipoArma == TipoArma.Martillo)
        {
            if(martillazo!=null)
            {
                martillazo.gameObject.SetActive(true);
                martillazo.transform.localPosition = mousePos2D;
            }
           
            aumentafill = true;
            Invoke("GolpeMartillo", tiempoRecarga);
        }
        if (tipoArma == TipoArma.Dedo)
        {
            if (hit != null)
            {
            
                if (hit.gameObject.layer == LayerMask.NameToLayer("Shield"))
                {
                  #if UNITY_EDITOR
                    Debug.Log("Escudo!");
                  #endif

                    return;

                }
               
                if (hit.gameObject.layer == LayerMask.NameToLayer("Bug"))
                {
                    
                    hit.GetComponent<Life>().GetHit();
                 #if UNITY_EDITOR
                    Debug.Log("¡Mosca golpeada en teoria!");
                 #endif

                }

            }
          
         
        }

    }
}