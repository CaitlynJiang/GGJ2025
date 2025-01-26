using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckToStraw : MonoBehaviour
{
    public ChargeBarController chargeBarController; 
    public float baseSuckForce = 5f; 

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Bubble") || other.CompareTag("Liquid Particle"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 suckDirection = (other.transform.position - transform.position).normalized;
                float distance = Vector3.Distance(other.transform.position, transform.position);
                float suckForce = chargeBarController.progressSquares.Count * baseSuckForce;
                float currentSuckForce = suckForce * (1 - distance / GetComponent<CircleCollider2D>().radius);

                rb.AddForce(suckDirection * currentSuckForce, ForceMode2D.Force);
            }
        }
    }
}
