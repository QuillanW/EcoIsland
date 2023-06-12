using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSystem : MonoBehaviour
{
    private void Start()
    {
        foreach (Transform tab in transform)
        {
            tab.gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OpenTab(string tabName)
    {
        foreach (Transform tab in transform)
        {
            tab.gameObject.SetActive(tab.name == tabName);
        }
    }
}
