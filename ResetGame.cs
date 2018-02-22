using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResetGame : MonoBehaviour {

    public string RestartGame; 
	public float timer;
	private Text timerSeconds;
    public Scene Charlottenburg;

	// Use this for initialization
	void Start () {

        Resources.UnloadUnusedAssets();
        timerSeconds = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		//timerSeconds.text = timer.ToString ("f1");

		if (timer <= 0)
		{
			SceneManager.LoadScene(RestartGame, LoadSceneMode.Single);
		}

		else if (Input.GetKeyDown (KeyCode.Space)) 

			SceneManager.LoadScene (RestartGame, LoadSceneMode.Single);
		
		

	}
}


