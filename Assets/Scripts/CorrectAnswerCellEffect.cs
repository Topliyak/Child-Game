using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CorrectAnswerCellEffect : MonoBehaviour
{
	private Sequence _sequence;

	[SerializeField] private AnswerTable _table;
	[SerializeField] private float _duration;
	[SerializeField] private float[] _intermediateScaleValues;

	public UnityEvent congratulationFinishedEvent;

	public void OnCorrectAnswer(CellIndex cellIndex)
	{
		_sequence = DOTween.Sequence();
		Transform imageTransform = _table[cellIndex].View.Image.transform;

		foreach (float intermediateScale in _intermediateScaleValues)
		{
			_sequence.Append(imageTransform.DOScale(intermediateScale, _duration));
		}

		_sequence.Append(imageTransform.DOScale(endValue: 1, _duration));
		WaitCongratulationFinish();
	}

	private async void WaitCongratulationFinish()
	{
		while (_sequence.IsPlaying())
			await System.Threading.Tasks.Task.Yield();

		congratulationFinishedEvent.Invoke();
	}
}
