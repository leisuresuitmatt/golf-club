using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    public PlayerSetup[] playerList;
    public string[] PlayerControllers;
    public int[] PlayerTeams;

    public void SetupPlayers()
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            playerList[i].player = PlayerControllers[i];
            playerList[i].teamNo = PlayerTeams[i];
            playerList[i].SetupPlayer();
        }
    }
}
