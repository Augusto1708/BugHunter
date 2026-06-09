using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAplastable
{
    
    void GetHit();
}
public interface ILevelController
{
    void KillBug();
    void BugIsScaped(int bugsScaped);
}
public enum TipoArma { Dedo, Martillo}
public class Interfaces : MonoBehaviour
{

}
