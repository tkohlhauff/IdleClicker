using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject shopObj;
    public List<float> buffTimes = new List<float>();
    public List<double> buffMods = new List<double>();
    public GameObject[] idleObjects;
    GameObject shopUI;
    private Vector3 objectPos;
    bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(buffTimes.Count>0)
        {
            for(int x=0;x<buffTimes.Count;x++)
            {
                buffTimes[x] -=Time.deltaTime;
                if(buffTimes[x]<=0)
                {
                    idleObjects = GameObject.FindGameObjectsWithTag("idleobject");
                    foreach(GameObject idleObject in idleObjects)
                    {
                        idleObject.GetComponent<idleObject>().baseXP=idleObject.GetComponent<idleObject>().baseXP/buffMods[x];
                    }
                    buffTimes.RemoveAt(x);
                    buffMods.RemoveAt(x);
                }
            }
        }
        
    }
    public void shop()
    {
        if(!clicked)
        {
            objectPos = this.transform.position;
            objectPos.y += 18;
            shopUI=Instantiate(shopObj, objectPos, Quaternion.identity);
            shopUI.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            objectPos.z=1;
            shopUI.transform.SetPositionAndRotation(objectPos,Quaternion.identity);
            clicked = true;
        }
        else
        {
            Destroy(shopUI);
            clicked = false;
        }
    }
}
