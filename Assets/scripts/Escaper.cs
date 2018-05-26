using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escaper : MonoBehaviour
{
    public bool inGame;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inGame)
                SceneManager.LoadScene("PlayerSelect");
            else
                Application.Quit();
        }
    }
}
