using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    bool menuActive = false;

    private void Start()
    {
        transform.position = new Vector3(25, -500, 0);
    }

    public void ToggleMenu()
    {
        if (menuActive)
        {
            transform.position = new Vector3(25, -500, 0);
        }
        else
        {
            transform.position = new Vector3(25, 25, 0);
        }
        menuActive = !menuActive;
    }
}
