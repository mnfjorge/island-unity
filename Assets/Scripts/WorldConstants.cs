using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldConstants
{
    public static readonly Vector3Int[] directions = new[] { Vector3Int.back, Vector3Int.forward, Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };

    public static readonly int ChunkVoxelResolution = 2;
    public static int WorldChunkResolution = 5;
    public static int ChunkHeight = 5;

    // for better understanding
    public static readonly int VerticesPerTriangle = 3;
    public static readonly int TrianglesPerFace = 2;
    public static readonly int VerticesPerFace = VerticesPerTriangle * TrianglesPerFace;
    public static readonly int FacesPerVoxel = 6;
    public static readonly int VerticesPerVoxel = FacesPerVoxel * VerticesPerFace;
    public static readonly int VerticesPerChunk = VerticesPerVoxel * ChunkVoxelResolution * ChunkHeight * ChunkVoxelResolution;

    public static readonly Vector3Int[] vertices = new[] {
        new Vector3Int(0, 0, 0),
        new Vector3Int(1, 0, 0),
        new Vector3Int(1, 1, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, 0, 1),
        new Vector3Int(1, 0, 1),
        new Vector3Int(1, 1, 1),
        new Vector3Int(0, 1, 1)
    };

    public static readonly int[,] triangles = new int[,] {
        { 0, 3, 1, 1, 3, 2 }, // Back face
        { 5, 6, 4, 4, 6, 7 }, // Front face
        { 3, 7, 2, 2, 7, 6 }, // Top face
        { 1, 5, 0, 0, 5, 4 }, // Bottom face
        { 4, 7, 0, 0, 7, 3 }, // Left face
        { 1, 2, 5, 5, 2, 6 }, // Right face
    };

    public static readonly BlockType blockTypeSand = new BlockType
    {
        name = "Sand",
        color = Color.yellow,
    };

    public static readonly BlockType blockTypeDirt = new BlockType
    {
        name = "Dirt",
        color = Color.black,
    };
}