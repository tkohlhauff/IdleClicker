using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoverStats : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cost;
    public GameObject xpsPer;
    public GameObject owned;
    public GameObject tot_xps;
    public GameObject flavor;
    void Start()
    {
        cost = this.gameObject.transform.GetChild(0).gameObject;
        xpsPer = this.gameObject.transform.GetChild(1).gameObject;
        owned = this.gameObject.transform.GetChild(2).gameObject;
        tot_xps = this.gameObject.transform.GetChild(3).gameObject;
        flavor = this.gameObject.transform.GetChild(4).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
