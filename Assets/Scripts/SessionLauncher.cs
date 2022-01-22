using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SessionLauncher : MonoBehaviour
{
	public UnityEvent sessionLaunchedEvent;

	private void Start()
	{
		Launch();
	}

	public void Launch() => sessionLaunchedEvent.Invoke();
}
