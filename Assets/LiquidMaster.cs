using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidMaster : MonoBehaviour
{
    public int liquidLeft;
    // Start is called before the first frame update
    void Awake()
    {
        BubbleLiquidDespawn.liquidSucked += decreaseLiquid;
        liquidLeft = transform.childCount * 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void decreaseLiquid()
    {
        liquidLeft -= 2;
        print("liquid destroyed, " + liquidLeft + "ml left");
        if (liquidLeft <= 10)
        {
            print("lose! bobba still left");
        }
    }
}
