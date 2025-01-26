using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidMaster : MonoBehaviour
{
    public int liquidLeft;
    // Start is called before the first frame update
    public delegate void LiquidLeft();
    public static event LiquidLeft liquidLeftEvent;
    private void OnEnable ()
    {
        BubbleLiquidDespawn.liquidSucked += decreaseLiquid;
        liquidLeft = transform.childCount * 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        BubbleLiquidDespawn.liquidSucked -= decreaseLiquid;
    }

    public void decreaseLiquid()
    {
        liquidLeft -= 2;
        print("liquid destroyed, " + liquidLeft + "ml left");
        if (liquidLeft <= 5)
        {
            liquidLeftEvent?.Invoke();
            print("lose! bobba still left");
        }
    }
}
