using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnswerClickHandler : MonoBehaviour
{
	[SerializeField] private AnswerTable _answerTable;
	[SerializeField] private Levelnfo _levelInfo;

	public UnityEventCellIndex correctAnswerEvent;
	public UnityEventCellIndex wrongAnswerEvent;

	public void HandleAnswerClick(CellIndex cellIndex)
	{
		string selectedAnswer = _levelInfo.Task.Cards[cellIndex.Row, cellIndex.Column].Answer;
		string correctAnswer = _levelInfo.Task.Answer;

		if (selectedAnswer.Equals(correctAnswer))
		{
			correctAnswerEvent.Invoke(cellIndex);
		}
		else
		{
			wrongAnswerEvent.Invoke(cellIndex);
		}
	}
}
