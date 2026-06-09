using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] float speed; 
    [SerializeField] float timeToSpin; 
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float angleSpeed;
    [SerializeField] float minAngleSpeed,maxAngleSpeed;
    [Header("Fast")]
    [SerializeField] bool isFast;
    [SerializeField] float minTimeToSpin;
    [SerializeField] float maxTimeToSpin;
    [SerializeField] int angle;
    [Header("CanScape")]
    public bool canScape=true;
    public float timeToScape;
    [SerializeField] BugScape bugScape;
    [Header("Son")]
    [SerializeField] bool isSon = false;
   





    void Update()
    {
      rb2d.velocity=transform.up*speed;
    }

    private void Spin()
    {
        timeToSpin=Random.Range(minTimeToSpin,maxTimeToSpin);
        if(isFast )
        {
            angle = Random.Range(10, 350);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            angleSpeed = Random.Range(minAngleSpeed, maxAngleSpeed);
            rb2d.angularVelocity = angleSpeed;
            Invoke("BrakeSpin", 1.5f);
        }
       
         Invoke("Spin", timeToSpin);

    }
    private void BrakeSpin()
    {
        rb2d.angularVelocity = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer== LayerMask.NameToLayer("Limits"))
        {
            if(canScape==false) 
            {
                if (isFast)
                {
                    angle = angle + 180;
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }
                else
                {

                    CancelInvoke("Spin");
                    rb2d.angularVelocity = 360;
                    Invoke("BrakeSpin", 0.5f);
                    Invoke("Spin", timeToSpin);
                }
            }
      

        }
      
    }
    private void OnCollisionExit2D(Collision2D collision)//la primera vez no cuenta y apartir deque entre puede escapar
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Limits"))
        {
            Invoke("Spin", timeToSpin);
            canScape = false;
            Invoke("CanScape", timeToScape);
        }
        
    }
    private void CanScape()
    {
        if(bugScape!=null)
        {
            canScape = true;
            CancelInvoke("Spin");
            bugScape.firstExit = false;
        }
    
    }
    private void OnEnable()
    {
        if(isSon)
        {
            Invoke("Spin", timeToSpin);
            canScape = false;
            Invoke("CanScape", timeToScape);

        }
    }


}
