using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkData
{
    public Chunk chunk;
    public Vector2Int position;
    public Dictionary<Vector3Int, VoxelData> voxels = new Dictionary<Vector3Int, VoxelData>();

    public string name
    {
        get { return "chunk " + position.x + "," + position.y; }
    }

    public ChunkData(Vector2Int position)
    {
        this.position = position;

        for (int x = 0; x < WorldConstants.ChunkVoxelResolution; x++)
        {
            for (int y = 0; y < WorldConstants.ChunkHeight; y++)
            {
                for (int z = 0; z < WorldConstants.ChunkVoxelResolution; z++)
                {
                    var voxelPosition = new Vector3Int(x, y, z);
                    var voxelData = new VoxelData(this, null, voxelPosition);
                    voxels[voxelPosition] = voxelData;
                }
            }
        }

        RefreshNeighbours();
    }

    void RefreshNeighbours()
    {
        for (int x = 0; x < WorldConstants.ChunkVoxelResolution; x++)
        {
            for (int y = 0; y < WorldConstants.ChunkHeight; y++)
            {
                for (int z = 0; z < WorldConstants.ChunkVoxelResolution; z++)
                {
                    var voxelPosition = new Vector3Int(x, y, z);
                    var voxel = voxels[voxelPosition];

                    for (int directionIndex = 0; directionIndex < WorldConstants.directions.Length; directionIndex++)
                    {
                        var neighbourPosition = voxelPosition + WorldConstants.directions[directionIndex];

                        if (voxels.ContainsKey(neighbourPosition))
                        {
                            var neighbour = voxels[neighbourPosition];
                            voxel.neighbours[directionIndex] = neighbour;
                        }
                    }
                }
            }
        }
    }

    public bool IsVoxelInChunk(Vector3Int position)
    {
        return voxels.ContainsKey(position);
    }

    public VoxelData GetVoxel(Vector3Int position)
    {
        return IsVoxelInChunk(position) ? voxels[position] : null;
    }
}