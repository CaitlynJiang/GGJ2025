using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BubbleMaster : MonoBehaviour
{
    public int bobbaLeft;
    public delegate void BubbleFinished();
    public static event BubbleFinished bubbleFinished;
    // Start is called before the first frame update
    void OnEnable()
    {
        BubbleLiquidDespawn.bubbleSucked += decreaseBobba;
        bobbaLeft = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        BubbleLiquidDespawn.bubbleSucked -= decreaseBobba;
    }

    public void decreaseBobba()
    {
        bobbaLeft -= 1;
        print("bobba destroyed, " + bobbaLeft + "left");
        if (bobbaLeft <= 0)
        {
            bubbleFinished?.Invoke();
            print("win");
        }
    }
}
