using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleLiquidDespawn : MonoBehaviour
{
    public delegate void BubbleSucked();
    public static event BubbleSucked bubbleSucked;
    public delegate void LiquidSucked();
    public static event LiquidSucked liquidSucked;
    // Start is called before the first frame update
    void Start()
    {
        bubbleSucked?.Invoke();
        liquidSucked?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            Destroy(other.gameObject);
            bubbleSucked?.Invoke();
        } else if (other.CompareTag("Liquid Particle"))
        {
            Destroy(other.gameObject);
            liquidSucked?.Invoke();
        }
    }
}
