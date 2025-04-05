using System.Diagnostics;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerManager : MonoBehaviour
{
    public InputField ipInputField;

    public void StartHost()
    {
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.SetConnectionData("0.0.0.0", 7777); // Listen on all network interfaces
        NetworkManager.Singleton.StartHost();
        UnityEngine.Debug.Log("Started as Host");
    }

    public void StartClient()
    {
        string ip = ipInputField != null ? ipInputField.text : "127.0.0.1";
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.SetConnectionData(ip, 7777);
        NetworkManager.Singleton.StartClient();
        UnityEngine.Debug.Log("Started as Client, connecting to: " + ip);
    }

    public void StartServer()
    {
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.SetConnectionData("0.0.0.0", 7777);
        NetworkManager.Singleton.StartServer();
        UnityEngine.Debug.Log("Started as Server");
    }
}
