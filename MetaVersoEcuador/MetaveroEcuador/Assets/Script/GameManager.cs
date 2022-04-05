using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
//using Newtonsoft.Json;
public class GameManager : MonoBehaviour
{
    public TMP_InputField nickname;
    public TMP_InputField correo;
    public TMP_InputField contrase�a;
    public Toggle recuerdame;
    public Login loginScr;
    public PlayFabLogin playFabLogin;
    public void Awake()
    {
        recuerdame.isOn = loginScr.recuerdame;
    }
    public void Start()
    {
        playFabLogin = GetComponent<PlayFabLogin>();

        if (loginScr.recuerdame == true)
        {
            nickname.text = loginScr.nickName;
            correo.text = loginScr.correo;
            contrase�a.text = loginScr.contrase�a;
        }
        else
        {
            nickname.text = null;
            correo.text = null;
            contrase�a.text = null;
        }
    }
    void Update()
    {
        loginScr.recuerdame = recuerdame.isOn;
        if (loginScr.recuerdame == true)
        {
            InicioSecion();

        }
    }

    public void InicioSecion()
    {
        loginScr.nickName = nickname.text;
        loginScr.correo = correo.text;
        loginScr.contrase�a = contrase�a.text;

        //aniPanel.SetBool("Panel", true);
        //StartCoroutine("CargaEscena");
    }

}
