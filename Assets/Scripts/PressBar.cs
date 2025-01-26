using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBar : MonoBehaviour
{
    public GameObject progressSquarePrefab;  // 进度方块预设体
    public Transform progressBar;            // 进度条容器

    [Header("Progress Settings")]
    public float holdThreshold = 0.2f;        // 长按时间阈值，达到这个时间增加一格进度
    public float decayTime = 0.5f;          // 松开按键后多长时间下降一格
    public int maxProgress = 25;            // 最大进度方块数量

    [Header("Gradient Colors")]
    public Color startColor = new Color(183f, 28f, 28f); 
    public Color endColor = new Color(253f, 216f, 53f);  

    [Header("Square Properties")]
    public Vector3 squareInitialPosition = new Vector3(0, 0, 0); // 方块初始位置
    public Vector3 squareSize = new Vector3(0.57f, 0.05f, 1.0f); // 方块大小
    public float ySpacing = 0.05f;           // 方块之间的垂直间距

    private float holdTime = 0f;            // 累计的长按时间
    private float lastReleaseTime = 0f;     // 上次松开空格的时间
    public List<GameObject> progressSquares = new List<GameObject>(); // 已生成的进度方块

    void Update()
    {
        // 检测长按空格键
        if (Input.GetKey(KeyCode.Space))
        {
            holdTime += Time.deltaTime; // 累计长按时间

            // 如果长按时间超过阈值，增加一个进度方块
            if (holdTime >= holdThreshold && progressSquares.Count < maxProgress)
            {
                AddProgressSquare();
                holdTime = 0f; // 重置长按时间
            }

            lastReleaseTime = Time.time; // 更新最后一次松开时间
        }
        else
        {
            // 如果没有按下空格且时间超过 decayTime，移除一个进度方块
            if (Time.time - lastReleaseTime > decayTime && progressSquares.Count > 0)
            {
                RemoveProgressSquare();
                lastReleaseTime = Time.time; // 更新最后一次松开时间
            }
        }
        UpdateSquareColors();
    }

    // 添加进度方块
    private void AddProgressSquare()
    {
        GameObject newSquare = Instantiate(progressSquarePrefab, progressBar); // 创建新的方块
        float yOffset = progressSquares.Count * ySpacing; // 根据当前方块数量设置 Y 偏移
        newSquare.transform.localPosition = squareInitialPosition + new Vector3(0, yOffset, 0); // 设置位置
        newSquare.transform.localScale = squareSize; // 设置大小
        progressSquares.Add(newSquare);  // 将新方块加入列表
    }

    // 移除进度方块
    private void RemoveProgressSquare()
    {
        GameObject squareToRemove = progressSquares[progressSquares.Count - 1]; // 获取最后一个进度方块
        progressSquares.RemoveAt(progressSquares.Count - 1);  // 从列表中移除它
        Destroy(squareToRemove);  // 销毁方块
    }

    // 更新所有方块的颜色
    private void UpdateSquareColors()
    {
        int squareCount = progressSquares.Count; // 当前方块数量
        for (int i = 0; i < squareCount; i++)
        {
            GameObject square = progressSquares[i];
            Renderer renderer = square.GetComponent<Renderer>(); // 获取方块的 Renderer
            if (renderer != null)
            {
                // 计算当前方块的颜色，位置越靠上（索引越大）越接近 endColor
                float colorRatio = (float)i / (squareCount - 1); // 计算当前方块在进度条中的位置比例
                Color currentColor = Color.Lerp(startColor, endColor, colorRatio); // 线性插值颜色
                renderer.material.color = currentColor; // 设置材质颜色
            }
        }
    }

}

