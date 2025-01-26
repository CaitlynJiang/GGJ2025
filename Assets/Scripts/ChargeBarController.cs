using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBarController : MonoBehaviour
{
    public GameObject progressSquarePrefab;  // 进度方块预设体
    public Transform progressBar;            // 进度条容器

    public AudioSource Suck;

    [Header("Progress Settings")]
    public float spacePressThreshold = 5;    // 按下多少次 space 增加一格进度
    public float resetTime = 0.5f;           // 超过时间限制后下降一格

    [Header("Square Properties")]
    public Vector3 squareInitialPosition = new Vector3(0, 0, 0); // 方块初始位置
    public Vector3 squareSize = new Vector3(0.57f, 0.05f, 1.0f); // 方块大小
    public float ySpacing = 0.05f;           // 方块之间的垂直间距

    private int pressCount = 0;              // 按下 space 的次数
    private float lastPressTime = 0f;        // 上次按下时间
    public List<GameObject> progressSquares = new List<GameObject>(); // 已生成的进度方块

    void Start()
    {
        //Suck = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 检测按下 space 键
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAudio();
            pressCount++;

            // 计算最后一次按下的时间
            lastPressTime = Time.time;

            // 每按 5 次 space 增加一个进度方块
            if (pressCount >= spacePressThreshold)
            {
                AddProgressSquare();
                pressCount = 0;  // 重置按键计数
            }
        }

        // 如果超过了设定的时间限制没有按下 space 键，移除一个进度方块
        if (Time.time - lastPressTime > resetTime && progressSquares.Count > 0)
        {
            RemoveProgressSquare();
            lastPressTime = Time.time;
        }
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

    private void PlayAudio()
    {
        if (progressSquares.Count == 0)
        {
            Suck.Play();
        }
    }
}
