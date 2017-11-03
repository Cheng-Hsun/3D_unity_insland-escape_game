using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REF : MonoBehaviour
{
    public bool firstTalk;
    public static bool missionAccept;
    public static bool missionCompleted;
    public static bool boatRepair;
    public GameObject powerCell;
    public GameObject hammer;

    void Start()
    {
        firstTalk = true;
        missionAccept = false;
        missionCompleted = false;
        boatRepair = false;
        powerCell.SetActive(false);
        hammer.SetActive(false);
    }

    private void OnMouseDown()
    {
        MyGUISkin.talk = !MyGUISkin.talk;
        if (!MyGUISkin.talk)
        {
            return;
        }

        if(!Ethan.missionAccept)
        {
            MyGUISkin.talk = false;
            Dialogue.title = "Ref";
            Dialogue.info = "（對方只是冷眼看著你，似乎不打算和你說話的樣子）";
            Dialogue.talk = true;
        }
        else
        {
            if (firstTalk)
            {
                MyGUISkin.title = "Ref";
                MyGUISkin.info = "喂！你！對，就是你。你是最近來到島上的船難受害者吧？，我叫Ref。聽說你答應要幫那個無聊的工程師找東西，我也有事要請你幫忙。在這種荒島上，想活下去就要互相幫助。前幾天的一陣風暴把我的船吹壞了，修船的工具也被吹走了。你幫我把修船工具找回來，把船修好，我就告訴你一個對你有幫助的情報。";
                firstTalk = false;
            } 
            else if (!missionAccept)
            {
                MyGUISkin.talk = false;
                Dialogue.title = "接受任務！";
                Dialogue.info = "幫Ref尋找修船工具，應該會在附近的地上？";
                Inventory.currentMission = "幫助Ref修復船。";
                Dialogue.talk = true;
                missionAccept = true;
                transform.parent.GetComponent<AudioSource>().Play();
                hammer.SetActive(true);
            }
            else if (!Inventory.haveHammer)
            {
                 MyGUISkin.title = "Ref";
                 MyGUISkin.info = "嗯？還沒找到修船工具？那你還待在這裡做什麼？去找啊！";    
            }
            else if(!boatRepair)
            {
                MyGUISkin.title = "Ref";
                MyGUISkin.info = "都找到修船工具了還磨蹭甚麼？快去修船啊！";
            }
            else if(!missionCompleted)
            {
                MyGUISkin.title = "Ref";
                MyGUISkin.info = "哼！總算好了。那我就告訴你吧！在對面的小島上，有一顆那個工程師在找的電池……你問我怎麼會知道？關你什麼事，你可以走了。";
                missionCompleted = true;
                powerCell.SetActive(true);
                Inventory.currentMission = "幫助伊森尋找電池。";
            }
            else
            {
                MyGUISkin.title = "Ref";
                MyGUISkin.info = "終於……終於可以離開這座島了。";
            }
        }
    }
}
