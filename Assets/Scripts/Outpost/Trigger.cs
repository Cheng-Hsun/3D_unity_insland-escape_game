using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Light doorLight;
    public AudioClip doorLockedSound;
    public UnityEngine.UI.Text doorMessage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(Inventory.haveICCard)
            {
                Destroy(GameObject.Find("ICcardGUI"));

                doorLight.color = Color.green;
                transform.Find("door").SendMessage("OpenDoor");
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(doorLockedSound);
            }
        }
    }
}
