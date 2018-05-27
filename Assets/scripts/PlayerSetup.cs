using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{

    public RotateHorizontal camcontrols;
    public Controls controls;
    public GolfHit gh;
    public HitablePlayer hp;
    public ShirtColor shirt;

    public string player;
    public int teamNo;

    public void SetupPlayer()
    {
        camcontrols.player = player;
        controls.player = player;
        gh.player = player;
        gh.teamNo = teamNo;
        hp.teamNo = teamNo;
        shirt.SetColor(teamNo);
    }
}
