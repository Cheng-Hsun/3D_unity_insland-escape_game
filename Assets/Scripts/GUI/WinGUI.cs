using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGUI : MonoBehaviour
{
	void Start ()
    {
        gameObject.SetActive(false);
        Invoke("Active", 2.0f);
	}

    private void Active()
    {
        gameObject.SetActive(true);
    }
}
