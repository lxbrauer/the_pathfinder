using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

    public Canvas gameOverText, instructionsText, TitelText, boostText, restaurantText, shopCount, bankCount;
    public Text timeText, boosts, restaurant, shop, bank, sceneName;
    public string shoptarg, resttarg, banktarg;
    public int shopInt, restInt, bankInt;
    public string GameOverScene;
    public float timer,boostToGive;


    private static GUIManager instance;

    
    // Use this for initialization
    void Start () {
        instance = this;
        sceneName.text = SceneManager.GetActiveScene().name;
        GameEventManager.GameOver += GameOver;
        GameEventManager.GameStart += GameStart;               
        TitelText.enabled = true;
        boostText.enabled = false;
        restaurantText.enabled = false;
        shopCount.enabled = false;
        bankCount.enabled = false;
        gameOverText.enabled = false;
        instructionsText.enabled = true;
        enabled = true;

    }
   

    private void GameStart()
    {
        TitelText.enabled = false;
        
        boostText.enabled = true;
        restaurantText.enabled = true;
        shopCount.enabled = true;
        bankCount.enabled = true;
        gameOverText.enabled = true;
        instructionsText.enabled = false;
        enabled = false;
    }
    private void GameOver()
    {
        TitelText.enabled = true;
        
        boostText.enabled = false;
        restaurantText.enabled = false;
        shopCount.enabled = false;
        bankCount.enabled = false;
        gameOverText.enabled = false;
        instructionsText.enabled = true;
        enabled = true;
        
    }

    // Update is called once per frame
    void Update () {
        sceneName.text = SceneManager.GetActiveScene().name;
        if (Input.GetButtonDown("Jump"))
        {                       
            GameEventManager.TriggerGameStart();
        }

        
    }
    public static void SetBoost(float boostCount)
    {
        instance.boostToGive = boostCount;
        instance.boosts.text = boostCount.ToString("f0");
    }
    

    public static void SetTime(float time)
    {
        instance.timeText.text = time.ToString("f1");
    }

    public static void SetRestaurant(float restaurants)
    {

        if (instance.restInt > restaurants)
        {
            string restaurant = restaurants.ToString("f0");
            instance.restaurant.text = restaurants.ToString(restaurant + " / " + instance.resttarg);
        }
        else instance.restaurant.text = ("ready!");

    }
    public static void SetShops(float shops)
    {

        if (instance.shopInt > shops)
        {
            string shop = shops.ToString("f0");
            instance.shop.text = shops.ToString(shop + " / " + instance.shoptarg);
        }
        else instance.shop.text = ("ready!");

    }
    public static void SetBanks(float banks)
    {

        if (instance.bankInt > banks)
        {
            string bank = banks.ToString("f0");
            instance.bank.text = (bank + " / " + instance.banktarg);
        }
        else instance.bank.text = ("ready!");


    }

    public static void SetTarget(int restTarget, int shopTarget, int bankTarget)
    {
        instance.shopInt = shopTarget;
        instance.restInt = restTarget;
        instance.bankInt = bankTarget;
        instance.resttarg = restTarget.ToString("f0");
        instance.shoptarg = shopTarget.ToString("f0");
        instance.banktarg = bankTarget.ToString("f0");
    }

    public static void GiveScore(out float boostsToGive)
    {
        boostsToGive = instance.boostToGive;
    }

}
