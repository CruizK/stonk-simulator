using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[System.Serializable]
public class Player 
{

    public int Money;
    public int[] StockCounts;

    public Player()
    {
        Money = 1000000;
        StockCounts = new int[6];
    }
}

public class SyncListPlayers : SyncList<Player> { }