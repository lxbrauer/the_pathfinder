using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour {

	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;

	public Canvas canvas;

	void Start () 
	{
	
		canvas = canvas.GetComponent<Canvas>();
		canvas.enabled = false;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvas.enabled = !canvas.enabled;
			Pause ();
		}
	}

	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Lowpass();
	}

	void Lowpass()
	{
		if (Time.timeScale == 0) 
		{
			paused.TransitionTo (.01f);
		}

		else
		{
			unpaused.TransitionTo (.01f);
		}
			
	}
}
