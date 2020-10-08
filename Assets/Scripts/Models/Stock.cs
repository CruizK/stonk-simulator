using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock
{
    public int Index { get; private set; }
    public int Cost;
    public string Name { get; private set; }

    public Sprite Sprite { get; private set; }

    public delegate void CostChange(int index, int cost);
    public event CostChange OnCostChange;

    public Stock(int index, string name, Sprite sprite)
    {
        Index = index;
        Name = name;
        Sprite = sprite;
        Cost = 1000;
    }

    public void ModifyCost(float percent)
    {
        Cost += Mathf.RoundToInt(Cost * percent);
        //OnCostChange(Index, Cost);
    }
}
