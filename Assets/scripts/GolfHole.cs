using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHole : MonoBehaviour
{
    public Renderer[] myRenderer;
    public Material[] materials;
    int teamNo = 0;

    private void OnTriggerEnter(Collider other)
    {
        GolfBall entered = other.gameObject.GetComponent<GolfBall>();
        if (entered)
        {
            if (entered.lastTeam != 0 && entered.lastTeam != teamNo)
            {
                int loss = teamNo;
                teamNo = entered.lastTeam;
                GameControler.Instance.GiveVP(teamNo, loss);

                foreach (Renderer rend in myRenderer)
                    rend.material = materials[teamNo];
            }
            entered.Respawn();
        }
    }
}
