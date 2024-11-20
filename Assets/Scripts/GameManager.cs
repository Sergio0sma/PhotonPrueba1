using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //Cogemos la configuracion del servidor
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room1",new Photon.Realtime.RoomOptions { MaxPlayers=2},null); //Crea o se une a una sala
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player",Vector3.zero,Quaternion.identity);
    }
}
