using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnswerTable : MonoBehaviour
{
	private AnswerCell[,] _answerTable;
	private List<Transform> _rows;

	[SerializeField] private GameObject _rowTemplate;
	[SerializeField] private AnswerCell _cellTemplate;

	public void Awake() => Init();

	public void Init()
	{
		_answerTable = new AnswerCell[0, 0];
		_rows = new List<Transform>();
	}

	public int Rows => _answerTable.GetLength(0);

	public int Columns => _answerTable.GetLength(1);

	public AnswerCell this[int row, int column] => _answerTable[row, column];

	public AnswerCell this[CellIndex cellIndex] => _answerTable[cellIndex.Row, cellIndex.Column];

	public void Resize(int rows, int columns)
	{
		Clear();
		_answerTable = new AnswerCell[rows, columns];
		AddRows();
		AddCells();
	}

	public void Resize(TableSize tableSize) => Resize(tableSize.Rows, tableSize.Columns);

	public void UpdateCells(Task task)
	{
		for (int row = 0; row < Rows; row++)
			for (int column = 0; column < Columns; column++)
			{
				Card card = task.Cards[row, column];
				_answerTable[row, column].View.UpdateView(card.Sprite, card.Rotation);
			}
	}

	private void AddRows()
	{
		for (int i = 0; i < Rows; i++)
		{
			var row = Instantiate(_rowTemplate, transform);
			row.SetActive(true);
			_rows.Add(row.transform);
		}
	}

	private void AddCells()
	{
		for (int i = 0; i < Rows; i++)
			for (int j = 0; j < Columns; j++)
			{
				_answerTable[i, j] = Instantiate(_cellTemplate, _rows[i]);
				_answerTable[i, j].gameObject.SetActive(true);
				_answerTable[i, j].Init(new CellIndex(i, j));
			}
	}

	public void Clear()
	{
		DestroyCells();
		DestroyRows();
	}

	private void DestroyCells()
	{
		for (int i = 0; i < Rows; i++)
			for (int j = 0; j < Columns; j++)
				Destroy(_answerTable[i, j].gameObject);

		_answerTable = new AnswerCell[0, 0];
	}

	private void DestroyRows()
	{
		for (int i = 0; i < _rows.Count; i++)
			Destroy(_rows[i].gameObject);

		_rows.Clear();
	}

	public void DestroyCell(int row, int column)
	{
		Destroy(_answerTable[row, column].gameObject);
		_answerTable[row, column] = null;
	}
}
