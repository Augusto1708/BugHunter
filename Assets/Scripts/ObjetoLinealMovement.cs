using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObjetoLinealMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeToChangue;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Vector2 direction;
    [SerializeField] bool upDown;
    [SerializeField] bool direccionpositiva;
  
    void Start()
    {
        Invoke("ChangueDirection", timeToChangue);
    }

   
    void Update()
    {
        rb2d.velocity = direction * speed;
    }
    void ChangueDirection()
    {
      if(!upDown)
        {
            if (direccionpositiva)
            {
                direction = -transform.right;
                direccionpositiva = false;
            }
           
           else if(!direccionpositiva)
            {
                direction = transform.right;
                direccionpositiva = true;
            }
        }
       else if (upDown)
        {
            if (direccionpositiva)
            {
                direction = -transform.up;
                direccionpositiva = false;
            }

            else if (!direccionpositiva)
            {
                direction = transform.up;
                direccionpositiva = true;
            }
        }
        Invoke("ChangueDirection", timeToChangue);
    }
}
