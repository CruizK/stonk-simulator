using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class NetworkManagerServer : NetworkManager
{
    // Start is called before the first frame update
    void Start()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        bool isServer = false;
        for(int i = 0; i < args.Length; i++)
        {
            Debug.Log(args[i]);
            if (args[i] == "-stonkserver")
            {
                isServer = true;
            }

            if(args[i] == "-stonkaddr")
            {
                networkAddress = args[i + 1];
            }
        }

        if(isServer)
        {
            StartServer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
