using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickerItem : MonoBehaviour
{
    double tickerWidth;
    float pixelsPerSecond;
    RectTransform rt;

    public double GetXPosition { get { return rt.anchoredPosition.x; } }
    public double GetWidth { get { return rt.rect.width;  } }

    public void initialize(double tickerWidth, float pixelsPerSecond, string message)
    {
        this.tickerWidth = tickerWidth;
        this.pixelsPerSecond = pixelsPerSecond;
        rt = GetComponent<RectTransform>();
        GetComponent<Text>().text = message;
    }

    // Update is called once per frame
    void Update()
    {
        rt.position += Vector3.left * pixelsPerSecond * Time.deltaTime;
        if(GetXPosition <= 0 - tickerWidth - GetWidth - 8)
        {
            Destroy(gameObject);
        }
    }
}
