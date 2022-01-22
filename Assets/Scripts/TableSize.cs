using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TableSize
{
	[SerializeField] private int _rows;
	[SerializeField] private int _columns;

	public TableSize(int rows, int columns)
	{
		_rows = rows;
		_columns = columns;
	}

	public int Rows => _rows;

	public int Columns => _columns;
}
