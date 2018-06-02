using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetup : MonoBehaviour
{

    public RotateHorizontal camcontrols;
    public Controls controls;
    public GolfHit gh;
    public HitablePlayer hp;
    public ShirtColor shirt;
    public Image hpBar;
    public Color[] hpBarColors;

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
        hpBar.color = hpBarColors[teamNo];
    }
}
