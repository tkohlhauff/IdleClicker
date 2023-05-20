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
            shortxp = xps/(double)1000000;
            if(shortxp>1000)
            {
                shortxp = shortxp/(double)1000;
                if(shortxp > 1000)
                {
                    this.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.###}",shortxp/(double)1000) + "T";
                }
                else
                {
                    this.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.###}",shortxp) + "B";
                }
            }
            else
            {
                this.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.###}",xps/(double)1000000) + "M";
            }
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = xps.ToString();
        }
    }
}
