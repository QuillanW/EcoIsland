using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int coins = 0;
    public int score = 0;
    public int maxScore = 1000;


    public static PlayerData instance;

    private void Start()
    {
        instance = this;
    }

    public void UpdateData(int Coins, int Score)
    {
        coins += Coins;
        score += Score;

        UIManager.instance.UpdateUI();
    }
}