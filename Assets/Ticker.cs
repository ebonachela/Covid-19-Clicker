using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticker : MonoBehaviour
{
    public TickerItem tickerItemPrefab;
    [Range(1f, 10f)]
    public double itemDuration = 3.0;
    public List<string> tickerItems = new List<string>();
    private List<string> tickerItemsSave;

    double width;
    float pixelsPerSecond;
    TickerItem currentItem;

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        pixelsPerSecond = (float)(width / itemDuration);
        tickerItemsSave = new List<String>(tickerItems);
        AddTickerItem();
    }

    private void AddTickerItem()
    {
        int itemRemove = UnityEngine.Random.Range(0, tickerItems.Count);
        string message = tickerItems[itemRemove];

        tickerItems.RemoveAt(itemRemove);

        currentItem = Instantiate(tickerItemPrefab, transform);
        currentItem.initialize(width, pixelsPerSecond, message);

        if(tickerItems.Count == 0) {
            tickerItems = new List<String>(tickerItemsSave);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentItem.GetXPosition <= 0 - width - currentItem.GetWidth)
        {
            AddTickerItem();
        }
    }


}
