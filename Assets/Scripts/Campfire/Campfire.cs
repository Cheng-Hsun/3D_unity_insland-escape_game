using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public static bool fireIgnite;
    public AudioClip strikeSound;
    public GameObject bakedEgg;
    public GameObject dragon;

    void Start()
    {
        fireIgnite = false;
        dragon.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && fireIgnite && !Dragon.playerLose)
        {
            GetComponent<AudioSource>().enabled = false;
            MyGUISkin.talk = false;

            Dialogue.title = "戰鬥龍";
            Dialogue.info = "區區苗小的人類竟敢對偉大的吾如此大放厥詞！吾要降災於汝！";
            Dialogue.talk = true;
            dragon.SendMessage("VolcanicEruption");
        }

        if (Input.GetKeyDown(KeyCode.E) && fireIgnite && !Dragon.playerLose)
        {
            GetComponent<AudioSource>().enabled = false;
            MyGUISkin.talk = false;

            Dialogue.title = "戰鬥龍";
            Dialogue.info = "好吧！我就讓你離開這座島！";
            Dialogue.talk = true;
            dragon.SendMessage("KillPlayer");
        }
    }

    private void OnMouseDown()
    {
        if (Inventory.haveMatch && Teddy.missionTwoAccept && !fireIgnite)
        {
            AudioSource.PlayClipAtPoint(strikeSound, transform.position);
            Inventory.haveMatch = false;
            Destroy(Inventory.matchGUI);

            Invoke("Ignite", 1.5f);
        }
    }

    void Ignite()
    {
        fireIgnite = true;
        transform.Find("fire").GetComponent<AudioSource>().Play();
        transform.Find("smoke").GetComponent<Renderer>().enabled = true;
        transform.Find("fire").GetComponent<Renderer>().enabled = true;

        Invoke("EggHatch", 3.0f);
    }

    private void EggHatch()
    {
        Destroy(bakedEgg);
        dragon.SetActive(true);
        GetComponent<AudioSource>().Play();

        MyGUISkin.title = "戰鬥龍";
        MyGUISkin.info = "歷經長久的睡眠後，終於有人喚醒吾了，吾乃萬能的神龍，為了答謝汝，就讓汝許一個願望吧！\n選項一：萬能的神龍只給一個願望太小氣了吧？（按Q鍵）\n選項二：讓我離開這座島。（按E鍵）";
        MyGUISkin.talk = true;
    }
}
