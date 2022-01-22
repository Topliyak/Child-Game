using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCellView : MonoBehaviour
{
	[SerializeField] private Image _image;
	[SerializeField] private RectTransform _rectTransform;

	public Image Image => _image;

	public void UpdateView(Sprite sprite, float rotation)
	{
		_image.sprite = sprite;
		_rectTransform.rotation = Quaternion.Euler(0, 0, rotation);
	}
}
