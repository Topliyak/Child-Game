using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellApearanceController : MonoBehaviour
{
	private int _apearancedCellsCount = 0;

	[SerializeField] private AnswerTable _table;
	[SerializeField] private int _maxCellApearancedWithEffect;

	public void OnCellSpawned(CellIndex cellIndex)
	{
		if (_apearancedCellsCount < _maxCellApearancedWithEffect)
		{
			_table[cellIndex].GetComponent<CellAppearanceEffect>().OnAppearance();
			_apearancedCellsCount++;
		}
	}
}
