using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    [SyncVar]
    public int Money = 100000;

    public RoundNetworking RoundManager;
    public SyncListInt StockCounts = new SyncListInt();

    public delegate void MoneyChange(int money);
    [SyncEvent]
    public event MoneyChange EventOnMoneyChange;



    void Start()
    {
        if(isServer)
        {
            RoundManager = FindObjectOfType<RoundNetworking>();
        }

        if(isLocalPlayer)
        {
            CmdIncreaseMoney(1000000);
            CmdSetupStockList();

            GameObject.Find("EndTrading").GetComponent<Button>().onClick.AddListener(CmdEndRound);
        }
            
    }
    [Command]
    public void CmdIncreaseMoney(int amount)
    {
        Debug.Log("Server::" + Money.ToString());
        Money += amount;
        EventOnMoneyChange(Money);
    }

    [Command]
    public void CmdChangeStock(int index, int count)
    {
        StockCounts[index] += count;
    }

    [Command]
    public void CmdSetupStockList()
    {
        for(int i = 0; i < 6; i++)
        {
            StockCounts.Add(0);
        }
    }

    [Command]
    void CmdEndRound()
    {
        RoundManager.CmdEndRound();
    }

    public void PurchaseStock(Stock stock, int count)
    {
        CmdIncreaseMoney(-stock.Cost * count);
        CmdChangeStock(stock.Index, count);
        //Money -= stock.Cost * count;
        //StockCounts[stock.Index] += count;

        // Send Command to purchase stock for this player instance of stock type and of this count

        //OnMoneyChange(Money);
        //OnStockCountChange(stock, StockCounts[stock.Index]);
    }

    public void SellStock(Stock stock, int count)
    {
        CmdIncreaseMoney(stock.Cost * count);
        CmdChangeStock(stock.Index, -count);

        //OnMoneyChange(Money);
        //OnStockCountChange(stock, StockCounts[stock.Index]);
    }

    public int GetStockCount(int stockIndex)
    {
        return StockCounts[stockIndex];
    }
}
