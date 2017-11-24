using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapManager))]
public class TileMapInspector : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		if (GUILayout.Button("Regenerate"))
		{
			var manager = (MapManager) target;
			manager.BuildMesh();
		}
	}
}
