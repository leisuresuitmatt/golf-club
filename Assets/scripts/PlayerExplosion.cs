using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour {

    public GameObject explosion;
    public float scale;
    public float increase;
    public float maxScale;
    public float decay;
    float decTimer;
    bool canSpawn;

    void Start()
    {
        transform.localScale *= scale;
        decTimer = decay;
        canSpawn = true;
        if (scale > maxScale)
            Destroy(gameObject);
    }


    void Update()
    {
        decTimer -= Time.deltaTime;

        if (decTimer <= 0 && canSpawn)
        {
            GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            newExplosion.GetComponent<PlayerExplosion>().scale = scale * increase;            

            canSpawn = false;
            Destroy(gameObject);
        }

    }
}
