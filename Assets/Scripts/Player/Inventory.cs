using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static int chargeCount = 0;
    public static string currentMission = "";
    public static bool haveICCard = false;
    public static bool haveHammer = false;
    public static bool haveApple = false;
    public static bool haveDragonEgg = false;
    public static bool haveCoconut = false;
    public static bool haveMatch = false;

    public AudioClip cellCollectSound;
    public AudioClip matchCollectSound;
    public AudioClip otherCollectSound;

    public Texture2D[] powerTexture;
    public UnityEngine.UI.RawImage powerGUI;

    public Texture2D[] chargeTexture;
    public Renderer chargeMeter;

    public static UnityEngine.UI.RawImage matchGUI;
    public static UnityEngine.UI.RawImage ICCardGUI;
    public static UnityEngine.UI.RawImage hammerGUI;
    public static UnityEngine.UI.RawImage coconutGUI;
    public static UnityEngine.UI.RawImage eggGUI;
    public static UnityEngine.UI.RawImage appleGUI;

    public static Transform player;

    private void Start()
    {
        player = GameObject.Find("FPSController").GetComponent<Transform>();
        matchGUI = GameObject.Find("Canvas/matchGUI").GetComponent<UnityEngine.UI.RawImage>();
        ICCardGUI = GameObject.Find("Canvas/ICcardGUI").GetComponent<UnityEngine.UI.RawImage>();
        hammerGUI = GameObject.Find("Canvas/hammerGUI").GetComponent<UnityEngine.UI.RawImage>();
        coconutGUI = GameObject.Find("Canvas/coconutGUI").GetComponent<UnityEngine.UI.RawImage>();
        eggGUI = GameObject.Find("Canvas/eggGUI").GetComponent<UnityEngine.UI.RawImage>();
        appleGUI = GameObject.Find("Canvas/appleGUI").GetComponent<UnityEngine.UI.RawImage>();
    }

    void CellPickUp()
    {
        if (!powerGUI.enabled)
        {
            powerGUI.enabled = true;
        }

        AudioSource.PlayClipAtPoint(cellCollectSound, transform.position);
        chargeCount++;
        powerGUI.texture = powerTexture[chargeCount];
        chargeMeter.material.mainTexture = chargeTexture[chargeCount];
    }

    void MatchPickUp()
    {
        haveMatch = true;
        AudioSource.PlayClipAtPoint(matchCollectSound, transform.position);
        matchGUI.enabled = true;
    }

    void HammerPickUp()
    {
        haveHammer = true;
        AudioSource.PlayClipAtPoint(otherCollectSound, transform.position);
        hammerGUI.enabled = true;
    }

    void EggPickUp()
    {
        haveDragonEgg = true;
        AudioSource.PlayClipAtPoint(otherCollectSound, transform.position);
        eggGUI.enabled = true;
    }

    void ApplePickUp()
    {
        haveApple = true;
        AudioSource.PlayClipAtPoint(otherCollectSound, transform.position);
        appleGUI.enabled = true;
    }

    void CoconutPickUp()
    {
        haveCoconut = true;
        AudioSource.PlayClipAtPoint(otherCollectSound, transform.position);
        coconutGUI.enabled = true;
    }
}
