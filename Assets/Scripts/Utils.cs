using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal class Utils
{
    // ====================Materials Functions========================\\
    // Returns a list of all materials on this GameObject and its children
    static public Material[] GetAllMaterials(GameObject go)
    {
        Renderer[] rends = go.GetComponentsInChildren<Renderer>();

        List<Material> mats = new List<Material>();
        foreach (Renderer rend in rends)
        {
            mats.Add(rend.material);
        }

        return (mats.ToArray());

    }
}
 
// Would give me a Compiler Error with a regular Utils class.
/* 
 public class Utils : MonoBehaviour
{

    // ====================Materials Functions========================\\
    // Returns a list of all materials on this GameObject and its children
    static public Material[] GetAllMaterials(GameObject go)
    {
        Renderer[] rends = go.GetComponentsInChildren<Renderer>();

        List<Material> mats = new List<Material>();
        foreach (Renderer rend in rends)
        {
            mats.Add(rend.material);
        }

        return (mats.ToArray());
    }
} */