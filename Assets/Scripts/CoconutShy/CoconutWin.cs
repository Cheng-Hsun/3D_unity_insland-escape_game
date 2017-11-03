using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutWin : MonoBehaviour
{
    public static int targetCount = 0;
    public static bool haveWon = false;

    public AudioClip winSound;
    public GameObject powerCell;

    void Update()
    {
		if(targetCount == 3 && !haveWon)
        {
            targetCount = 0;
            GetComponent<AudioSource>().PlayOneShot(winSound);
            GameObject winCell = transform.Find("powerCell").gameObject;
            winCell.transform.Translate(-1, 0, 0);
            Instantiate(powerCell, winCell.transform.position, transform.rotation);
            Destroy(winCell);
            haveWon = true;
            Warrior.missionCompleted = true;
        }
    }
}
