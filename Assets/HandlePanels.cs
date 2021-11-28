using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePanels : MonoBehaviour
{
    public GameObject upgradesPanel;
    public GameObject perksPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickPanel(int index)
    {
        if(index == 0)
        {
            upgradesPanel.SetActive(true);
            perksPanel.SetActive(false);
        }

        if (index == 1)
        {
            upgradesPanel.SetActive(false);
            perksPanel.SetActive(true);
        }
    }
}
