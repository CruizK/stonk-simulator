using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockHandler : MonoBehaviour
{
    public StockManager StockManager;
    public StockPopup StockPopup;


    public int StockNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void HandleClicked()
    {
        StockPopup.OpenPopup(StockManager.Stocks[StockNumber]);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
