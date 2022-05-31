using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    public ChunkData chunkData;
    public GameObject gameObject;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    [HideInInspector]
    public Vector3[] vertices = new Vector3[WorldConstants.VerticesPerChunk];
    [HideInInspector]
    public int[] triangles = new int[WorldConstants.VerticesPerChunk];
    [HideInInspector]
    public Voxel[,,] voxels = new Voxel[WorldConstants.ChunkVoxelResolution, WorldConstants.ChunkHeight, WorldConstants.ChunkVoxelResolution];

    public Chunk(ChunkData chunkData)
    {
        this.chunkData = chunkData;
        this.chunkData.chunk = this;

        gameObject = new GameObject(chunkData.name);
        gameObject.transform.parent = World.Instance.gameObject.transform;
        gameObject.transform.position = new Vector3(chunkData.position.x, 0, chunkData.position.y);

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.sharedMesh = new Mesh();

        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        meshRenderer.sharedMaterial.color = World.Instance.cubeColor;
    }

    public void Generate()
    {
        int verticeIndex = 0;

        foreach (var voxelData in chunkData.voxels.Values)
        {
            var voxel = new Voxel(this, voxelData);
            voxels[voxelData.position.x, voxelData.position.y, voxelData.position.z] = voxel;

            for (int directionIndex = 0; directionIndex < WorldConstants.directions.Length; directionIndex++)
            {
                var neighborLocalPosition = voxelData.position + WorldConstants.directions[directionIndex];
                if (chunkData.GetVoxel(neighborLocalPosition) != null)
                    continue;
                else
                {
                    var voxelGlobalPosition = new Vector3Int(chunkData.position.x + voxelData.position.x, voxelData.position.y, chunkData.position.y + voxelData.position.z);
                    var neighborGlobalPosition = voxelGlobalPosition + WorldConstants.directions[directionIndex];
                    if (World.Instance.worldData.GetVoxelInWorld(neighborGlobalPosition) != null)
                        continue;
                }

                for (int i = 0; i < WorldConstants.VerticesPerFace; i++)
                {
                    vertices[verticeIndex] = voxelData.position + WorldConstants.vertices[WorldConstants.triangles[directionIndex, i]];
                    triangles[verticeIndex] = verticeIndex;
                    verticeIndex++;
                }
            }
        }

        meshFilter.sharedMesh.Clear();
        meshFilter.sharedMesh.vertices = vertices;
        meshFilter.sharedMesh.triangles = triangles;
        meshFilter.sharedMesh.RecalculateNormals();
    }
}
