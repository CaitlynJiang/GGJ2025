using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BubbleMaster : MonoBehaviour
{
    public int bobbaLeft;
    // Start is called before the first frame update
    void Start()
    {
        BubbleLiquidDespawn.bubbleSucked += decreaseBobba;
        bobbaLeft = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseBobba()
    {
        bobbaLeft -= 1;
        print("bobba destroyed, " + bobbaLeft + "left");
        if (bobbaLeft <= 0)
        {
            print("win");
        }
    }
}
