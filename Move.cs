namespace Mapbox.Unity.Map
{
    using System;
    using Mapbox.Unity.Utilities;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using Utils;
    using Mapbox.Map;
    using System.Collections;
    using System.Collections.Generic;

    public class Move : MonoBehaviour
    {
        private static Move instance;        
        public float bitCount = 25;              
        public int routComplete;        
        public float speed = 6.0F;
        public float jumpSpeed = 8.0F;
        public float gravity = 20.0F;
        public float yRotation = 5.0F;
        private Vector3 moveDirection = Vector3.zero;
        public Vector3 startPosition;        
        public int shopCount, restaurantCount, bankCount;
        public string GameOverScene, NextScene;
        public MonoBehaviour DontDestroy;
        
        //Audio
        public AudioClip bitSound;
        private AudioSource bit;
        public AudioClip botSound;
        private AudioSource bot;
        public AudioClip jumpSound;
        private AudioSource jump;
        public AudioClip POICollect;
        private AudioSource POI;
        private float volLowRange = 0.8f;
        private float volHighRange = 1.0f;


        void Start()
        {
            instance = this;
            startPosition = transform.localPosition;        
            GameEventManager.GameStart += GameStart;
            GameEventManager.GameOver += GameOver;
            startPosition = transform.localPosition;            
            enabled = false;
            

            //initialize Audio
            bot = GetComponent<AudioSource>();
            bit = GetComponent<AudioSource>();
            jump = GetComponent<AudioSource>();
            POI = GetComponent<AudioSource>();
            
        }

        private void GameStart()
        {
            bitCount = 25f;
            restaurantCount = 0;
            shopCount = 0;
            bankCount = 0;
            speed = (0.3F* bitCount);                        
            enabled = true;                        
        }

        private void GameOver()
        {
            transform.localPosition = startPosition;
            enabled = false;
        }
               

        void Update()
        {            
                CharacterController controller = GetComponent<CharacterController>();
                speed = (0.3F * bitCount);

                yRotation += 2.5F *Input.GetAxis("Horizontal");
                
                transform.eulerAngles = new Vector3(5, yRotation, 0);

                if (controller.isGrounded)
                {
                    moveDirection = new Vector3(0.3F*Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= speed;

                    if (Input.GetButton("Jump"))
                    {
                        moveDirection.y = jumpSpeed;
                        float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
                        bit.PlayOneShot(jumpSound, vol);
                    }                        

                }
                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime);
              
                //Give current values to GUIManager
                GUIManager.SetBoost(bitCount);               
                GUIManager.SetRestaurant(restaurantCount);
                GUIManager.SetShops(shopCount);
                GUIManager.SetBanks(bankCount);
                //Give current values to OpenGate
                OpenGate.SetOpen(restaurantCount, shopCount, bankCount);

                //Conditions for Gameover
                if (bitCount <= 0 || transform.localPosition.y<-10F)
                {
                    GameEventManager.TriggerGameOver();
                    SceneManager.LoadScene(GameOverScene, LoadSceneMode.Single);
                    this.enabled = false;
                    routComplete = 0;                    
                }                  
                           

        }
       
        private void OnTriggerEnter(Collider other)
        {
            //Condition to complete a route/level
            //routComplete counts up for each level to get the right level to be loaded
            if (other.name == "End(Clone)")
            {
                instance.routComplete += 1;
                string count = instance.routComplete.ToString();
                string SceneName = NextScene+count;
                GameEventManager.TriggerGameOver();
                SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
                this.enabled = false;

            }
            
            if(other.tag == "boost")
            {   //Audio Hit
                float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
                bit.PlayOneShot(bitSound, vol);
                //collecting Bits
                bitCount += 1;
                Destroy(other.gameObject);
            }
            if (other.tag == "shop")
            {   //Audio Hit
                float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
                POI.PlayOneShot(POICollect, vol);
                //collecting shops
                shopCount += 1;
                Destroy(other.gameObject);
            }
            if (other.tag == "restaurant")
            {   //Audio Hit
                float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
                POI.PlayOneShot(POICollect, vol);
                //collecting restaurants
                restaurantCount += 1;
                Destroy(other.gameObject);
            }
            if (other.tag == "bank")
            {   //Audio Hit
                float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
                POI.PlayOneShot(POICollect, vol);
                //collecting banks
                bankCount += 1;
                Destroy(other.gameObject);
            }
            if (other.tag == "bot")
            {   //Audio Hit
                float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
                bot.PlayOneShot(botSound, vol);
                //collecting bots
                bitCount -= 5;
                Destroy(other.gameObject);

            }
        }

        public static void GiveScore(out float give)
        {
            give = instance.bitCount;
        }

        
    }
}