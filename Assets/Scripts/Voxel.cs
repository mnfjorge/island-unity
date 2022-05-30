using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel
{
    public static readonly Vector3[] directions = new[] { Vector3.back, Vector3.forward, Vector3.up, Vector3.down, Vector3.left, Vector3.right };

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

    public Voxel(World world, Vector3Int position)
    {
        var cube = new GameObject("cube");
        cube.transform.parent = world.transform;
        var meshFilter = cube.AddComponent<MeshFilter>();
        meshFilter.sharedMesh = new Mesh();
        var meshRenderer = cube.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = world.cubeMaterial;
        meshRenderer.sharedMaterial.color = world.cubeColor;

        int verticesPerFace = 6; // 3 vertices per triangle * 2 triangles per face

        var vertices = new Vector3[verticesPerFace * Voxel.directions.Length];
        var triangles = new int[verticesPerFace * Voxel.directions.Length];

        int verticeIndex = 0;

        for (int faceIndex = 0; faceIndex < Voxel.directions.Length; faceIndex++)
        {
            for (int i = 0; i < verticesPerFace; i++)
            {
                int triangleIndex = Voxel.triangles[faceIndex, i];

                vertices[verticeIndex] = position + Voxel.vertices[triangleIndex];
                triangles[verticeIndex] = verticeIndex;

                verticeIndex++;
            }
        }

        meshFilter.sharedMesh.Clear();
        meshFilter.sharedMesh.vertices = vertices;
        meshFilter.sharedMesh.triangles = triangles;
        meshFilter.sharedMesh.RecalculateNormals();
    }
}