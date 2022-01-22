using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
	public Card[,] Cards { get; set; }

	public string Answer { get; set; }

	public string Text => $"Find {Answer}";
}
