using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonInstancia : MonoBehaviour
{
    public GameObject puntoInstancia;

    // Start is called before the first frame update
    private void Awake()
    {
        PhotonNetwork.Instantiate("BreathingIdleInst (1)", puntoInstancia.transform.position, Quaternion.identity);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
