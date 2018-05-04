using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImachine : MonoBehaviour
{
    public HitablePlayer playerhealth;
    public GolfHit player;
    public Text hp;
    public Text power;
	
	void Update ()
    {
        hp.text = "HP: " + playerhealth.hp;
        power.text = "Power: " + player.powerBuildUp*100 + "%";
	}
}
