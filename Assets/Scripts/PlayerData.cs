using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int coins = 0;
    public int score = 0;
    public int maxScore = 1000;

    UIManager UImanager;

    private void Start()
    {
        UImanager = GetComponent<UIManager>();
    }

    public void UpdateData(int Coins, int Score)
    {
        coins += Coins;
        score += Score;

        UImanager.UpdateUI();
    }
}
