using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImachine : MonoBehaviour
{
    public HitablePlayer playerhealth;
    public GolfHit player;
    public Text hp;
    public Slider slider;
    public Image dot;
	
	void Update ()
    {
        hp.text = "HP: " + playerhealth.hp;
        slider.value = player.powerBuildUp;
        dot.color = new Color(dot.color.r, dot.color.g, dot.color.b, player.powerBuildUp);
    }
}
