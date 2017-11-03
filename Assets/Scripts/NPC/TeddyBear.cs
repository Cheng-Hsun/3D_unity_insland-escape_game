using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBear : MonoBehaviour
{
    public bool firstTalk;
    public static bool missionAccept;
    public static bool missionCompleted;
    public GameObject apple;
    public GameObject coconut;
    public AudioClip coconutSound;

    void Start()
    {
        firstTalk = true;
        missionCompleted = false;
        apple.SetActive(false);
    }

    private void OnMouseDown()
    {
        MyGUISkin.talk = !MyGUISkin.talk;
        if (!MyGUISkin.talk)
        {
            return;
        }

        if(!Warrior.missionAccept)
        {
            MyGUISkin.title = "泰迪熊";
            MyGUISkin.info = "你是誰？我不認識你，不要跟我說話。";
        }
        else
        {
            if (firstTalk)
            {
                MyGUISkin.title = "泰迪熊";
                MyGUISkin.info = "你就是在島上到處幫忙的人類吧！我是夢想成為偉大航海家的泰迪熊，多虧有你幫Ref修好船我才能完成出海的夢想，謝謝！對了，新來的，你才剛到這座島，肯定很閒吧！我正在跟Ref準備出海的事情，可是我想在航行途中吃的蘋果不夠了，你可以幫我蒐集一些嗎？如果你給我蘋果的話，我就把這些椰子給你。";
                firstTalk = false;
            }
            else if (!missionAccept)
            {
                MyGUISkin.talk = false;
                Dialogue.title = "接受任務！";
                Dialogue.info = "幫泰迪熊尋找蘋果，或許可以濕地附近找找看。";
                Inventory.currentMission = "幫助泰迪熊尋找蘋果。";
                Dialogue.talk = true;
                missionAccept = true;
                transform.parent.GetComponent<AudioSource>().Play();
                apple.SetActive(true);
            }
            else if (!Inventory.haveApple)
            {
                MyGUISkin.title = "泰迪熊";
                MyGUISkin.info = "還沒找到蘋果嗎？快一點啦~我肚子餓了。";
            }
            else if (!missionCompleted)
            {
                MyGUISkin.title = "泰迪熊";
                MyGUISkin.info = "謝謝你！這是說好的椰子……真不知道為什麼人類會喜歡這種又硬又沒味道的東西呢……";
                Inventory.currentMission = "幫助勇士找到椰子。";
                GetComponent<AudioSource>().Play();
                AudioSource.PlayClipAtPoint(coconutSound, transform.position);
                Inventory.haveCoconut = true;
                Inventory.coconutGUI.enabled = true;
                Destroy(GameObject.Find("appleGUI"));
                Destroy(coconut);
                missionCompleted = true;
            }
            else
            {
                MyGUISkin.title = "泰迪熊";
                MyGUISkin.info = "快樂的航行~破浪前進~英勇的小熊~無所畏懼~";
            }
        }
    }
}
