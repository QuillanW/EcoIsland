using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinsCounter;
    public Image scoreFill;

    PlayerData playerData;

    public static UIManager instance;

    private void Start()
    {
        instance = this;
        playerData = GetComponent<PlayerData>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinsCounter.text = "Coins: " + playerData.coins.ToString();

        float scorePrecentage = playerData.score * 1f / (playerData.maxScore * 1f);

        scoreFill.fillAmount = scorePrecentage;
    }
}
