using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WrongAnswerCellEffect : MonoBehaviour
{
	private Sequence _sequence;

	[SerializeField] private AnswerTable _table;
	[SerializeField] private float _duration;
	[SerializeField] private float[] _offsets;

	public void OnWrongAnswer(CellIndex cellIndex)
	{
		_sequence = DOTween.Sequence();
		Transform imageTransform = _table[cellIndex].View.Image.transform;

		foreach (float offset in _offsets)
		{
			float x = imageTransform.position.x + offset;
			_sequence.Append(imageTransform.DOMoveX(endValue: x, _duration));
		}

		_sequence.Append(imageTransform.DOMoveX(endValue: imageTransform.position.x, _duration)
										.SetEase(Ease.InBounce));
	}
}
