using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public int NumberOfPlayers;
    public string[] PlayerControllers;
    public int[] PlayerTeams;

    public PlayerList Setup2Players;
    public PlayerList Setup3Players;
    public PlayerList Setup4Players;

    public float timer;
    public bool isClassic;

    public static GameSetup Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartTheGame()
    {
        Setup2Players.gameObject.SetActive(false);
        Setup3Players.gameObject.SetActive(false);
        Setup4Players.gameObject.SetActive(false);

        switch (NumberOfPlayers)
        {
            case 2:
                Setup2Players.gameObject.SetActive(true);
                Setup2Players.PlayerControllers = PlayerControllers;
                Setup2Players.PlayerTeams = PlayerTeams;
                Setup2Players.SetupPlayers();
                break;

            case 3:
                Setup3Players.gameObject.SetActive(true);
                Setup3Players.PlayerControllers = PlayerControllers;
                Setup3Players.PlayerTeams = PlayerTeams;
                Setup3Players.SetupPlayers();
                break;

            case 4:
                Setup4Players.gameObject.SetActive(true);
                Setup4Players.PlayerControllers = PlayerControllers;
                Setup4Players.PlayerTeams = PlayerTeams;
                Setup4Players.SetupPlayers();
                break;
        }
    }
}
