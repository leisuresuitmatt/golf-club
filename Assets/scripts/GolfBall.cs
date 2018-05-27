﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GolfBall : MonoBehaviour
{

    #region variables

    public float dmg;    // Wartośc obrażeń 
  //  [Range(0.5f, 5f)]
    public float dmgMod; // modyfikator obrażeń 
    public float speed; // Wartość prędkości piłki 
    public float curSpeed; // Aktualna prędkość piłki 
 //   [Range(0.2f, 2f)]
    public float minSpeedtoDmg; // minimalna prędkość do zadawania obrażeń 
    Rigidbody rb;
    public float maxDmg;
    public int team;
    public int lastTeam;
    int exploTeam;
    public float explosionMultiplier;
    public bool airborne;
    public GameObject explosion;
    public Material[] materials;
    private TrailRenderer trail;
    public Material[] trails;
    public float idleTimer;
    float timer;
    bool idle = false;

    public ParticleSystem SignpostParticles;

    Vector3 startPos;
    #endregion
    
    public void calcDmg() // obliczanie obrażeń 
    {
        if (speed < minSpeedtoDmg)
        {
            dmg = 0;
            idle = true;
            //trail.enabled = false;
        }

        else if (speed >= minSpeedtoDmg)
        {
            dmg = speed * dmgMod;
            idle = false;
            //trail.enabled = true;
        }

        if (dmg >= maxDmg)
        {
            dmg = maxDmg;
        }
    }

    public void FixedUpdate()
    {
        ChangeColor();
        if (team != 0) lastTeam = team;
        curSpeed = rb.velocity.magnitude;

        if (speed != curSpeed)

        {
            speed = curSpeed;
            calcDmg();
        }
        if (idle)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                idle = false;
                team = 0;
                timer = idleTimer;
            }
        }
        else
        {
            timer = idleTimer;
        }

        if (airborne && !SignpostParticles.isPlaying) SignpostParticles.Play();
        else if (SignpostParticles.isPlaying) SignpostParticles.Stop();

    }

    public void OnCollisionEnter(Collision other)
    {
        if (airborne)
        {
            GetComponent<Animator>().SetTrigger("Explosion");
            exploTeam = team;
            airborne = false;
            SignpostParticles.Stop();
        }
        if (other.gameObject.GetComponent<Hitable>())
        {
            if (team != 0) dmg += 20;
            other.gameObject.GetComponent<Hitable>().HitMe(dmg, team);
        }
    }
    void ChangeColor()
    {
        switch (team)
        {
            case 0:
                GetComponent<Renderer>().material = materials[0];
                trail.material = trails[0];
                break;
            case 1:
                GetComponent<Renderer>().material = materials[1];
                trail.material = trails[1];
                break;
            case 2:
                GetComponent<Renderer>().material = materials[2];
                trail.material = trails[2];
                break;
            case 3:
                GetComponent<Renderer>().material = materials[3];
                trail.material = trails[3];
                break;
            case 4:
                GetComponent<Renderer>().material = materials[4];
                trail.material = trails[4];
                break;
        }
    }

    public void Explode()
    {
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        newExplosion.GetComponent<Explosion>().dmg = (dmg + 10) * explosionMultiplier;
        newExplosion.GetComponent<Explosion>().teamNo = exploTeam;
        exploTeam = 0;
    }

    public void Start()
    {
        speed = curSpeed;
        rb = GetComponent<Rigidbody>();
        timer = idleTimer;
        trail = GetComponent<TrailRenderer>();
        startPos = transform.position;
    }
    
    public void Respawn()
    {
        team = 0;
        lastTeam = 0;
        timer = idleTimer;
        transform.position = startPos;
    }
}



