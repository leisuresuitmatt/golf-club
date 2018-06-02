using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditRoll : MonoBehaviour {

    public GameObject MenuHandler;
    public Image Credits;
    public Text CredText;
    float a = 1;
    bool run = false;

    private void Update()
    {
        if (!run)
            if (Input.anyKeyDown) run = true;

        if (run)
        {
            if (a == 0) return;

            Credits.color = new Color(Credits.color.r, Credits.color.g, Credits.color.b, a);
            CredText.color = new Color(CredText.color.r, CredText.color.g, CredText.color.b, a);

            a -= Time.deltaTime / 3;

            if (a <= 0)
            {
                a = 0;
                Credits.color = new Color(Credits.color.r, Credits.color.g, Credits.color.b, a);
                CredText.color = new Color(CredText.color.r, CredText.color.g, CredText.color.b, a);
                MenuHandler.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
