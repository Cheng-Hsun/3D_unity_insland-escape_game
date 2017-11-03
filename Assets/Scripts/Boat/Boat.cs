using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(Inventory.haveHammer && !REF.boatRepair)
        {
            Destroy(GameObject.Find("hammerGUI"));
            REF.boatRepair = true;
            Dialogue.info = "小船已經修好！去告訴Ref一聲吧！";
            Dialogue.title = "修船完成";
            Dialogue.talk = true;
            transform.Rotate(180, 0, 0);
            GetComponent<AudioSource>().Play();
        }
    }
}
