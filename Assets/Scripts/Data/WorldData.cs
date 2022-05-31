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

    public VoxelData GetVoxelInWorld(Vector3Int globalPosition)
    {
        if (globalPosition.x < 0 || globalPosition.x > WorldConstants.WorldVoxelResolution - 1 ||
            globalPosition.y < 0 || globalPosition.y > WorldConstants.ChunkHeight - 1 ||
            globalPosition.z < 0 || globalPosition.z > WorldConstants.WorldVoxelResolution - 1)
            return null;

        var chunkX = Mathf.FloorToInt(globalPosition.x / WorldConstants.ChunkVoxelResolution) * WorldConstants.ChunkVoxelResolution;
        var chunkZ = Mathf.FloorToInt(globalPosition.z / WorldConstants.ChunkVoxelResolution) * WorldConstants.ChunkVoxelResolution;

        var chunkPosition = new Vector2Int(chunkX, chunkZ);

        if (!chunks.ContainsKey(chunkPosition))
            return null;

        var chunk = chunks[chunkPosition];

        var voxelLocalPosition = new Vector3Int(globalPosition.x - chunkX, globalPosition.y, globalPosition.z - chunkZ);

        return chunk.voxels.ContainsKey(voxelLocalPosition) ? chunk.voxels[voxelLocalPosition] : null;
    }
}
