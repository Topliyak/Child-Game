using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
	[SerializeField] private Sprite _sprite;
	[SerializeField] private string _answer;
	[SerializeField] private float _rotation;

	public Card(Sprite sprite, string answer)
	{
		_sprite = sprite;
		_answer = answer;
	}

	public Sprite Sprite => _sprite;

	public string Answer => _answer;

	public float Rotation => _rotation;
}
