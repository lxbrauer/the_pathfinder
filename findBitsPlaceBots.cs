using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findBitsPlaceBots : MonoBehaviour {

    public GameObject[] bits;
    public GameObject bot;
    public float probability = 1/6F;

	// Use this for initialization
	void Start () {
        Invoke("Then", 1);
	}
	void Then()
    {   bits = GameObject.FindGameObjectsWithTag("boost");

        foreach (GameObject obj in bits)
        {
            int i = Random.Range(0, 10);
            if (i <= probability)
            {
                if (obj != null)
                {
                    float x = Random.Range(-300, 300);
                    float z = Random.Range(-300, 300);
                    Instantiate(bot, new Vector3(x, 0.25F, z), Quaternion.identity);
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
