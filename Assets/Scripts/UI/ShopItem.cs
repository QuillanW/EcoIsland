using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI priceLabel;
    public TextMeshProUGUI levelLabel;
    public Button interactionButton;

    public void Setup(Item item)
    {
        nameLabel.text = item.name;
        priceLabel.text = "Cost: " + item.price.ToString();
        levelLabel.text = "Unlocked at: " + item.level.ToString();
        interactionButton.onClick.AddListener(delegate { BuildMode.instance.EnterBuildMode(item); });
    }
}
