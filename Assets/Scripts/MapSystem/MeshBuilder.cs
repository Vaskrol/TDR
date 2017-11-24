using UnityEngine;

public static class MeshBuilder
{
	public static Mesh GetFlatMesh(int sizeX, int sizeY, float tileSize)
	{
		int numTiles      = sizeX * sizeY;
		int numTriangles  = numTiles * 2;
		int verticesSizeX = sizeX * 3;
		int verticesSizeY = sizeY * 3;
		int numVertices   = verticesSizeX * verticesSizeY;

		// Mesh data
		var vertices = new Vector3[numVertices];
		var normals = new Vector3[numVertices];
		var uvs = new Vector2[numVertices];
		var triangles = new int[numTriangles * 3]; // Triangle described as three vertex numbers

		// Normals
		// TODO: check performance and move to verts if needed
		for (var y = 0; y < verticesSizeY; y++)
		{
			for (var x = 0; x < verticesSizeX; x++)
			{
				normals[verticesSizeX * y + x] = Vector3.back;

			}
		}

		/* Points: A-B-C, D-E-F		
			A    D----F
			|\    \   |
			| \    \  |
			|  \    \ |
			|   \    \|
			B----C    E
		*/

		// Foreach square (pair of triangles)
		for (var y = 0; y < sizeY; y++)
		{
			for (var x = 0; x < sizeX; x++)
			{
				// Point indeces
				var a = verticesSizeX * 2 * y + 3 * x;
				var b = a + verticesSizeX;
				var c = b + 1;
				var d = a + 1;
				var e = b + 2;
				var f = a + 2;

				// Vertices
				vertices[a] = new Vector3(x * tileSize, y * tileSize, 0);
				vertices[b] = new Vector3(x * tileSize, y * tileSize + tileSize, 0);
				vertices[c] = new Vector3(x * tileSize + tileSize, y * tileSize + tileSize, 0);
				vertices[d] = new Vector3(x * tileSize, y * tileSize, 0);
				vertices[e] = new Vector3(x * tileSize + tileSize, y * tileSize + tileSize, 0);
				vertices[f] = new Vector3(x * tileSize + tileSize, y * tileSize, 0);

				// Uvs
				uvs[a] = new Vector2((float)x / sizeX, (float)y / sizeY);
				uvs[b] = new Vector2((float)x / sizeX, (float)(y + 1) / sizeY);
				uvs[c] = new Vector2((float)(x + 1) / sizeX, (float)(y + 1) / sizeY);
				uvs[d] = new Vector2((float)x / sizeX, (float)y / sizeY);
				uvs[e] = new Vector2((float)(x + 1) / sizeX, (float)(y + 1) / sizeY);
				uvs[f] = new Vector2((float)(x + 1) / sizeX, (float)y / sizeY);

				int squareNum = sizeX * y + x;
				int triangleOffset = squareNum * 6;

				// Triangles
				// left triangle
				triangles[triangleOffset] = a;
				triangles[triangleOffset + 1] = b;
				triangles[triangleOffset + 2] = c;

				// right triangle
				triangles[triangleOffset + 3] = d;
				triangles[triangleOffset + 4] = e;
				triangles[triangleOffset + 5] = f;
			}
		}

		// Create mesh and populate it with data
		var mesh = new Mesh
		{
			vertices = vertices,
			triangles = triangles,
			normals = normals,
			uv = uvs,
			bounds = new Bounds(Vector3.zero, new Vector3(sizeX * tileSize, sizeY * tileSize))
		};

		return mesh;
	}
}