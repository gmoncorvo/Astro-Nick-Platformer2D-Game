using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moncrow.Singleton;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        UIInGameManager.UpdateTextCoins(coins.ToString());
    }
}
