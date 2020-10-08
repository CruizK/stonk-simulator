using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


[RequireComponent(typeof(PlayerManager))]
public class PlayerNetworking : NetworkBehaviour
{
    public Behaviour[] BehaviorsToDisable;

    public PlayerHandler PlayerHandler;
    public OtherPlayersHandler OtherPlayerHandler;
    public RoundNetworking RoundManager;

    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer)
        {
            foreach(Behaviour behaviour in BehaviorsToDisable)
            {
                behaviour.enabled = false;
            }
        }

        Debug.Log("Is this the local player: " + isLocalPlayer.ToString());
        Debug.Log("Is this a client " + isClient.ToString());
        RoundManager = FindObjectOfType<RoundNetworking>();
        if (isLocalPlayer)
        {
            PlayerHandler = FindObjectOfType<PlayerHandler>();
            PlayerHandler.SetPlayer(GetComponent<PlayerManager>());
        }
        else if(isClient)
        {
            OtherPlayerHandler = FindObjectOfType<OtherPlayersHandler>();
            OtherPlayerHandler.AddPlayer(GetComponent<PlayerManager>());
        }

        
    }

    void OnDestroy()
    {
        Debug.Log("TEST");
        if(isClient && !isLocalPlayer)
        {
            Debug.Log("DESTORY IT, CAST IT INTO THE FIRE");

            OtherPlayerHandler.RemovePlayer(GetComponent<PlayerManager>());
        }
        
    }
    

    public override void OnStartClient()
    {
        base.OnStartClient();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
