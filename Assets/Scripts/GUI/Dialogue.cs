using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GUISkin myGUISkin;
    private Rect winRect;
    public static bool talk = false;
    public static string title;
    public static string info;

    void Start()
    {
        winRect = new Rect(70, 0, Screen.width-120, 70);
    }

    private void OnGUI()
    {
        if (talk)
        {
            GUI.skin = myGUISkin;
            winRect = GUI.Window(1, winRect, DrawMyWindow, "");
        }
    }

    private void DrawMyWindow(int winId)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Button("", "mybuttonskin");
        GUILayout.Label(title, "mylabelskin");
        GUILayout.Label(info, "mytextskin");
        GUILayout.EndHorizontal();
    }
}
