using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellIndex
{
	[SerializeField] private int _row;
	[SerializeField] private int _column;

	public CellIndex(int row, int column)
	{
		_row = row;
		_column = column;
	}

	public int Row => _row;

	public int Column => _column;
}
