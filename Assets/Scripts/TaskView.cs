using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskView : MonoBehaviour
{
	[SerializeField] private Text _text;

	public void UpdateView(string text)
	{
		_text.text = text;
	}

	public void UpdateView(Task task) => UpdateView(task.Text);
}
