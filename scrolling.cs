using UnityEngine;
using System.Collections;

public class scrolling : MonoBehaviour
{
    public float scrollSpeed = 0.2f;   
    public GameObject[] shops;
    public GameObject[] rests;
    public GameObject[] banks;
    public GameObject end;
    private static scrolling instance;

    private void Start()
    {
        instance = this;
        Invoke("Then", 1);
    }
    void Then()
    {
        instance.shops = GameObject.FindGameObjectsWithTag("shop");
        instance.rests = GameObject.FindGameObjectsWithTag("restaurant");
        instance.banks = GameObject.FindGameObjectsWithTag("bank");
        end = GameObject.Find("End(Clone)");

       

    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        foreach(GameObject obj in rests)
        { if (obj != null)
                obj.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, 1.2F*offset);
        }
        foreach (GameObject obj in shops)
        {
            if (obj != null)
                obj.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset);
        }
        foreach (GameObject obj in banks)
        {
            if (obj != null)
                obj.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, 2F*offset);
        }
        if (end != null)
            end.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, 2F * offset);
    }

    //give total numbers of available POIs to OpenGate
    public static void ProgrammOpenGate(out int x, out int y, out int z)
    {
        x = instance.rests.Length;
        y = instance.shops.Length;
        z = instance.banks.Length;
    }
}