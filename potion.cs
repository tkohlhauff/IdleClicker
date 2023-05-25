using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    public float buffTime;
    public double buffMod;
    public double cost;
    public GameObject[] idleObjects;
    GameObject tot_xp;
    GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        tot_xp = GameObject.FindWithTag("XP");
        shop = GameObject.FindWithTag("shop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void applyPotion()
    {
        if(tot_xp.GetComponent<displayXP>().xp >= cost)
        {
            idleObjects = GameObject.FindGameObjectsWithTag("idleobject");
            shop.GetComponent<OpenShop>().buffTimes.Add(buffTime);
            shop.GetComponent<OpenShop>().buffMods.Add(buffMod);
            tot_xp.GetComponent<displayXP>().xp-=cost;
            foreach (GameObject idleObject in idleObjects)
            {
                idleObject.GetComponent<idleObject>().baseXP=idleObject.GetComponent<idleObject>().baseXP*buffMod;
            }
        }
    }
}
