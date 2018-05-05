using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHole : MonoBehaviour
{
    Renderer myRenderer;
    public Material[] materials;
    int teamNo;

    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GolfBall entered = other.gameObject.GetComponent<GolfBall>();
        if (entered)
        {
            if (entered.team != 0 && entered.team != teamNo)
            {
                int loss = teamNo;
                teamNo = entered.team;
                GameControler.Instance.GiveVP(teamNo, loss);
                myRenderer.material = materials[teamNo];
            }
        }
    }
}
