using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTimer : MonoBehaviour
{
    public Text timerText; // 计时显示的Text UI
    private bool isTiming = false;
    private float startTime;
    private float elapsedTime;

    void Update()
    {
        // 如果正在计时，更新显示时间
        if (isTiming)
        {
            elapsedTime = Time.time - startTime;
            timerText.text = "Time: " + elapsedTime.ToString("F2") + "s";
        }
    }

    void OnMouseDown()
    {
        // 检查是否已经在计时
        if (isTiming)
        {
            // 停止计时
            isTiming = false;
        }
        else
        {
            // 开始计时
            isTiming = true;
            startTime = Time.time;
        }
    }
}