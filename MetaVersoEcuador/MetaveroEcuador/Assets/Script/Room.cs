using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviourPunCallbacks
{
    RoomOptions roomOption = new RoomOptions();
    public string[] escenas;
    public Text cantidad;
    public int x;
    //public PostCam pistaSeleccionada;
    public float timer;
    public void CreateRoom()
    {
        roomOption.MaxPlayers = 100;
        roomOption.PlayerTtl = -1;
        roomOption.CleanupCacheOnLeave = false;
        PhotonNetwork.CreateRoom(null, roomOption, null);

    }
    public void QuickMatch()
    {
        PhotonNetwork.JoinRandomRoom();
        print("unidos");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
        print("creando");
    }
    public override void OnJoinedRoom()
    {
        CancelInvoke();
        roomOption.IsVisible = true;
        roomOption.IsOpen = true;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(escenas[x]);
        /*if (PhotonNetwork.PlayerList.Length==2)
        {
            CancelInvoke();
            roomOption.IsVisible = false;
            roomOption.IsOpen = false;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.LoadLevel(escenas[x]);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer>=2)
            {
                roomOption.IsVisible = false;
                roomOption.IsOpen = false;
                SceneManager.LoadScene("AceleracionFinalOffLine");
                //SceneManager.LoadScene("")
            }

            Invoke("OnJoinedRoom", 0.15f);
        }*/
       //PhotonNetwork.LoadLevel("AceleracionFinal");

    }



    private void Update()
    {
        //x = pistaSeleccionada.y;
        print(x);
    }
}
