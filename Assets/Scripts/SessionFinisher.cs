using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SessionFinisher : MonoBehaviour
{
	public UnityEvent sessionFinishedEvent;

	public void OnSessionFinished()
	{
		sessionFinishedEvent.Invoke();
	}
}
