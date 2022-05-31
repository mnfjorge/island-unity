using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelData
{
    public ChunkData chunkData;
    public BlockType blockType;
    public Vector3Int position;
    public VoxelData[] neighbours;

    public VoxelData(ChunkData chunkData, BlockType blockType, Vector3Int position)
    {
        this.chunkData = chunkData;
        this.blockType = blockType;
        this.position = position;
        this.neighbours = new VoxelData[WorldConstants.FacesPerVoxel];
    }


}