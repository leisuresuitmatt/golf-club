using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleEnterScript : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GolfBall"))
        {
            other.gameObject.layer = 11;
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GolfBall"))
        {
            other.gameObject.layer = 9;
        }
    }
}
