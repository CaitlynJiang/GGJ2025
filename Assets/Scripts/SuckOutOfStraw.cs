using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckOutOfStraw : MonoBehaviour
{
    public ChargeBarController chargeBarController;
    public float baseSuckForce = 5f;
    public Transform endPos;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Bubble") || other.CompareTag("Liquid Particle"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 suckDirection = (other.transform.position - endPos.position).normalized;
                float suckForce = chargeBarController.progressSquares.Count * baseSuckForce;

                rb.AddForce(-suckDirection * suckForce, ForceMode2D.Force);
            }
        }
    }
}
