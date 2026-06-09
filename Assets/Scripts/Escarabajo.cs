using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escarabajo : MonoBehaviour
{
    [SerializeField] Life life;
    [SerializeField] bool isArmored;
    [SerializeField] Animator animator;
    [SerializeField] float armorTime, noArmorTime;

    
    void Start()
    {
        Invoke("Armored", armorTime);
    }
    public void Armored()
    {
        
        life.isArmored = true;
        animator.SetBool("Walk",true);
        Invoke("NoArmored", noArmorTime);
    }
    public void NoArmored()
    {
       
        life.isArmored = false;
        animator.SetBool("Walk", false);
        Invoke("Armored", armorTime);
    }

    
    void Update()
    {
        
    }
}
