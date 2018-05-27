using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectManager : MonoBehaviour
{

    public Text[] plReadyTexts = new Text[4];

    public Text golf;
    public Text mode;
    public Text map;
    public Text timer;
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

    public string SceneToLoad1;
    public string SceneToLoad2;
    int mapSelected;

    bool c1Trig, c2Trig, c3Trig, c4Trig;
    bool timerTrig;

    void Start()
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

        if (Golferton.Instance.isClassic) mode.text = "Classic Mode";
        else mode.text = "DeathMatch";

        mapSelected = Golferton.Instance.mapselected;

        if (mapSelected == 0) map.text = "Map: Golferdome";
        if (mapSelected == 1) map.text = "Map: The Golf Pit";        
    }


    void Update()
    {
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
                    plReadyTexts[i].text = "Keyboard";
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
                    plReadyTexts[i].text = "Controller 1";
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
                    plReadyTexts[i].text = "Controller 2";
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
                    plReadyTexts[i].text = "Controller 3";
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
                    plReadyTexts[i].text = "Controller 4";
                    plTeams[i] = i;
                    controller4Index = i;
                    numberOfPlayers++;
                    break;
                }
            }
        }

        if (Input.GetButtonDown(keyboard + "Cancel") && keyboardSelected)
        {
            keyboardSelected = false;

            plEnabled[keyboardIndex] = false;
            plControls[keyboardIndex] = null;
            plReadyTexts[keyboardIndex].color = new Color(0, 0, 0, 1);
            plReadyTexts[keyboardIndex].text = "Player " + (keyboardIndex + 1);
            plTeams[keyboardIndex] = 0;
            numberOfPlayers--;
        }
        if (Input.GetButtonDown(controler1 + "Cancel") && p1selected)
        {
            p1selected = false;

            plEnabled[controller1Index] = false;
            plControls[controller1Index] = null;
            plReadyTexts[controller1Index].color = new Color(0, 0, 0, 1);
            plReadyTexts[controller1Index].text = "Player " + (controller1Index + 1);
            plTeams[controller1Index] = 0;
            numberOfPlayers--;
        }
        if (Input.GetButtonDown(controler2 + "Cancel") && p2selected)
        {
            p2selected = false;

            plEnabled[controller2Index] = false;
            plControls[controller2Index] = null;
            plReadyTexts[controller2Index].color = new Color(0, 0, 0, 1);
            plReadyTexts[controller2Index].text = "Player " + (controller2Index + 1);
            plTeams[controller2Index] = 0;
            numberOfPlayers--;
        }
        if (Input.GetButtonDown(controler3 + "Cancel") && p3selected)
        {
            p3selected = false;

            plEnabled[controller3Index] = false;
            plControls[controller3Index] = null;
            plReadyTexts[controller3Index].color = new Color(0, 0, 0, 1);
            plReadyTexts[controller3Index].text = "Player " + (controller3Index + 1);
            plTeams[controller3Index] = 0;
            numberOfPlayers--;
        }
        if (Input.GetButtonDown(controler4 + "Cancel") && p4selected)
        {
            p4selected = true;

            plEnabled[controller4Index] = false;
            plControls[controller4Index] = null;
            plReadyTexts[controller4Index].color = new Color(0, 0, 0, 1);
            plReadyTexts[controller4Index].text = "Player " + (controller4Index + 1);
            plTeams[controller4Index] = 0;
            numberOfPlayers--;
        }       

        if (numberOfPlayers >= 2)
        {
            golf.enabled = true;
        }
        else
        {
            golf.enabled = false;
        }

        if (Input.GetButtonDown("Select"))
        {
            if (mapSelected == 0) mapSelected = 1;
            else if (mapSelected == 1) mapSelected = 0;

            if (mapSelected == 0) map.text = "Map: Golferdome";
            if (mapSelected == 1) map.text = "Map: The Golf Pit";

            Golferton.Instance.mapselected = mapSelected;
        }

        if ((Input.GetAxis(controler1 + "Fire1") > 0 || Input.GetAxis(controler1 + "Fire2") > 0) && !c1Trig)
        {
            c1Trig = true;
            Golferton.Instance.isClassic = !Golferton.Instance.isClassic;
            if (Golferton.Instance.isClassic) mode.text = "Classic Mode";
            else mode.text = "DeathMatch";
        }
        if (Input.GetAxis(controler1 + "Fire1") == 0 && Input.GetAxis(controler1 + "Fire2") == 0) c1Trig = false;
        if ((Input.GetAxis(controler2 + "Fire1") > 0 || Input.GetAxis(controler2 + "Fire2") > 0) && !c2Trig)
        {
            c2Trig = true;
            Golferton.Instance.isClassic = !Golferton.Instance.isClassic;
            if (Golferton.Instance.isClassic) mode.text = "Classic Mode";
            else mode.text = "DeathMatch";
        }
        if (Input.GetAxis(controler2 + "Fire1") == 0 && Input.GetAxis(controler2 + "Fire2") == 0) c2Trig = false;
        if ((Input.GetAxis(controler3 + "Fire1") > 0 || Input.GetAxis(controler3 + "Fire2") > 0) && !c3Trig)
        {
            c3Trig = true;
            Golferton.Instance.isClassic = !Golferton.Instance.isClassic;
            if (Golferton.Instance.isClassic) mode.text = "Classic Mode";
            else mode.text = "DeathMatch";
        }
        if (Input.GetAxis(controler3 + "Fire1") == 0 && Input.GetAxis(controler3 + "Fire2") == 0) c3Trig = false;
        if ((Input.GetAxis(controler4 + "Fire1") > 0 || Input.GetAxis(controler4 + "Fire2") > 0) && !c4Trig)
        {
            c4Trig = true;
            Golferton.Instance.isClassic = !Golferton.Instance.isClassic;
            if (Golferton.Instance.isClassic) mode.text = "Classic Mode";
            else mode.text = "DeathMatch";
        }
        if (Input.GetAxis(controler4 + "Fire1") == 0 && Input.GetAxis(controler4 + "Fire2") == 0) c4Trig = false;
        if (Input.GetButtonDown(keyboard + "Fire1") || Input.GetButtonDown(keyboard + "Fire2"))
        {
            Golferton.Instance.isClassic = !Golferton.Instance.isClassic;
            if (Golferton.Instance.isClassic) mode.text = "Classic Mode";
            else mode.text = "DeathMatch";
        }

        if ((Input.GetAxis(keyboard + "Vertical") > 0
            || Input.GetAxis(controler1 + "Horizontal") > 0 || Input.GetAxis(controler1 + "Vertical") > 0
            || Input.GetAxis(controler2 + "Horizontal") > 0 || Input.GetAxis(controler2 + "Vertical") > 0
            || Input.GetAxis(controler3 + "Horizontal") > 0 || Input.GetAxis(controler3 + "Vertical") > 0
            || Input.GetAxis(controler4 + "Horizontal") > 0 || Input.GetAxis(controler4 + "Vertical") > 0) 
            && !timerTrig)
        {
            timerTrig = true;
            Golferton.Instance.timer += 30f;            
        }
        if ((Input.GetAxis(keyboard + "Vertical") < 0
            || Input.GetAxis(controler1 + "Horizontal") < 0 || Input.GetAxis(controler1 + "Vertical") < 0
            || Input.GetAxis(controler2 + "Horizontal") < 0 || Input.GetAxis(controler2 + "Vertical") < 0
            || Input.GetAxis(controler3 + "Horizontal") < 0 || Input.GetAxis(controler3 + "Vertical") < 0
            || Input.GetAxis(controler4 + "Horizontal") < 0 || Input.GetAxis(controler4 + "Vertical") < 0)
            && !timerTrig)
        {
            timerTrig = true;
            Golferton.Instance.timer -= 30f;

            if (Golferton.Instance.timer < 30f) Golferton.Instance.timer = 30f;
        }
        if (Input.GetAxis(keyboard + "Vertical") == 0
            && Input.GetAxis(controler1 + "Horizontal") == 0 && Input.GetAxis(controler1 + "Vertical") == 0
            && Input.GetAxis(controler2 + "Horizontal") == 0 && Input.GetAxis(controler2 + "Vertical") == 0
            && Input.GetAxis(controler3 + "Horizontal") == 0 && Input.GetAxis(controler3 + "Vertical") == 0
            && Input.GetAxis(controler4 + "Horizontal") == 0 && Input.GetAxis(controler4 + "Vertical") == 0)
        {
            timerTrig = false;            
        }
        int minutes = (int)Golferton.Instance.timer / 60;
        int seconds = (int)Golferton.Instance.timer % 60;

        if (seconds >= 10) timer.text = "" + minutes + ":" + seconds;
        else timer.text = "" + minutes + ": 0" + seconds;

        if (golf.enabled && Input.GetButtonDown("Start"))
        {
            for (int i = 0; i < plTeams.Length; i++)
            {
                plTeams[i]++;
            }

            Golferton.Instance.NumberOfPlayers = numberOfPlayers;
            Golferton.Instance.PlayerControllers = plControls;
            Golferton.Instance.PlayerTeams = plTeams;

            string SceneToLoad;
            if (mapSelected == 0) SceneToLoad = SceneToLoad1;
            else SceneToLoad = SceneToLoad2;

            SceneManager.LoadScene(SceneToLoad);
        }

    }
}
