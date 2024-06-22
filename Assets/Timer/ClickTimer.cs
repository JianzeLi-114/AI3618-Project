using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTimer : MonoBehaviour
{
    public Text timerText; // ��ʱ��ʾ��Text UI
    private bool isTiming = false;
    private float startTime;
    private float elapsedTime;

    void Update()
    {
        // ������ڼ�ʱ��������ʾʱ��
        if (isTiming)
        {
            elapsedTime = Time.time - startTime;
            timerText.text = "Time: " + elapsedTime.ToString("F2") + "s";
        }
    }

    void OnMouseDown()
    {
        // ����Ƿ��Ѿ��ڼ�ʱ
        if (isTiming)
        {
            // ֹͣ��ʱ
            isTiming = false;
        }
        else
        {
            // ��ʼ��ʱ
            isTiming = true;
            startTime = Time.time;
        }
    }
}