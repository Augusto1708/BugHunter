using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoRandomMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeToSpin;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float minTimeToSpin;
    [SerializeField] float maxTimeToSpin;
    [SerializeField] int angle;

    void Start()
    {
        Invoke("Spin", timeToSpin);
    }

  
    void Update()
    {
        rb2d.velocity = transform.up * speed;
    }
    private void Spin()
    {
        timeToSpin = Random.Range(minTimeToSpin, maxTimeToSpin);


        angle = Random.Range(10, 350);
        transform.rotation = Quaternion.Euler(0, 0, angle);



        Invoke("Spin", timeToSpin);
    }

    private void OnBecameInvisible()
    {
     #if UNITY_EDITOR
        Debug.Log("EntraENLimits");
     #endif


        angle = angle + 180;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
