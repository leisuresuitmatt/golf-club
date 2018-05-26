using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitablePlayer : Hitable
{
    public GameObject playerBody;
    public SkinnedMeshRenderer Outline;
    public Material NormalOutline;
    public Material DamagedOutline;
    public Material RespawnOutline;
    public GameObject PlayerExplosion;
    public Transform RespawnPoint;
    public float hp = 100;
    public int teamNo;
    int damagingTeam;
    float damagedTimer;
    
    public PlayerDisabler disabler;

    private void Update()
    {
        if (hp <= 0) Respawn();

        if (damagedTimer > 0)
        {
            damagedTimer -= Time.deltaTime;
            if (damagedTimer <= 0)
            {
                Outline.material = NormalOutline;
            }
        }
    }

    public override void HitMe(float dmg, int team)
    {
        if(team != teamNo)
        {
            hp -= dmg;            

            if (dmg > 0)
            {
                damagingTeam = team;
                damagedTimer = .5f;
                Outline.material = DamagedOutline;
            }
        }        
    }

    public void Death()
    {
        disabler.DisableControls();
    }

    void Respawn()
    {
        if (GameControler.Instance.isClassic) GameControler.Instance.GiveHiddenVP(damagingTeam, teamNo);
        else GameControler.Instance.GiveVP(damagingTeam, teamNo);

        Instantiate(PlayerExplosion, transform.position, Quaternion.identity);
        Outline.material = RespawnOutline;
        playerBody.transform.position = RespawnPoint.position;
        playerBody.transform.rotation = RespawnPoint.rotation;

        hp = 100;
    }
}
