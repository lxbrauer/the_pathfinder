using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {

	public string GameOverScene;
	public float timer=100;

    private static CountdownTimer instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    private void GameStart () 
	{
        timer += timer;
        enabled = true;
        
		
	}
    private void GameOver()
    {
        enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
	{
	
		timer -= Time.deltaTime;
		
		if (timer <= 0) {
			SceneManager.LoadScene(GameOverScene, LoadSceneMode.Single);
		}
        GUIManager.SetTime(timer);
    }

    public static void GiveScore(out float give)
    {   
        give = instance.timer;
    }
}

