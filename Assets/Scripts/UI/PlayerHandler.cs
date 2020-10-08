using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class PlayerHandler : MonoBehaviour
{

    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI[] StockCounters;

    public PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerManager.OnMoneyChange += HandleMoneyChange;
        //PlayerManager.OnStockCountChange += HandleStockCountChange;

        //Debug.Log(PlayerManager.Money);
    }

    public void SetPlayer(PlayerManager player)
    {
        this.player = player;

        MoneyText.text = player.Money.ToString();
        player.EventOnMoneyChange += HandleMoneyChange;
        player.StockCounts.Callback += ChangeStockCount;
    }

    public void IncreaseMoney(int amount)
    {
        player.CmdIncreaseMoney(amount);
    }

    public void IncreaseStock(int index)
    {
        player.CmdChangeStock(index, 50);
    }

    public void ChangeStockCount(SyncListInt.Operation op, int index, int oldItem, int newItem)
    {
        StockCounters[index].text = newItem.ToString();
    }

    void HandleMoneyChange(int money)
    {
        Debug.Log("Updating Text");
        MoneyText.text = money.ToString();
    }
}
