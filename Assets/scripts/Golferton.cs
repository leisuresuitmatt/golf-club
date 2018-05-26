using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golferton : MonoBehaviour {

    public int NumberOfPlayers;
    public string[] PlayerControllers;
    public int[] PlayerTeams;
    public bool isClassic = true;

    public static Golferton Instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (GameSetup.Instance)
        {
            GameSetup.Instance.NumberOfPlayers = NumberOfPlayers;
            GameSetup.Instance.PlayerControllers = PlayerControllers;
            GameSetup.Instance.PlayerTeams = PlayerTeams;
            GameSetup.Instance.isClassic = isClassic;

            GameSetup.Instance.StartTheGame();
        }
    }
}
