using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBot : MonoBehaviour
{
    public static Animator ani;

	void Start ()
    {
        ani = GetComponent<Animator>();
    }
}
