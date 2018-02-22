using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {
    
    public Collider scollider;
    public bool open = false;
    public int restTarget = 3;
    public int shopTarget = 3;
    public int bankTarget = 3;


    private static OpenGate instance; 
	// Use this for initialization
	void Start () {
        instance = this;
        scollider = scollider.GetComponent<CapsuleCollider>();
        scollider.isTrigger = false;
        
        //take number of available POIs and set a target number with a certain ratio
        scrolling.ProgrammOpenGate(out restTarget, out shopTarget, out bankTarget);
        float r= restTarget * 0.05F;
        restTarget=(int) r;
        float s = shopTarget * 0.15F;
        shopTarget = (int)s;
        float b = bankTarget * 0.25F;
        bankTarget = (int)b;
        GUIManager.SetTarget(restTarget, shopTarget, bankTarget);

    }
    	
	// Update is called once per frame
	void Update () {

        if (open == true)
            scollider.isTrigger= true;
        
    }
    
    //check if target number of POIs is reached => open Gate to next Level
    // gets each current number from move.cs
    public static void SetOpen(int restaurant, int shop, int banks)
    {
        if (restaurant >= instance.restTarget && shop >= instance.shopTarget && banks >=instance.bankTarget)
        {
            instance.open = true;
        }                               

    }
    
    
}
