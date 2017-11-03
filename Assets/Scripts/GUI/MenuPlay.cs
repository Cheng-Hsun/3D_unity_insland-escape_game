using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
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

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().PlayOneShot(beep);
        SceneManager.LoadScene("OpeningStory");
    }
}
