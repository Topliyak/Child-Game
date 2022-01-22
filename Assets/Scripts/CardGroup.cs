using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardGroup")]
public class CardGroup : ScriptableObject
{
	[SerializeField] private Card[] _cards;

	public Card[] Cards => _cards;
}
