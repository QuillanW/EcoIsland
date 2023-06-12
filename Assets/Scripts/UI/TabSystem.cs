using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSystem : MonoBehaviour
{

    public void OpenTab(string tabName)
    {
        foreach (Transform tab in transform)
        {
            tab.gameObject.SetActive(tab.name == tabName);
        }
    }
}
