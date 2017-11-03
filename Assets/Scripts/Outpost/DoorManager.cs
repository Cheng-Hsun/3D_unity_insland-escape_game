using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private bool doorIsOpen = false;
    private float doorTime = 0.0f;
    private float dialogueTime = 0.0f;
    private float guiSkinTime = 0.0f;

    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;

    void Update()
    {
        if (doorIsOpen)
        {
            doorTime += Time.deltaTime;
            if (doorTime > 3.0f)
            {
                ShutDoor();
                doorTime = 0.0f;
            }
        }

        if(Dialogue.talk)
        {
            dialogueTime += Time.deltaTime;
            if (dialogueTime > 3.0f)
            {
                Dialogue.talk = false;
                dialogueTime = 0.0f;
            }
        }

        if (MyGUISkin.talk && !Campfire.fireIgnite)
        {
            guiSkinTime += Time.deltaTime;
            if (guiSkinTime > 7.0f)
            {
                MyGUISkin.talk = false;
            }
        }

        if(!MyGUISkin.talk)
        {
            guiSkinTime = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Dialogue.title = "當前任務";
            Dialogue.info = Inventory.currentMission;
            Dialogue.talk = !Dialogue.talk;
        }
    }

    private void OpenDoor()
    {
        doorIsOpen = true;
        GetComponent<AudioSource>().PlayOneShot(doorOpenSound);
        transform.parent.gameObject.GetComponent<Animation>().Play("openDoor");
    }

    private void ShutDoor()
    {
        doorIsOpen = false;
        GetComponent<AudioSource>().PlayOneShot(doorShutSound);
        transform.parent.gameObject.GetComponent<Animation>().Play("shutDoor");
    }
}
