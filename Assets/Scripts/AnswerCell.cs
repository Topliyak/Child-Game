using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventCellIndex: UnityEvent<CellIndex> { }

public class AnswerCell : MonoBehaviour
{
	[SerializeField] private AnswerCellView _view;

	public UnityEventCellIndex cellClickedEvent;
	public UnityEventCellIndex cellSpawnedEvent;

	public void Start() => cellSpawnedEvent.Invoke(Index);

	public void Init(CellIndex index)
	{
		Index = index;
	}

	public AnswerCellView View => _view;

	public CellIndex Index { get; private set; }

	public void OnCellClicked() => cellClickedEvent.Invoke(Index);
}
