using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class idleObject : MonoBehaviour
{
    // Start is called before the first frame update
    public int startCost;
    public int total;
    public float costModifier;
    public double baseXP;
    public int rateOfXP;
    GameObject amountText;
    GameObject costText;
    GameObject tot_xp;
    GameObject xps;
    string currCost;
    string initial;
    void Start()
    {
        amountText = this.gameObject.transform.GetChild(0).gameObject;
        costText = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        tot_xp=GameObject.FindWithTag("XP"); 
        xps=GameObject.FindWithTag("XPS");
    }

    // Update is called once per frame
    void Update()
    {   
        if(total>0)
        {
            currCost = string.Format("{0:0}",startCost*Mathf.Pow(costModifier,total));
            if (float.Parse(currCost)>1000000)
            {
                if(float.Parse(currCost)/(float)1000000>1000)
                {
                    currCost=(float.Parse(currCost)/(float)1000000000).ToString();
                    Debug.Log(currCost);
                    if(float.Parse(currCost)>1000)
                    {
                        currCost = string.Format("{0:0.###}",float.Parse(currCost)/(float)1000)+"T";
                    }
                    else
                    {
                        currCost = string.Format("{0:0.###}",float.Parse(currCost))+"B";
                    }
                    

                }
                else
                {
                    currCost = string.Format("{0:0.###}",float.Parse(currCost)/(float)1000000)+"M";
                }
                

            }
        }
        else
        {
            currCost = startCost.ToString();
        }
        costText.GetComponent<Text>().text = currCost;
        amountText.GetComponent<Text>().text = total.ToString();
        if (total >= rateOfXP)
        {
            tot_xp.GetComponent<displayXP>().xp+=(total/rateOfXP)*baseXP;
        }
        else
        {
            if(Time.frameCount % (rateOfXP/total) == 0)
            {
                tot_xp.GetComponent<displayXP>().xp+=baseXP;
            }
        }
    }
    public void purchase()
    {
        if(tot_xp.GetComponent<displayXP>().xp >= int.Parse(costText.GetComponent<Text>().text))
        {
            tot_xp.GetComponent<displayXP>().xp -= int.Parse(costText.GetComponent<Text>().text);
            total+=1;
            xps.GetComponent<xpsCount>().xps += baseXP * (30d/rateOfXP);
        }
    }
}
