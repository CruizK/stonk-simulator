using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockPopup : MonoBehaviour 
{
    public TextMeshProUGUI StockName;
    public TextMeshProUGUI StockCost;
    public TextMeshProUGUI StockSubmit;
    public TextMeshProUGUI StockAction;
    public PlayerHandler PlayerHandler;
    public Image StockImage;

    public enum STOCK_ACTIONS
    {
        BUYING,
        SELLING,
        INVESTING
    }

    private Slider StockSlider;
    private TMP_InputField StockInput;
    private Stock selectedStock = null;

    private STOCK_ACTIONS currentAction = STOCK_ACTIONS.BUYING;

    // Start is called before the first frame update
    void Awake()
    {
        StockInput = GetComponentInChildren<TMP_InputField>();
        StockSlider = GetComponentInChildren<Slider>();
        StockSlider.value = 0;
        StockInput.text = StockSlider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void HandleSliderChange(float value)
    {
        Debug.Log("Changing slider");
        StockInput.text = value.ToString();
        if (selectedStock != null)
        {
            if(currentAction == STOCK_ACTIONS.BUYING)
            {
                StockCost.color = Color.red;
                StockCost.text = "-" + (StockSlider.value * selectedStock.Cost).ToString();
            }
            else if(currentAction == STOCK_ACTIONS.SELLING)
            {
                StockCost.color = Color.green;
                StockCost.text = "+" + (StockSlider.value * selectedStock.Cost).ToString();
            }
        }
    }

    public void HandleEndEdit(string val)
    {
        StockSlider.value = int.Parse(StockInput.text);
    }

    public void OpenPopup(Stock stock)
    {
        Debug.Log("Opened Popup");
        gameObject.SetActive(true);
        StockSlider.value = 0;
        selectedStock = stock;
        SwitchAction(STOCK_ACTIONS.BUYING);
    }

    public void ActionToBuy()
    {
        SwitchAction(STOCK_ACTIONS.BUYING);
    }

    public void ActionToSell()
    {
        SwitchAction(STOCK_ACTIONS.SELLING);
    }

    public void ActionToInvesting()
    {
        SwitchAction(STOCK_ACTIONS.INVESTING);
    }

    private void SwitchAction(STOCK_ACTIONS action)
    {
        currentAction = action;
        StockSlider.value = 0;
        StockName.text = selectedStock.Name;
        StockImage.sprite = selectedStock.Sprite;
        if (action == STOCK_ACTIONS.BUYING)
        {
            StockSlider.maxValue = PlayerHandler.player.Money / selectedStock.Cost;
            StockAction.text = "Buying @" + selectedStock.Cost + " Per Share";
            StockCost.color = Color.red;
            StockCost.text = "-" + (StockSlider.value * selectedStock.Cost).ToString();
        }
        else if(action == STOCK_ACTIONS.SELLING)
        {
            StockSlider.maxValue = PlayerHandler.player.GetStockCount(selectedStock.Index);
            StockAction.text = "Selling @" + selectedStock.Cost + " Per Share";
            StockCost.color = Color.green;
            StockCost.text = "+" + (StockSlider.value * selectedStock.Cost).ToString();
        }
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }

    public void SubmitPopup()
    {
        if(currentAction == STOCK_ACTIONS.BUYING)
        {
            PlayerHandler.player.PurchaseStock(selectedStock, (int)StockSlider.value);
        }
        else if(currentAction == STOCK_ACTIONS.SELLING)
        {
            PlayerHandler.player.SellStock(selectedStock, (int)StockSlider.value);
        }

        gameObject.SetActive(false);
    }
}
