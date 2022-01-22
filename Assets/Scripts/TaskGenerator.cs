using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class UnityEventTask: UnityEvent<Task> { }

public class TaskGenerator : MonoBehaviour
{
	private List<Card> _unusedCards;
	private CardGroup[] _orderedCardGroups;
	private int _currentCardGroupIndexInOrder;

	[SerializeField] private CardGroup[] _cardGroups;

	public UnityEventTask taskGeneratedEvent;

	private void Awake() => Init();

	public void Init()
	{
		_unusedCards = new List<Card>();
		CreateCardGroupsOrder();
		_currentCardGroupIndexInOrder = 0;
		UpdateUnusedCardsList();
	}

	public CardGroup CurrentCardGroup => _orderedCardGroups[_currentCardGroupIndexInOrder];

	public void Generate(int rows, int columns)
	{
		Task task = new Task();
		task.Cards = new Card[rows, columns];

		for (int row = 0; row < rows; row++)
			for (int column = 0; column < columns; column++)
				task.Cards[row, column] = TakeRandomUnusedCard();

		int correctCardIndex = Random.Range(0, task.Cards.Length);
		int correctCardRow = correctCardIndex / task.Cards.GetLength(1);
		int correctCardColumn = correctCardIndex % task.Cards.GetLength(1);
		Card correctCard = task.Cards[correctCardRow, correctCardColumn];
		task.Answer = correctCard.Answer;

		taskGeneratedEvent.Invoke(task);
	}

	public void Generate(TableSize tableSize) => Generate(tableSize.Rows, tableSize.Columns);

	public void ResetGenerator()
	{
		SelectNextCardGroup();
		UpdateUnusedCardsList();
	}

	private Card TakeRandomUnusedCard()
	{
		if (_unusedCards.Count == 0)
			throw new UnityException(message: "Cards from current card group are over");

		int unusedCardIndex = Random.Range(0, _unusedCards.Count);
		Card card = _unusedCards[unusedCardIndex];
		_unusedCards.RemoveAt(unusedCardIndex);

		return card;
	}

	private void SelectNextCardGroup()
	{
		_currentCardGroupIndexInOrder++;
		_currentCardGroupIndexInOrder %= _orderedCardGroups.Length;
	}

	private void UpdateUnusedCardsList()
	{
		_unusedCards.Clear();
		_unusedCards = CurrentCardGroup.Cards.ToList();
	}

	private void CreateCardGroupsOrder()
	{
		_orderedCardGroups = new CardGroup[_cardGroups.Length];
		_cardGroups.CopyTo(_orderedCardGroups, 0);

		for (int i = 0; i < _orderedCardGroups.Length; i++)
		{
			int index = Random.Range(i, _orderedCardGroups.Length);

			CardGroup cardGroup = _orderedCardGroups[index];
			_orderedCardGroups[index] = _orderedCardGroups[i];
			_orderedCardGroups[i] = cardGroup;
		}
	}
}
