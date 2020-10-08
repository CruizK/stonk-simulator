using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OtherPlayersHandler : MonoBehaviour
{
    //List<PlayerManager> players;
    public GameObject OtherPlayerPrefab;

    private Dictionary<PlayerManager, GameObject> otherPlayerPairs;

    // Start is called before the first frame update
    void Start()
    {
        otherPlayerPairs = new Dictionary<PlayerManager, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer(PlayerManager player)
    {
        GameObject go = Instantiate(OtherPlayerPrefab, transform);

        OtherPlayerUpdateUI update = go.GetComponent<OtherPlayerUpdateUI>();
        update.HandleMoneyUpdate(player.Money);
        player.EventOnMoneyChange += update.HandleMoneyUpdate;
        player.StockCounts.Callback += update.HandleStockUpdate;

        otherPlayerPairs.Add(player, go);
    }

    public void RemovePlayer(PlayerManager player)
    {
        Destroy(otherPlayerPairs[player]);
    }
}
