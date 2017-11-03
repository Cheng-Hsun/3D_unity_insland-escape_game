using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutThrower : MonoBehaviour
{
    public Rigidbody coconut;
    public AudioClip throwSound;
    public static bool canThrow = false;

	void Update ()
    {
		if(Input.GetButtonDown("Fire1") && canThrow)
        {
            GetComponent<AudioSource>().PlayOneShot(throwSound);
            Rigidbody newCoconut = Instantiate(coconut, transform.position, transform.rotation);
            newCoconut.name = "coconut";
            newCoconut.velocity = transform.forward * 80;

            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newCoconut.GetComponent<Collider>(), true);
        }
	}
}
