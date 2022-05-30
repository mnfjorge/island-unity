using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    public static readonly int ChunkWidth = 10;
    public static readonly int ChunkHeight = 10;

    public Chunk(World world)
    {
        for (int x = 0; x < ChunkWidth; x++)
        {
            for (int y = 0; y < ChunkHeight; y++)
            {
                for (int z = 0; z < ChunkWidth; z++)
                {
                    var position = new Vector3Int(x, y, z);
                    new Voxel(world, position);
                }
            }
        }
    }
}
