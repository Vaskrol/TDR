using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.MapSystem
{
	/// Description: TODO
	[Serializable]
	public class TdrMap
	{
		#region Fields

		/// <summary>
		/// Serialized Fields
		/// </summary>
		private readonly string            _name;
		private readonly MapSize           _mapSize;
		private int						   _width, _height;
		private readonly List<TdrMapLayer> _layers;

		#endregion

		#region Properties

		public string  GetName       { get { return _name; }}
		public MapSize GetMapSize    { get { return _mapSize; }}
		public int     GetWidth      { get { return _width; }}
		public int     GetHeight     { get { return _height; }}
		public int     GetLayerCount { get { return _layers.Count; } }

		#endregion

		#region Constructors

		public TdrMap()
		{
		}

		public TdrMap(string name, MapSize mapSize)
		{
			_name = name;
			_mapSize = mapSize;

			MeasureWorld(GetMapSize == MapSize.Custom
				? MapSize.Small
				: GetMapSize);

			_layers = new List<TdrMapLayer>();
		}

		public TdrMap(string name, int width, int height)
		{
			_name = name;
			_mapSize = MapSize.Custom;
			_width = width;
			_height = height;
			_layers = new List<TdrMapLayer>();
		}

		#endregion

		#region Public Methods

		#region Layers

		/// <summary>
		/// Adds a new layer to the map.
		/// </summary>
		public void AddLayer(bool autoTile)
		{
			_layers.Add(new TdrMapLayer(GetWidth, GetHeight, autoTile));
		}

		/// <summary>
		/// Removes the last layer from the map.
		/// </summary>
		public void RemoveLayer()
		{
			_layers.RemoveAt(_layers.Count - 1);
		}

		#endregion

		#region Tiles

		/// <summary>
		/// Gets a tile value by x, y coordinate.
		/// </summary>
		/// <param name="x">X coordinate of the tile.</param>
		/// <param name="y">Y coordinate of the tile.</param>
		/// <param name="layerID">Layer ID the tile is located in.</param>
		public ushort GetTileValue(int x, int y, int layerID)
		{
			return _layers[layerID].GetTileValue(GetTileID(x, y));
		}

		/// <summary>
		/// Gets a tile sub value by x, y coordinate.
		/// </summary>
		/// <param name="x">X coordinate of the tile.</param>
		/// <param name="y">Y coordinate of the tile.</param>
		/// <param name="layerID">Layer ID the tile is located in.</param>
		public byte GetTileSubValue(int x, int y, int layerID)
		{
			return _layers[layerID].GetTileSubValue(GetTileID(x, y));
		}

		/// <summary>
		/// Sets a tile by x, y coordinate.
		/// </summary>
		/// <param name="x">X coordinate of the tile.</param>
		/// <param name="y">Y coordinate of the tile.</param>
		/// <param name="layerID">Layer ID the tile is located in.</param>
		/// <param name="value">Value to set to the tile.</param>
		/// <param name="subValue">Sub Value to set to the tile.</param>
		public void SetTile(int x, int y, int layerID, ushort value, byte subValue)
		{
			_layers[layerID].SetTile(GetTileID(x, y), value, subValue);
		}

		#endregion

		#region Decorations

		/// <summary>
		/// Gets a decoration value by x, y coordinate.
		/// </summary>
		/// <param name="x">X coordinate of the decoration.</param>
		/// <param name="y">Y coordinate of the decoration.</param>
		/// <param name="layerID">Layer ID the decoration is located in.</param>
		public ushort GetDecorationValue(int x, int y, int layerID)
		{
			return _layers[layerID].GetDecorationValue(GetTileID(x, y));
		}

		/// <summary>
		/// Gets a decoration sub value by coordinate.
		/// </summary>
		/// <param name="x">X coordinate of the decoration.</param>
		/// <param name="y">Y coordinate of the decoration.</param>
		/// <param name="layerID">Layer ID the decoration is located in.</param>
		public byte GetDecorationSubValue(int x, int y, int layerID)
		{
			return _layers[layerID].GetDecorationSubValue(GetTileID(x, y));
		}

		/// <summary>
		/// Sets a decoration by x, y coordinate.
		/// </summary>
		/// <param name="x">X coordinate of the decoration.</param>
		/// <param name="y">Y coordinate of the decoration.</param>
		/// <param name="layerID">Layer ID the decoration is located in.</param>
		/// <param name="value">Value to set to the decoration.</param>
		/// <param name="subValue">Sub Value to set to the decoration.</param>
		public void SetDecoration(int x, int y, int layerID, ushort value, byte subValue)
		{
			_layers[layerID].SetDecoration(GetTileID(x, y), value, subValue);
		}

		#endregion

		#region Utility

		/// <summary>
		/// Gets a tile ID by x, y coordinate.
		/// </summary>
		/// <param name="x">X coordinate of the tile.</param>
		/// <param name="y">Y coordinate of the tile.</param>
		public int GetTileID(int x, int y)
		{
			return (y * _width) + x;
		}

		/// <summary>
		/// Saves the current Paper World to a file.
		/// </summary>
		public void Save()
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath + Global.FileSavePath + _name + Global.MapDataExtension);
			bf.Serialize(file, this);
			file.Close();
		}

		#endregion

		#endregion

		#region Private Methods

		#region Utility

		/// <summary>
		/// Sets tile width & height of the world based on world size.
		/// </summary>
		private void MeasureWorld(MapSize worldSize)
		{
			switch (worldSize)
			{
				case MapSize.Small: // Small
					_width  = Global.SmallWorldWidth;
					_height = Global.SmallWorldHeight;
					break;
				case MapSize.Medium: // Medium
					_width  = Global.MediumWorldWidth;
					_height = Global.MediumWorldHeight;
					break;
				case MapSize.Large: // Large
					_width  = Global.LargeWorldWidth;
					_height = Global.LargeWorldHeight;
					break;
			}
		}

		#endregion

		#endregion
	}
}
