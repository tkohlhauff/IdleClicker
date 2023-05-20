using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class xpsCount : MonoBehaviour
{
    // Start is called before the first frame update
    public double xps;
    double shortxp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                this.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.###}",xps/1000000d) + "M";
            }
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = xps.ToString();
        }
    }
}
