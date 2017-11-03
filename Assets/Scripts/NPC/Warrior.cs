using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public bool firstTalk;
    public bool secondTalk;
    public bool thirdTalk;
    public static bool missionAccept;
    public static bool missionCompleted;
    public static bool haveCoconut;

    void Start()
    {
        firstTalk = true;
        secondTalk = true;
        thirdTalk = true;
        missionAccept = false;
        missionCompleted = false;
        haveCoconut = false;
    }

    private void OnMouseDown()
    {
        MyGUISkin.talk = !MyGUISkin.talk;
        if (!MyGUISkin.talk)
        {
            return;
        }

        if (!REF.missionCompleted)
        {
            MyGUISkin.talk = false;
            Dialogue.title = "勇士";
            Dialogue.info = "（對方很專心的在研究奇怪的機器，還是不要打擾他比較好吧？）";
            Dialogue.talk = true;
        }
        else
        {
            if (firstTalk)
            {
                MyGUISkin.title = "勇士";
                MyGUISkin.info = "哈囉~沒錯，就是在跟你打招呼。看你這個樣子，應該也是船難受害著吧？在這座泰迪島上，平時的生活肯定是十分無聊的，為了解決這個狀況，我發明了這個──登登！";
                firstTalk = false;
            }
            else if (secondTalk)
            {
                MyGUISkin.title = "勇士";
                MyGUISkin.info = "投擲訓練機！就是用靶子搭配彈簧組成的。靶子被打中後經過一段時間會彈起，幫助訓練投擲技巧，還可以打發時間，搭配作為彈藥的椰子，訓練效果更是妙不可言，丟完還可以剖開來喝！與椰子的巧妙組合正是這個發明的精華所在。\n（所以我說那個椰子呢？）";
                secondTalk = false;
            }
            else if (thirdTalk)
            {
                MyGUISkin.title = "勇士";
                MyGUISkin.info = "再、再給我幾天我一定可以撿到的。如果你有撿到椰子的話，可以給我一些嗎？";
                thirdTalk = false;

            }
            else if (!missionAccept)
            {
                MyGUISkin.talk = false;
                Dialogue.title = "接受任務！";
                Dialogue.info = "椰子？之前好像都沒有看過，會不會有人撿到過呢？";
                Inventory.currentMission = "幫助勇士找到椰子。";
                Dialogue.talk = true;
                missionAccept = true;
                transform.parent.GetComponent<AudioSource>().Play();
            }
            else if (!Inventory.haveCoconut)
            {
                MyGUISkin.title = "勇士";
                MyGUISkin.info = "沒有找到椰子嗎？麻煩你了繼續找吧，一定要椰子才行，一般的石頭太沒有格調了！";
            }
            else if (missionCompleted)
            {
                MyGUISkin.title = "勇士";
                MyGUISkin.info = "嗨！歡迎你隨時挑戰我發明的訓練機喔！雖然已經沒有獎品就是了……";
            }
            else
            {
                haveCoconut = true;
                Destroy(GameObject.Find("coconutGUI"));

                if (!CoconutWin.haveWon)
                {
                    MyGUISkin.title = "勇士";
                    MyGUISkin.info = "太好了！這下我的發明終於完成了。為了報答你，就讓你第一個使用這個發明吧！只要站在投擲訓練機前面的板子上就能啟動機器。如果你能同時讓三個靶都倒下的話，就可以得到獎品！";
                    Inventory.currentMission = "幫助伊森尋找電池。";
                }
            }
        }
    }
}
