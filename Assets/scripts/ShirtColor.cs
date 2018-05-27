using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtColor : MonoBehaviour {

    public int materialToSwap;
    SkinnedMeshRenderer myRenderer;
    public Material[] shirtMaterials;
    
    public void SetColor(int teamNo)
    {
        myRenderer = GetComponent<SkinnedMeshRenderer>();
        Material[] mats = myRenderer.materials;
        mats[materialToSwap] = shirtMaterials[teamNo];
        myRenderer.materials = mats;
    }
}
