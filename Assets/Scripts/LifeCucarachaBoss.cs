using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCucarachaBoss : MonoBehaviour
{
    //[SerializeField] LevelControllerTiempo levelController;
    //[SerializeField] RandomMovement movementScript;//cambiar por una interface
    //[SerializeField] LinealMovement linealMovementScript;
    //[SerializeField] GameObject alive, dead;
    //[SerializeField] Rigidbody2D rb2d;
    //[SerializeField] Collider2D col;
    //public int life = 1;
    //public bool isArmored = false;

    //private void Awake()
    //{
    //    levelController = FindObjectOfType<LevelControllerTiempo>();
    //}

    //public void GetHit()
    //{
    //    if (isArmored == false)
    //    {
    //        Debug.Log("¡Mosca golpeada de verdad!");

    //        life--;
    //        if (life <= 0)
    //        {
    //            col.enabled = false;
    //            alive.SetActive(false);
    //            if (movementScript != null)
    //            {
    //                movementScript.CancelInvoke();
    //                movementScript.enabled = false;
    //            }
    //            else if (linealMovementScript != null)
    //            {
    //                linealMovementScript.enabled = false;
    //            }

    //            rb2d.velocity = Vector3.zero;
    //            rb2d.angularVelocity = 0;
    //            dead.SetActive(true);
    //            Invoke("Desaparece", 2.5f);
    //        }


    //    }
    //    else
    //    {
    //        Debug.Log("¡no me duele!");
    //    }

    //}
    //private void Desaparece()
    //{
    //    gameObject.SetActive(false);
    //    levelController.Dead();

    //}
}

