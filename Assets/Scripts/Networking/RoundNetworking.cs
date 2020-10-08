using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class RoundNetworking : NetworkBehaviour
{
    public enum ROUND_STATE
    {
        TRADING,
        ROLLING
    }

    public StockRollingPopup StockRollingPopup;
    
    private StockManager StockManager;

    [SyncVar]
    public ROUND_STATE CurrentState = ROUND_STATE.TRADING;

    [SyncVar]
    public int ReadyForNextRound;

    private Button nextRoundBtn;

    // Start is called before the first frame update
    void Start()
    {
        StockManager = FindObjectOfType<StockManager>();
    }


    [Server]
    public void CmdEndRound()
    {
        ReadyForNextRound++;
        Debug.Log(ReadyForNextRound);
        // All players are ready
        if(ReadyForNextRound >= NetworkServer.connections.Count)
        {
            int[] stockChanges = new int[StockManager.Stocks.Length];
            for(int i = 0; i < StockManager.Stocks.Length; i++)
            {
                // Start rolling baby;
                float random = Random.value;
                int amount = Mathf.RoundToInt(Random.Range(5, 50));

                if (random <= 0.9f)
                {
                    stockChanges[i] = amount;
                }
                else
                {
                    stockChanges[i] = -amount;
                }
            }

            RpcSendRolls(stockChanges);
            ReadyForNextRound = 0;
        }
    }

    [ClientRpc]
    public void RpcSendRolls(int[] rolls)
    {
        StockRollingPopup.RollStocks(rolls);
    }
}
