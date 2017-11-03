using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : MonoBehaviour
{
    public bool firstTalk;
    public static bool missionOneAccept;
    public static bool missionOneCompleted;
    public static bool missionTwoAccept;
    public static bool secretReveal;
    public GameObject dragonEgg;
    public GameObject BakedEgg;

    void Start()
    {
        firstTalk = true;
        secretReveal = false;
        dragonEgg.SetActive(false);
        BakedEgg.SetActive(false);
        missionOneAccept = false;
        missionOneCompleted = false;
        missionTwoAccept = false;
    }

    private void OnMouseDown()
    {
        MyGUISkin.talk = !MyGUISkin.talk;
        if (!MyGUISkin.talk)
        {
            return;
        }

        if (firstTalk)
        {
            MyGUISkin.title = "老泰迪熊";
            MyGUISkin.info = "你好，人類。老夫是這座泰迪島的長老。泰迪島附近的海洋十分不平靜，因此偶爾會有像你這樣的遇難者飄到這座島上。有空的話就去和大家打聲招呼吧！在這裡，互助是能順利生活最重要的事。另外，在島的某處有座火山，勸你最好不要接近，很危險的。";
            firstTalk = false;
        }
        else if(!Ethan.missionAccept)
        {
            MyGUISkin.title = "老泰迪熊";
            MyGUISkin.info = "唉呀~年紀大了關節處處都在痛啊";
        }
        else if (TeddyBear.missionAccept && !TeddyBear.missionCompleted)
        {
            MyGUISkin.title = "老泰迪熊";
            MyGUISkin.info = "蘋果啊~即使像老夫這樣一大把年紀了也抵抗不了那香甜的誘惑呢。在小泰迪附近的濕地找找吧，說不定能有所收穫喔。";
        }
        else if (Warrior.missionAccept && !Warrior.missionCompleted)
        {
            MyGUISkin.title = "老泰迪熊";
            MyGUISkin.info = "哈哈哈！勇士總是一副元氣滿滿的樣子呢！椰子的話，說不定其他的居民有撿到，向他們問問看吧。";
        }
        else if (REF.missionAccept && !REF.missionCompleted)
        {
            MyGUISkin.title = "老泰迪熊";
            MyGUISkin.info = "Ref啊，它其實也不是壞人，只是講話尖酸刻薄了一點。";
        }
        else if (Ethan.missionAccept && !Ethan.missionCompleted)
        {
            MyGUISkin.title = "老泰迪熊";
            MyGUISkin.info = "電池？是說那個會發亮的管子嗎？如果找不到的話，可以問問島上的其他居民，說不定有人正好有看到呢。";
        }
        else if (Ethan.missionCompleted && REF.missionCompleted && Warrior.missionCompleted && TeddyBear.missionCompleted && !secretReveal)
        {
            MyGUISkin.title = "老泰迪熊";
            MyGUISkin.info = "聽說你幫了島上很多人的忙啊！真是太感謝你了。好吧，看來你是可以信任的人，老夫就告訴你吧。其實，據說很久以前，在老夫的曾曾祖父那一輩，有一條神龍降臨在泰迪島上，短暫的居住在火山裡，但沒多久又因為不明的原因離開了。據說火山裡有留下神龍的寶藏，但是到那邊的人不是再也沒回來了，就是說他什麼也沒看到，最後也就沒有人再過去了。只是那邊畢竟還是很危險，你真的要過去的話一定要小心啊！";
            secretReveal = true;
        }
        else
        {
            if (!missionOneAccept)
            {
                MyGUISkin.talk = false;
                Dialogue.title = "接受任務！";
                Dialogue.info = "去火山那裡看看吧？說不定能找到什麼東西幫助我回家。";
                Inventory.currentMission = "前往火山調查。";
                Dialogue.talk = true;
                missionOneAccept = true;
                transform.parent.GetComponent<AudioSource>().Play();
                dragonEgg.SetActive(true);
            }
            else if (!Inventory.haveDragonEgg)
            {
                MyGUISkin.title = "老泰迪熊";
                MyGUISkin.info = "如果你打算去火山的話，千萬要小心啊！";
            }
            else if (!missionOneCompleted)
            {
                MyGUISkin.title = "老泰迪熊";
                MyGUISkin.info = "你居然真的跑去火山那裡！能安全回來真是太好了。所以那裡有什麼嗎？……什麼？只有一顆蛋？居然只有一顆蛋嗎……傳說果然不可信呢。正好老夫也肚子餓了，不如你就把那邊的營火點起來，把蛋烤來吃吧！";
                Destroy(GameObject.Find("eggGUI"));
                BakedEgg.SetActive(true); 
                missionOneCompleted = true;
            }
            else if (!missionTwoAccept)
            {
                MyGUISkin.talk = false;
                Dialogue.title = "接受任務！";
                Dialogue.info = "烤蛋啊？先點燃營火就行了吧？有沒有能點火的東西呢？";
                Inventory.currentMission = "將蛋烤熟，交給熊長老。";
                Dialogue.talk = true;
                missionTwoAccept = true;
                transform.parent.GetComponent<AudioSource>().Play();
            }
            else if (!Campfire.fireIgnite)
            {
                MyGUISkin.title = "老泰迪熊";
                MyGUISkin.info = "不知道這麼大的蛋味道如何，真是期待啊。";
            }
        }
    }
}
