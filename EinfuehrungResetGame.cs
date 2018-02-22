using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EinfuehrungResetGame : MonoBehaviour {

	public string RestartGame;
	public float timer;
    public GameObject cube, GUI, GUIM;
    //private Text timerSeconds;
    private EinfuehrungResetGame instance;

	// Use this for initialization
	void Start () {
        instance = this;
        cube = GameObject.Find("Cube");
        GUI = GameObject.Find("GUI");
        GUIM = GameObject.Find("GUIManager");

		//timerSeconds = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

		instance.timer -= Time.deltaTime;
        //timerSeconds.text = timer.ToString ("f1");

        if (instance.timer <= 0)
        {   if(cube !=null && GUI !=null &&GUIM != null)
            {
                cube.SetActive(true);
                GUI.SetActive(true);
                GUIM.SetActive(true);
            }            
            SceneManager.LoadScene(RestartGame, LoadSceneMode.Single);
            
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (cube != null && GUI != null && GUIM != null)
            {
                cube.SetActive(true);
                GUI.SetActive(true);
                GUIM.SetActive(true);
            }
            SceneManager.LoadScene(RestartGame, LoadSceneMode.Single);            
        }

        else if(instance.timer>0)
        {
            if (cube != null && GUI != null && GUIM != null)
            {
                cube.SetActive(false);
                GUI.SetActive(false);
                GUIM.SetActive(false);
            }
        }
            
		
		

	}
}


