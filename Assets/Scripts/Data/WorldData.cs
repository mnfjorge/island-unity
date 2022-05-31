using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData
{
    public int seed;

    [System.NonSerialized]
    public Dictionary<Vector2Int, ChunkData> chunks = new Dictionary<Vector2Int, ChunkData>();

    public WorldData(int seed = 0)
    {
        this.seed = seed;

        for (int x = 0; x < WorldConstants.WorldChunkResolution; x++)
        {
            for (int z = 0; z < WorldConstants.WorldChunkResolution; z++)
            {
                GetChunkData(new Vector2Int(x * WorldConstants.ChunkVoxelResolution, z * WorldConstants.ChunkVoxelResolution));
            }
        }
    }

    public ChunkData GetChunkData(Vector2Int position)
    {
        if (!chunks.ContainsKey(position))
        {
            chunks[position] = new ChunkData(position);
        }
        
        return chunks[position];
    }
}
