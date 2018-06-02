using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float scale;
    public float dmg;
    public int teamNo;
    public float increase;
    public float maxScale;
    public float decay;
    float decTimer;
    bool canSpawn;
    List<Hitable> cantDamage;
    public GameObject explosion;
    public Material[] materials;

    private void Awake()
    {
        cantDamage = new List<Hitable>();
    }

    void Start()
    {        
        transform.localScale *= scale;
        decTimer = decay;
        canSpawn = true;
        ChangeColor();
        if (scale > maxScale)
            Destroy(gameObject);
    }


    void Update()
    {
        decTimer -= Time.deltaTime;

        if (decTimer <= 0 && canSpawn)
        {
            GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            newExplosion.GetComponent<Explosion>().scale = scale * increase;
            newExplosion.GetComponent<Explosion>().dmg = dmg / increase;
            newExplosion.GetComponent<Explosion>().teamNo = teamNo;
            newExplosion.GetComponent<Explosion>().cantDamage = cantDamage;

            canSpawn = false;
            Destroy(gameObject);
        }

    }

    void ChangeColor()
    {
        switch (teamNo)
        {
            case 0:
                GetComponent<Renderer>().material = materials[0];
                break;
            case 1:
                GetComponent<Renderer>().material = materials[1];
                break;
            case 2:
                GetComponent<Renderer>().material = materials[2];
                break;
            case 3:
                GetComponent<Renderer>().material = materials[3];
                break;
            case 4:
                GetComponent<Renderer>().material = materials[4];
                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Hitable hit = other.GetComponent<Hitable>();
        bool canDamage = true;

        if (hit)
        {
            if (cantDamage.Count > 0)
                foreach (Hitable alreadyHit in cantDamage)
                    if (hit == alreadyHit) canDamage = false;

            if (canDamage)
            {
                hit.HitMe(dmg, teamNo, true);
                cantDamage.Add(hit);
            }
        }
    }
}
