using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel
{
    public Chunk chunk;
    public VoxelData voxelData;

    public Voxel(Chunk chunk, VoxelData voxelData)
    {
        this.chunk = chunk;
        this.voxelData = voxelData;
    }
}