using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckBubble : MonoBehaviour
{
    public ChargeBarController chargeBarController; // 控制吸力的外部组件
    public float baseSuckForce = 5f; // 基础吸力
    public float suckRadius = 2f; // 吸附半径
    public Transform strawStart; // 吸力起点
    public Transform strawEnd; // 吸力终点

    private void Update()
    {
        print(strawStart.position);
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查进入触发器的对象是否有指定的标签
        if (other.CompareTag("Bubble") || other.CompareTag("Liquid Particle"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 计算吸力方向和强度
                Vector3 suckDirection = (strawEnd.position - strawStart.position).normalized;
                //For creating line renderer object
                
                float distance = Vector3.Distance(other.transform.position, strawStart.position);
                float suckForce = chargeBarController.progressSquares.Count * baseSuckForce;
                float currentSuckForce = suckForce * (1 - distance / suckRadius);

                // 应用吸力
                rb.AddForce(suckDirection * currentSuckForce, ForceMode2D.Impulse);
                Debug.Log($"{other.gameObject.name} is being sucked with force {currentSuckForce}");
            }
        }
    }*/

    private void OnTriggerStay2D(Collider2D other)
    {
        // 确保物体在触发器内持续受到吸力
        if (other.CompareTag("Bubble") || other.CompareTag("Liquid Particle"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 suckDirection = (other.transform.position - strawStart.position).normalized;
                float distance = Vector3.Distance(other.transform.position, strawStart.position);
                float suckForce = chargeBarController.progressSquares.Count * baseSuckForce;
                float currentSuckForce = suckForce * (1 - distance / suckRadius);

                rb.AddForce(suckDirection * currentSuckForce, ForceMode2D.Impulse);
            }
        }
    }
}

