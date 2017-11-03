using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lerp : MonoBehaviour
{
    private float xStartPosition = -500;
    private float xEndPosition = 500;
    private float speed = 0.0f;

    void Start()
    {
        Invoke("StartGame", 7.0f);
    }

    void Update()
    {
        speed += Time.deltaTime;
        transform.position = new Vector3(Mathf.Lerp(xStartPosition, xEndPosition, speed), transform.position.y, transform.position.z);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Island");
    }
}