using System;

/// <summary>
/// Name: PaperWorldLayer.cs
/// Created by: BlueSin
/// Created on: 10/12/2014
/// Last Updated by: BlueSin
/// Last Updated on: 11/16/2016
/// Copyright: Pixelsoft Games, LLC. 2014 - 2016
/// Description: TODO
/// </summary>
[Serializable]
public class TdrMapLayer
{
	#region Fields

	private readonly bool     _autoTile;
	private readonly ushort[] _tileValues;
	private readonly ushort[] _decorationValues;

	[NonSerialized] private readonly byte[] _tileSubValues;
	[NonSerialized] private readonly byte[] _decorationSubValues;

	#endregion

	#region Constructors

	public TdrMapLayer() { }

	public TdrMapLayer(int worldWidth, int worldHeight, bool autoTile)
	{
		_tileValues = new ushort[worldWidth * worldHeight];
		_decorationValues = new ushort[worldWidth * worldHeight];
		_tileSubValues = new byte[worldWidth * worldHeight];
		_decorationSubValues = new byte[worldWidth * worldHeight];
		_autoTile = autoTile;
	}

	#endregion

	#region Public Methods

	#region Tiles

	/// <summary>
	/// Gets a tile's value by tile ID.
	/// </summary>
	/// <param name="tileID">ID of the tile.</param>
	/// <returns></returns>
	public ushort GetTileValue(int tileID)
	{
		return _tileValues[tileID];
	}

	/// <summary>
	/// Gets a tile's sub value by ID.
	/// </summary>
	/// <param name="tileID"></param>
	/// <returns></returns>
	public byte GetTileSubValue(int tileID)
	{
		return _tileSubValues[tileID];
	}

	/// <summary>
	/// Sets a tile by tile ID, and also sets sub value.
	/// </summary>
	/// <param name="tileID">ID of the tile.</param>
	/// <param name="value">Value to set the tile to.</param>
	/// <param name="subValue">Sub Value to set the tile to.</param>
	public void SetTile(int tileID, ushort value, byte subValue)
	{
		_tileValues[tileID] = value;
		_tileSubValues[tileID] = subValue;
	}

	#endregion

	#region Decorations

	/// <summary>
	/// Gets a tile decoration's value by tile ID.
	/// </summary>
	/// <param name="tileID">ID of the decoration.</param>
	/// <returns></returns>
	public ushort GetDecorationValue(int tileID)
	{
		return _decorationValues[tileID];
	}

	/// <summary>
	/// Gets a tile decoration's sub value by tile ID.
	/// </summary>
	/// <param name="tileID">ID of the decoration.</param>
	/// <returns></returns>
	public byte GetDecorationSubValue(int tileID)
	{
		return _decorationSubValues[tileID];
	}

	/// <summary>
	/// Sets a tile decoration's sub value by tileID.
	/// </summary>
	/// <param name="tileID">ID of the decoration.</param>
	/// <param name="value">Value to set to the decoration.</param>
	/// <param name="subValue">Sub Value to set to the decoration.</param>
	public void SetDecoration(int tileID, ushort value, byte subValue)
	{
		_decorationValues[tileID] = value;
		_decorationSubValues[tileID] = subValue;
	}

	#endregion

	#region Auto Tiling

	/// <summary>
	/// Auto tiles the entire layer.
	/// </summary>
	public void AutoTileAll()
	{
		if (!_autoTile)
			return;

		// TODO: Implement auto tiling algorithm
	}

	/// <summary>
	/// Auto tiles a single point.
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	public void AutoTilePoint(int x, int y)
	{
		if (!_autoTile)
			return;

		// TODO: Implement auto tiling algorithm
	}

	#endregion

	#endregion
}