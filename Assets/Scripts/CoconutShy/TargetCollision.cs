using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    private bool beenHit = false;
    public static float resetTime = 1.0f;

    private Animation targetAni;
    public AudioClip hitSound;
    public AudioClip resetSound;

    void Start()
    {
        targetAni = transform.parent.parent.GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(beenHit == false && collision.gameObject.name == "coconut")
        {
            StartCoroutine("TagerHit");
        }
    }

    private IEnumerator TagerHit()
    {
        GetComponent<AudioSource>().PlayOneShot(hitSound);
        targetAni.Play("down");
        beenHit = true;
        CoconutWin.targetCount++;

        yield  return new WaitForSeconds(resetTime);

        GetComponent<AudioSource>().PlayOneShot(resetSound);
        targetAni.Play("up");
        beenHit = false;
        CoconutWin.targetCount--;
    }
}
