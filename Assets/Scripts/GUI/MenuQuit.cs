using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuQuit : MonoBehaviour
{
    public Texture2D normalTexture;
    public Texture2D rolloverTexture;
    public AudioClip beep;

    private void OnMouseEnter()
    {
        GetComponent<UnityEngine.UI.RawImage>().texture = rolloverTexture;
    }

    private void OnMouseExit()
    {
        GetComponent<UnityEngine.UI.RawImage>().texture = normalTexture;
    }

    private IEnumerator OnMouseDown()
    {
        GetComponent<AudioSource>().PlayOneShot(beep);
        yield return new WaitForSeconds(0.35f);
        Application.Quit();
    }
}
