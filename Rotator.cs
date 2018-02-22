using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float x = 0;
    public float y = 50;
    public float z = 0;

	void Update () 

	{
		transform.Rotate (new Vector3 (x, y, z) * Time.deltaTime);	
	}
}
