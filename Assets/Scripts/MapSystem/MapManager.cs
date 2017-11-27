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
		Vector2Int meshPoint, 
		Vector2Int tilePosition)
	{
		int textureAtlasSize = 32;
		int verticesSizeX = SizeX * 3;
		
		if (tilePosition.x >= textureAtlasSize || tilePosition.y >= textureAtlasSize)
			throw new ArgumentOutOfRangeException(
				"Tile position is out of bounds.");

		//Point indeces
		var a = verticesSizeX * 2*meshPoint.y + 3*meshPoint.x;
		var b = a + verticesSizeX;
		var c = b + 1;
		var d = a + 1;
		var e = b + 2;
		var f = a + 2;

		var left   = tilePosition.x       / (float) textureAtlasSize;
		var right  = (tilePosition.x + 1) / (float) textureAtlasSize;
		var bottom = (tilePosition.y + 1) / (float) textureAtlasSize;
		var top    = tilePosition.y       / (float) textureAtlasSize;

		var aVal = new Vector2(left,	top);
		var bVal = new Vector2(left,	bottom);
		var cVal = new Vector2(right,	bottom);
		var dVal = new Vector2(left,	top);
		var eVal = new Vector2(right,	bottom);
		var fVal = new Vector2(right,	top);

		uvs[a] = aVal;
		uvs[b] = bVal;
		uvs[c] = cVal;

		uvs[d] = dVal;
		uvs[e] = eVal;
		uvs[f] = fVal; 
	}
}


