using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class xpsCount : MonoBehaviour
{
    // Start is called before the first frame update
    public double xps;
    public GameObject[] idleObjects;
    double shortxp;
    double tempxps;
    void Start()
    {
        idleObjects = GameObject.FindGameObjectsWithTag("idleobject");   
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject idleObject in idleObjects)
        {
            if (idleObject.GetComponent<idleObject>().total>0)
            {
                tempxps += (idleObject.GetComponent<idleObject>().baseXP * (30d/idleObject.GetComponent<idleObject>().rateOfXP))*idleObject.GetComponent<idleObject>().total;

            }
        }
        if(tempxps != xps)
        {
            xps=tempxps;
        }
        tempxps=0;
        if(xps>1000000)
        {
            shortxp = xps/1000000d;
            if(shortxp>1000)
            {
                shortxp = shortxp/1000d;
                if(shortxp > 1000)
                {
                    this.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.###}",shortxp/1000d) + "T";
                }
                else
                {
                    this.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.###}",shortxp) + "B";
                }
            }
            else
            {
                this.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.###}",shortxp) + "M";
            }
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = xps.ToString();
        }
    }
}
