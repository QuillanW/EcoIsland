using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI price;
    public TextMeshProUGUI level;

    public void Setup(Item item)
    {
        name.text = item.name;
        price.text = "Cost: " + item.price.ToString();
        level.text = "Unlocked at: " + item.level.ToString();
    }
}
