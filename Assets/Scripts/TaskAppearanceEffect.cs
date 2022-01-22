using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TaskAppearanceEffect : MonoBehaviour
{
	private Sequence _sequence;

	[SerializeField] private float _duration;
	[SerializeField] private Color _startColor;
	[SerializeField] private Color _endColor;
	[SerializeField] private Text _text;

	private void Start()
	{
		_text.color = _startColor;
		_text.DOColor(_endColor, _duration);
	}
}
