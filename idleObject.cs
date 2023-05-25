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
    public string currCost;
    public AudioSource sound;
    public string flavorText;
    GameObject amountText;
    GameObject costText;
    GameObject tot_xp;
    GameObject xps;
    GameObject hover_ui;
    private Vector3 mousePos;
    private Vector3 objectPos;
    public GameObject hoverObject;
    string initial;
    void Start()
    {
        amountText = this.gameObject.transform.GetChild(0).gameObject;
        costText = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        tot_xp=GameObject.FindWithTag("XP"); 
        xps=GameObject.FindWithTag("XPS");
        costText.GetComponent<Text>().text = startCost.ToString();
        currCost = startCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {   
        if(total>0)
        {
            currCost = string.Format("{0:0}",startCost*Mathf.Pow(costModifier,total));
            if (double.Parse(currCost)>1000000)
            {
                if(double.Parse(currCost)/1000000d>1000)
                {
                    if(double.Parse(currCost)/1000000000d>1000)
                    {
                        costText.GetComponent<Text>().text = string.Format("{0:0.###}",double.Parse(currCost)/(1000000000d*1000d))+"T";
                    }
                    else
                    {
                        costText.GetComponent<Text>().text = string.Format("{0:0.###}",double.Parse(currCost)/1000000000d)+"B";
                    }
                    

                }
                else
                {
                    costText.GetComponent<Text>().text = string.Format("{0:0.###}",double.Parse(currCost)/1000000f)+"M";
                }
            }
            else
            {
                costText.GetComponent<Text>().text = currCost.ToString();
            }
        }
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
    void OnMouseEnter()
    {
        objectPos = this.transform.position;
        objectPos.y = 16;
        hover_ui=Instantiate(hoverObject, objectPos, Quaternion.identity);
        hover_ui.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        objectPos.z=1;
        hover_ui.transform.SetPositionAndRotation(objectPos,Quaternion.identity);
        hover_ui.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = costText.GetComponent<Text>().text;
        hover_ui.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = (baseXP * (30d/rateOfXP)).ToString();
        hover_ui.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = total.ToString();
        hover_ui.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Text>().text = (baseXP * (30d/rateOfXP)*total).ToString();
        hover_ui.transform.GetChild(4).gameObject.GetComponent<Text>().text = flavorText;
    }
    void OnMouseOver()
    {
        hover_ui.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = costText.GetComponent<Text>().text;
        hover_ui.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = (baseXP * (30d/rateOfXP)).ToString();
        hover_ui.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = total.ToString();
        hover_ui.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Text>().text = (baseXP * (30d/rateOfXP)*total).ToString();
    }
    void OnMouseExit()
    {
        Destroy(hover_ui);
    }
    public void purchase()
    {
        if(tot_xp.GetComponent<displayXP>().xp >= double.Parse(currCost))
        {
            tot_xp.GetComponent<displayXP>().xp -= double.Parse(currCost);
            total+=1;
            sound.Play();
        }
    }
}
