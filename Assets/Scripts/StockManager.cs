using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StockManager : MonoBehaviour
{
 
    
    public Stock[] Stocks { get; private set; }
    public Sprite[] StockSprites;

    
    // Start is called before the first frame update
    void Start()
    {
        Stocks = new Stock[6];

        Stocks[0] = new Stock(0, "Tech", StockSprites[0]);
        Stocks[1] = new Stock(1, "Industry", StockSprites[1]);
        Stocks[2] = new Stock(2, "Health", StockSprites[2]);
        Stocks[3] = new Stock(3, "Insurance", StockSprites[3]);
        Stocks[4] = new Stock(4, "Entertainment", StockSprites[4]);
        Stocks[5] = new Stock(5, "Transit", StockSprites[5]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
