using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class OtherPlayerUpdateUI : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI[] StockCounters;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleMoneyUpdate(int money)
    {
        MoneyText.text = money.ToString();
    }

    public void HandleStockUpdate(SyncListInt.Operation op, int index, int oldCount, int newCount)
    {
        StockCounters[index].text = newCount.ToString();
    }

    public void HandleDestory()
    {
        Destroy(this);
    }
}
