using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotsMove : MonoBehaviour {
    private Transform player;
    public Rigidbody bot;
    public Transform botTrans;
    private AudioSource botSound;
    Vector3 movement;
    public float speed = 1;    
    public float chaseDistance;
    private float dist;
    public MonoBehaviour rotation;
   
    

    private static BotsMove instance;

	// Use this for initialization
	void Awake () {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;        
        rotation = GetComponent<Rotator>();
        bot = GetComponent<Rigidbody>();
        botTrans = GetComponent<Transform>();
        rotation.enabled = true;
        botSound = GetComponent<AudioSource>();
        botSound.enabled = false;


    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.y < -10F) Destroy(transform.gameObject);

        dist = Vector3.Distance(player.position, transform.position);
        if (dist < chaseDistance)
        {
            
            rotation.enabled = false;
            botSound.enabled = true;
            Moving();
            
        }
        else if (dist>=chaseDistance)
        {
            
            rotation.enabled = true;
            botSound.enabled = false;
        }
	}

    void Moving()
    {         
            
        if (transform.position != player.position)
        {
            movement = player.position - transform.position;
            movement.x = movement.x *speed * Time.deltaTime;
            movement.y = 0;
            movement.z = movement.z * speed * Time.deltaTime;
            bot.position += movement;
        }
                

           
        
    }
}
