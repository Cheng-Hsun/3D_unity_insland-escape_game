using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerAngles : MonoBehaviour
{
    private Vector3 oldAngles;

	void Start ()
    {
        oldAngles = transform.eulerAngles;
	}

    private void OnMouseEnter()
    {
        transform.LookAt(Inventory.player);
    }

    private void OnMouseExit()
    {
        transform.eulerAngles = oldAngles;
    }
}
