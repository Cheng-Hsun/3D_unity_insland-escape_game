using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragon : MonoBehaviour
{
    public GameObject[] VolcanicFlame;
    public AudioClip playerDieSound;
    public GameObject player;
    public GameObject loseGUI;
    public static bool playerLose;
    public Light sunLight;

    void Start()
    {
        playerLose = false;
        loseGUI.SetActive(false);
    }

    public IEnumerator VolcanicEruption()
    {
        VolcanicFlame[0].GetComponent<Renderer>().enabled = true;
        VolcanicFlame[1].GetComponent<Renderer>().enabled = true;
        VolcanicFlame[2].GetComponent<Renderer>().enabled = true;
        VolcanicFlame[3].GetComponent<Renderer>().enabled = true;
        GetComponent<AudioSource>().Play();
        sunLight.intensity = 0.5f;

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("Victory");
    }

    public IEnumerator KillPlayer()
    {
        player.transform.position = new Vector3(300, 30, 600);
        GetComponent<AudioSource>().PlayOneShot(playerDieSound);

        yield return new WaitForSeconds(1.0f);

        loseGUI.SetActive(true);
        loseGUI.GetComponent<AudioSource>().Play();
        playerLose = true;
    }
}
