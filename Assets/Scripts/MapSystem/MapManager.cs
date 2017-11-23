
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class MapManager : MonoBehaviour
{
	public int SizeX       = 100;
	public int SizeY       = 100;
	public float TileSize  = 1f;
	
	void Start()
	{
		BuildMesh();
	}
	
	private void BuildMesh()
	{
		var mesh           = GetFlatMesh(SizeX, SizeY, TileSize);
		var meshFilter     = GetComponent<MeshFilter>();
		meshFilter.mesh    = mesh;

		Debug.Log("Mesh done.");
	}

	private Mesh GetFlatMesh(int sizeX, int sizeY, float tileSize)
	{
		int numTiles      = sizeX * sizeY;
		int numTriangles  = numTiles * 2;
		int verticesSizeX = sizeX + 1;
		int verticesSizeY = sizeY + 1;
		int numVertices   = verticesSizeX * verticesSizeY;

		// Mesh data
		var vertices      = new Vector3[numVertices];
		var normals       = new Vector3[numVertices];
		var uvs           = new Vector2[numVertices];
		var triangles     = new int[numTriangles * 3]; // Triangle described as three vertex numbers

		// Generate mesh data
		// Verts, normals, uvs
		for (var y = 0; y < verticesSizeY; y++)
		{
			for (var x = 0; x < verticesSizeX; x++)
			{
				vertices[verticesSizeX * y + x] = new Vector3(x * tileSize, y * tileSize, 0);
				normals[verticesSizeX * y + x]  = Vector3.back;
				uvs[verticesSizeX * y + x]      = new Vector2((float)x / verticesSizeX, (float)y / verticesSizeY);
			}
		}

		// Triangles, foreach square (pair of triangles)
		for (var y = 0; y < sizeY; y++)
		{
			for (var x = 0; x < sizeX; x++)
			{
				int squareNum = sizeX * y + x;
				int triangleOffset = squareNum * 6;
				triangles[triangleOffset]     = verticesSizeX * y + x;
				triangles[triangleOffset + 1] = verticesSizeX * y + x + verticesSizeX;
				triangles[triangleOffset + 2] = verticesSizeX * y + x + verticesSizeX + 1;

				triangles[triangleOffset + 3] = verticesSizeX * y + x;
				triangles[triangleOffset + 4] = verticesSizeX * y + x + verticesSizeX + 1;
				triangles[triangleOffset + 5] = verticesSizeX * y + x + 1;
			}
		}

		// Create mesh and populate it with data
		var mesh = new Mesh
		{
			vertices  = vertices,
			triangles = triangles,
			normals   = normals,
			uv        = uvs
		};

		return mesh;
	}
}
