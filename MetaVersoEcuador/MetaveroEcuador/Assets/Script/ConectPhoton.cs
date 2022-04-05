using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConectPhoton : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("conectando al master");
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()//al comenzar se une a un lobby antes de iniciar cualquier otra funcion
    {
        print("conectado al master");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        print("te uniste al lobby");
    }
}
