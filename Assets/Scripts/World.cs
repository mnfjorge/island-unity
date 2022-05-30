using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public int seed = 0;
    public int resolution = 2;
    public Material cubeMaterial;
    public Color cubeColor = Color.black;

    public void GenerateCube()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            DestroyImmediate(this.transform.GetChild(i).gameObject);
        }

        new Chunk(this);
    }
}
