using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public int seed = 0;

    public Material cubeMaterial;
    public Color cubeColor = Color.black;

    public WorldData worldData;

    #region Singleton
    private static World instance;
    public static World Instance { get { return instance; } }

    public World()
    {
        instance = this;

        GenerateWorld();
    }

    #endregion

    public void GenerateWorld()
    {
        worldData = new WorldData(seed);
    }

    public void Populate()
    {
        foreach (var chunkData in worldData.chunks.Values)
        {
            var existingChunk = transform.Find(chunkData.name);
            if (existingChunk != null)
                DestroyImmediate(existingChunk.gameObject);

            new Chunk(chunkData).Generate();
        }
    }
}
