using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockRollingPopup : MonoBehaviour
{
    public TextMeshProUGUI StockName;
    public TextMeshProUGUI OriginalPrice;
    public TextMeshProUGUI PriceChange;
    public TextMeshProUGUI NewPrice;
    public Image StockImage;

    public StockManager StockManager;

    // Start is called before the first frame update
    void Awake()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void RollStocks(int[] rolls)
    {
        gameObject.SetActive(true);
        Debug.Log(rolls.Length);
        StartCoroutine(Roll(rolls));
    }

    IEnumerator Roll(int[] rolls)
    {
        
        for(int i = 0; i < rolls.Length; i++)
        {
            Debug.Log(StockManager.Stocks);
            Stock stock = StockManager.Stocks[i];
            int amount = rolls[i];
            StockName.text = stock.Name;
            StockImage.sprite = stock.Sprite;

            OriginalPrice.text = "Original: " + stock.Cost.ToString();

            stock.ModifyCost(amount / 100.0f);

            string prefix = amount > 0 ? "▲" : "▼";

            PriceChange.color = amount > 0 ? Color.green : Color.red;
            PriceChange.text = "Change: " + prefix + Mathf.Abs(amount).ToString() + "%";

            NewPrice.color = amount > 0 ? Color.green : Color.red;
            NewPrice.text = "New: " + stock.Cost.ToString();

            yield return new WaitForSeconds(3.0f);
        }

        gameObject.SetActive(false);
    }
}
