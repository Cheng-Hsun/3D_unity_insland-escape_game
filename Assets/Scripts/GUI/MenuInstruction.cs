using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInstruction : MonoBehaviour
{
    public Texture2D normalTexture;
    public Texture2D rolloverTexture;
    public AudioClip beep;
    public UnityEngine.UI.RawImage instruction;

    private void OnMouseEnter()
    {
        GetComponent<UnityEngine.UI.RawImage>().texture = rolloverTexture;
    }

    private void OnMouseExit()
    {
        GetComponent<UnityEngine.UI.RawImage>().texture = normalTexture;
    }

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().PlayOneShot(beep);
        if(!instruction.enabled)
        {
            instruction.enabled = true;
        }
        else
        {
            instruction.enabled = false;
        }
    }
}
