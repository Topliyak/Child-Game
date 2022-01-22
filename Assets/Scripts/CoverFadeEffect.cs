using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class CoverFadeEffect : MonoBehaviour
{
	private Sequence _sequence;
	private bool _waitingEffectFinished;

	[SerializeField] private Image _image;
	[SerializeField] private float _duration;
	[SerializeField] private Color _startColor;
	[SerializeField] private Color _endColor;

	public UnityEvent fadeInFinishedEvent;
	public UnityEvent fadeOutFinishedEvent;
	public UnityEvent initializedEvent;

	private void Awake() => Init();

	public void Init()
	{
		_waitingEffectFinished = false;
		_sequence = DOTween.Sequence();
		initializedEvent.Invoke();
	}

	public void FadeIn()
	{
		_image.color = _startColor;
		_sequence.Append(_image.DOColor(endValue: _endColor, _duration).OnComplete(fadeInFinishedEvent.Invoke));
	}

	public void FadeOut()
	{
		_sequence.Append(_image.DOColor(endValue: _startColor, _duration).OnComplete(fadeOutFinishedEvent.Invoke));
	}
}
