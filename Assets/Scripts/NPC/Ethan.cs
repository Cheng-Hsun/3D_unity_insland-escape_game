using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ethan : MonoBehaviour
{
    public bool firstTalk;
    public bool secondTalk;
    public static bool missionAccept;
    public static bool missionCompleted;
    public AudioClip ICCardSound;
    public RuntimeAnimatorController mineBot;
    public GameObject[] powerCell;

    void Start()
    {
        firstTalk = true;
        secondTalk = true;
        missionAccept = false;
        missionCompleted = false;
        powerCell[0].SetActive(false);
        powerCell[1].SetActive(false);
    }

    private void OnMouseDown()
    {
        MyGUISkin.talk = !MyGUISkin.talk;
        if(!MyGUISkin.talk)
        {
            return;
        }

        if (firstTalk)
        {
            MyGUISkin.title = "伊森";
            MyGUISkin.info = "咦？我沒見過你呢。……啊啊，原來你也是船難的遇難者啊！歡迎來到泰迪島……這好像不是值得高興的事，抱歉。我叫伊森，是一名工程師。雖然對初次見面的人來說有點厚臉皮，但是我想請你聽我說一下。";
            firstTalk = false;
        }
        else if(secondTalk)
        {
            MyGUISkin.title = "伊森";
            MyGUISkin.info = "你看到旁邊這個機器裝置了嗎？它叫「奧米加3000機械蜘蛛」，是我為了在這座島上打發時間做出來的，距離完成就只差一種零件了──那就是電池，總共需要四顆。只是之前我在島上散步的時候，不小心把電池掉在島上了。我還得待在這邊幫這小傢伙做一些調整，能請你幫我把那些電池撿回來嗎？如果你能幫我的話，我就會給你一些獎勵。";
            secondTalk = false;
        }
        else if(!missionAccept)
        {
            MyGUISkin.talk = false;
            Dialogue.title = "接受任務！";
            Dialogue.info = "幫工程師尋找電池，在島上四處看看應該有機會找到吧？（按R鍵可以查看當前任務）";
            Inventory.currentMission = "幫助伊森尋找電池。";
            Dialogue.talk = true;
            missionAccept = true;
            transform.parent.GetComponent<AudioSource>().Play();
            powerCell[0].SetActive(true);
            powerCell[1].SetActive(true);
        }
        else if(!missionCompleted)
        {
            switch (Inventory.chargeCount)
            {
                case 0:
                    MyGUISkin.title = "伊森";
                    MyGUISkin.info = "太感謝你了！那我就在這等你的好消息！";
                    break;
                case 1:
                    MyGUISkin.title = "伊森";
                    MyGUISkin.info = "剛開始總是最難的，加油！";
                    break;
                case 2:
                    MyGUISkin.title = "伊森";
                    MyGUISkin.info = "一半了一半了，GOGO！";
                    break;
                case 3:
                    MyGUISkin.title = "伊森";
                    MyGUISkin.info = "只差一顆電池了，拜託你了。";
                    break;
                case 4:
                    MyGUISkin.title = "伊森";
                    MyGUISkin.info = "太棒了！這是說好的獎勵，這張晶片卡很寶貴喔，你可要好好留著，說不定之後會派上用場。另外啊，熊長老好像有事情想告訴你，去跟他談話吧。";
                    Inventory.currentMission = "";
                    SpiderBot.ani.enabled = true;
                    AudioSource.PlayClipAtPoint(ICCardSound, transform.position);
                    Inventory.haveICCard = true;
                    Inventory.ICCardGUI.enabled = true;
                    Destroy(GameObject.Find("powerGUI"));
                    missionCompleted = true;
                    break;
            }
        }
        else
        {
            MyGUISkin.title = "伊森";
            MyGUISkin.info = "感謝你幫助我完成奧米加3000機械蜘蛛，今後請多多指教。";
        }
    }
}
