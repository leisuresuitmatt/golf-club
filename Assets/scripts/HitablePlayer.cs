using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitablePlayer : Hitable {

    public GameObject playerBody;
    public float hp = 100;
    public int teamNo;

    GameControler gcont;
    public PlayerDisabler disabler;

    private void Start()
    {
        gcont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControler>();
    }

    public override void HitMe(float dmg, int team)
    {
        if(team != teamNo)
        {
            hp -= dmg;
        }        
    }

    public void Death()
    {
        disabler.DisableControls();
    }
}
