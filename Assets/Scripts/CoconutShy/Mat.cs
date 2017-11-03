using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat : MonoBehaviour
{
    public UnityEngine.UI.RawImage crossHair;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Warrior.haveCoconut)
        {
            CoconutThrower.canThrow = true;
            crossHair.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CoconutThrower.canThrow = false;
            crossHair.enabled = false;
        }
    }
}
