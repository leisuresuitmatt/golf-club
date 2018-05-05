using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayerSelect;

    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.SetActive(false);
            PlayerSelect.SetActive(true);
        }
    }
}
