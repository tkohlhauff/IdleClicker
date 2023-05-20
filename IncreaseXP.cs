using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IncreaseXP : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject tot_xp;
    void Start()
    {
       tot_xp=GameObject.FindWithTag("XP"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clicked()
    {
        tot_xp.GetComponent<displayXP>().xp+=1;

    }
}

