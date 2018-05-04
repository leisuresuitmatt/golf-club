using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectManager : MonoBehaviour
{

    public Text[] plReadyTexts = new Text[4];
    
    public Text golf;
    public string keyboard;
    public string controler1;
    public string controler2;
    public string controler3;
    public string controler4;

    int keyboardIndex;
    int controller1Index;
    int controller2Index;
    int controller3Index;
    int controller4Index;

    public Color[] teamcolors = new Color[4];

    int numberOfPlayers = 0;
    bool[] plEnabled = new bool[4];
    string[] plControls = new string[4];
    int[] plTeams = new int[4];

    bool keyboardSelected = false;
    bool p1selected = false;
    bool p2selected = false;
    bool p3selected = false;
    bool p4selected = false;

    public string SceneToLoad;

    void Start ()
    {
        for (int i = 0; i < plReadyTexts.Length; i++)
        {
            plReadyTexts[i].color = Color.black;
        }

        golf.enabled = false;

        for (int i = 0; i < plEnabled.Length; i++)
        {
            plEnabled[i] = false;
        }
    }
	
	
	void Update ()
    {
        if (Input.GetButtonDown(keyboard + "Jump") && !keyboardSelected)
        {
            keyboardSelected = true;
            for (int i = 0; i < plEnabled.Length; i++)
            {
                if (!plEnabled[i])
                {
                    plEnabled[i] = true;
                    plControls[i] = keyboard;
                    plReadyTexts[i].color = teamcolors[i];
                    plTeams[i] = i;
                    keyboardIndex = i;
                    numberOfPlayers++;
                    break;
                }
            }
        }
        if (Input.GetButtonDown(controler1 + "Jump") && !p1selected)
        {
            p1selected = true;
            for (int i = 0; i < plEnabled.Length; i++)
            {
                if (!plEnabled[i])
                {
                    plEnabled[i] = true;
                    plControls[i] = controler1;
                    plReadyTexts[i].color = teamcolors[i];
                    plTeams[i] = i;
                    controller1Index = i;
                    numberOfPlayers++;
                    break;
                }
            }
        }
        if (Input.GetButtonDown(controler2 + "Jump") && !p2selected)
        {
            p2selected = true;
            for (int i = 0; i < plEnabled.Length; i++)
            {
                if (!plEnabled[i])
                {
                    plEnabled[i] = true;
                    plControls[i] = controler2;
                    plReadyTexts[i].color = teamcolors[i];
                    plTeams[i] = i;
                    controller2Index = i;
                    numberOfPlayers++;
                    break;
                }
            }
        }
        if (Input.GetButtonDown(controler3 + "Jump") && !p3selected)
        {
            p3selected = true;
            for (int i = 0; i < plEnabled.Length; i++)
            {
                if (!plEnabled[i])
                {
                    plEnabled[i] = true;
                    plControls[i] = controler3;
                    plReadyTexts[i].color = teamcolors[i];
                    plTeams[i] = i;
                    controller3Index = i;
                    numberOfPlayers++;
                    break;
                }
            }
        }
        if (Input.GetButtonDown(controler4 + "Jump") && !p4selected)
        {
            p4selected = true;
            for (int i = 0; i < plEnabled.Length; i++)
            {
                if (!plEnabled[i])
                {
                    plEnabled[i] = true;
                    plControls[i] = controler4;
                    plReadyTexts[i].color = teamcolors[i];
                    plTeams[i] = i;
                    controller4Index = i;
                    numberOfPlayers++;
                    break;
                }
            }
        }

        if (Input.GetButtonDown(keyboard + "Jump") && keyboardSelected)
        {
            int newTeam = plTeams[keyboardIndex];

            newTeam++;
            if (newTeam >= 4) newTeam = 0;

            plTeams[keyboardIndex] = newTeam;
            plReadyTexts[keyboardIndex].color = teamcolors[newTeam];
        }
        if (Input.GetButtonDown(controler1 + "Jump") && p1selected)
        {
            int newTeam = plTeams[controller1Index];

            newTeam++;
            if (newTeam >= 4) newTeam = 0;

            plTeams[controller1Index] = newTeam;
            plReadyTexts[controller1Index].color = teamcolors[newTeam];
        }
        if (Input.GetButtonDown(controler2 + "Jump") && p2selected)
        {
            int newTeam = plTeams[controller2Index];

            newTeam++;
            if (newTeam >= 4) newTeam = 0;

            plTeams[controller2Index] = newTeam;
            plReadyTexts[controller2Index].color = teamcolors[newTeam];
        }
        if (Input.GetButtonDown(controler3 + "Jump") && p3selected)
        {
            int newTeam = plTeams[controller3Index];

            newTeam++;
            if (newTeam >= 4) newTeam = 0;

            plTeams[controller3Index] = newTeam;
            plReadyTexts[controller3Index].color = teamcolors[newTeam];
        }
        if (Input.GetButtonDown(controler4 + "Jump") && p4selected)
        {
            int newTeam = plTeams[controller4Index];

            newTeam++;
            if (newTeam >= 4) newTeam = 0;

            plTeams[controller4Index] = newTeam;
            plReadyTexts[controller4Index].color = teamcolors[newTeam];
        }

        if (numberOfPlayers >= 2)
        {
            golf.enabled = true;
        }

        if(golf.enabled && Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < plTeams.Length; i++)
            {
                plTeams[i]++;
            }

            Golferton.Instance.NumberOfPlayers = numberOfPlayers;
            Golferton.Instance.PlayerControllers = plControls;
            Golferton.Instance.PlayerTeams = plTeams;

            SceneManager.LoadScene(SceneToLoad);
        }

    }
}
