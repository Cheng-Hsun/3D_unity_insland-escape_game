using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUISkin : MonoBehaviour
{
    public GUISkin myGUISkin;
    private Rect winRect;
    public static bool talk = false;
    public static string title;
    public static string info;

    void Start()
    {
        winRect = new Rect(900, 60, 360, 510);
    }

    private void OnGUI()
    {
        if(talk)
        {
            GUI.skin = myGUISkin;
            winRect = GUI.Window(0, winRect, DrawMyWindow, "");
        }
    }

    private void DrawMyWindow(int winId)
    {
        GUILayout.BeginVertical();
        GUILayout.Button("", "mybuttonskin");
        GUILayout.Label("", "mydivideskin");
        GUILayout.Label(title, "mylabelskin");
        GUILayout.Label("", "mydivideskin");
        GUILayout.Label(info, "mytextskin");
        GUILayout.EndVertical();
    }
}
