using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class displayXP : MonoBehaviour
{
    // Start is called before the first frame update
    public double xp = 0;
    double shortxp;
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = xp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(xp>1000000)
        {
            shortxp = xp/(double)1000000;
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
                this.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.###}",xp/(double)1000000) + "M";
            }
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = xp.ToString();
        }
    }
}
