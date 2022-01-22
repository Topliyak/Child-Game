using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventDifficultyLevel: UnityEvent<DifficultyLevel> { }

public class LevelSwitcher : MonoBehaviour
{
	[SerializeField] private Levelnfo _levelInfo;

	public UnityEventDifficultyLevel levelSwitchedEvent;
	public UnityEvent firstLevelStartedEvent;
	public UnityEvent lastLevelFinishedEvent;

	public void OnCorrectAnswer()
	{
		if (_levelInfo.Difficulty != DifficultyLevel.Hard)
			NextLevel();
		else
			lastLevelFinishedEvent.Invoke();
	}

	public void NextLevel()
	{
		if (_levelInfo.Difficulty == DifficultyLevel.Easy)
		{
			_levelInfo.Difficulty = DifficultyLevel.Middle;
		}
		else if (_levelInfo.Difficulty == DifficultyLevel.Middle)
		{
			_levelInfo.Difficulty = DifficultyLevel.Hard;
		}

		levelSwitchedEvent.Invoke(_levelInfo.Difficulty);
	}

	public void FirstLevel()
	{
		_levelInfo.Difficulty = DifficultyLevel.Easy;
		firstLevelStartedEvent.Invoke();
		levelSwitchedEvent.Invoke(_levelInfo.Difficulty);
	}
}
