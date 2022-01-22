using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventTableSize: UnityEvent<TableSize> { }

public class TableController : MonoBehaviour
{
	[SerializeField] private AnswerTable _table;

	public UnityEventTableSize tableUpdatedEvent;

	private Dictionary<DifficultyLevel, TableSize> _difficultyTableSizePairs = new Dictionary<DifficultyLevel, TableSize>
	{
		{DifficultyLevel.Easy, new TableSize(1, 3) },
		{DifficultyLevel.Middle, new TableSize(2, 3) },
		{DifficultyLevel.Hard, new TableSize(3, 3) },
	};

	public void UpdateTable(DifficultyLevel difficulty)
	{
		TableSize tableSize = _difficultyTableSizePairs[difficulty];
		_table.Resize(tableSize);
		tableUpdatedEvent.Invoke(tableSize);
	}
}
