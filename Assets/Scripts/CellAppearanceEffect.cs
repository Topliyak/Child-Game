using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CellAppearanceEffect : MonoBehaviour
{
	private Sequence _sequence;

	[SerializeField] private float _duration;
	[SerializeField] private float[] _intermediateScaleValues;

	public void OnAppearance()
	{
		_sequence = DOTween.Sequence();
		transform.localScale = Vector3.zero;

		foreach (float intermediateScale in _intermediateScaleValues)
		{
			_sequence.Append(transform.DOScale(intermediateScale, _duration));
		}

		_sequence.Append(transform.DOScale(endValue: 1, _duration));
	}
}
