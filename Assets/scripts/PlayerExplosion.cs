using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour {

    ParticleSystem myParticles;

    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        if (!myParticles.isPlaying) Destroy(gameObject);
    }
}
