using System;
using NUnit.Framework.Constraints;
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
	
	public void BuildMesh()
	{
		var mesh        = MeshBuilder.GetFlatMesh(SizeX, SizeY, TileSize);
		var meshFilter  = GetComponent<MeshFilter>();
		meshFilter.mesh	= null;

		GenerateMapTexture(mesh);
		meshFilter.sharedMesh = mesh;
	}
	
	private void GenerateMapTexture(Mesh mesh)
	{
		var uvs = new Vector2[SizeX * 3 * SizeY * 3];
		for (var y = 0; y < SizeY; y++)
		{
			for (var x = 0; x < SizeX; x++)
			{
				SetTileToUvMap(ref uvs, new Vector2Int(x, y), new Vector2Int(0, 0));
			}
		}
		mesh.uv = uvs;
	}

	private void SetTileToUvMap(
		ref Vector2[] uvs, 
		Vector2Int point, 
		Vector2Int tile)
	{
		int textureAtlasSize = 32;
		int verticesSizeX = SizeX * 3;
		
		if (tile.x >= textureAtlasSize || tile.y >= textureAtlasSize)
			throw new ArgumentOutOfRangeException(
				"Tile position is out of bounds.");

		//Point indeces
		var a = verticesSizeX * 2*point.y + 3*point.x;
		var b = a + verticesSizeX;
		var c = b + 1;
		var d = a + 1;
		var e = b + 2;
		var f = a + 2;

		var aVal = new Vector2(tile.x / (float)textureAtlasSize, tile.y / (float)textureAtlasSize);
		var bVal = new Vector2(tile.x / (float)textureAtlasSize, (tile.y + 1) / (float)textureAtlasSize);
		var cVal = new Vector2((tile.x + 1) / (float)textureAtlasSize, (tile.y + 1) / (float)textureAtlasSize);
		var dVal = new Vector2(tile.x / (float)textureAtlasSize, tile.y / (float)textureAtlasSize);
		var eVal = new Vector2((tile.x + 1) / (float)textureAtlasSize, (tile.y + 1) / (float)textureAtlasSize);
		var fVal = new Vector2((tile.x + 1) / (float)textureAtlasSize, tile.y / (float)textureAtlasSize);


		uvs[a] = aVal;
		uvs[b] = bVal;
		uvs[c] = cVal;

		uvs[d] = dVal;
		uvs[e] = eVal;
		uvs[f] = fVal;
	}
}
