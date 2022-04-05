using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayFabLogin : MonoBehaviour
{
    public TMP_Text TEXT;
    public GameManager gameManager;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        /*fondoInicio = GameObject.Find("Login/PanelInicio").GetComponent<Animator>();
        if (gameManager.recuerdame)
        { 
            BotonLogin();
        }
        else
        {
            fondoInicio.SetBool("Panel", false);
        }*/
    }
    public void InicioSeccionAnonimo()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Cambie el titleId a continuación a su propio titleId de PlayFab Game Manager.
            Si ya ha establecido el valor en las extensiones del editor, puede omitirlo.
            */
            PlayFabSettings.staticSettings.TitleId = "42";
        }
#if UNITY_ANDROID
        var androidRequest = new LoginWithAndroidDeviceIDRequest
        {
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithAndroidDeviceID(androidRequest, OnLoginSuccess, OnLoginFailure);
#else
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }
#endif
    
    public void BotonRegistro() 
    {
        if (gameManager.contraseña.text.Length<6)
        {
            TEXT.text = ("contraseña muy corta");
        }
        var request = new RegisterPlayFabUserRequest
        {
            //Username=gameManager.nickname.text,
            Email = gameManager.correo.text,
            Password = gameManager.contraseña.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, RegistroOK, OnLoginFailure);
    }
    public void BotonLogin()
    {
        LoginWithEmailAddressRequest request = new LoginWithEmailAddressRequest
        {
            Email = gameManager.correo.text,
            Password = gameManager.contraseña.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    public void BotonResetPassword()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = gameManager.correo.text,
            TitleId = "B15C2"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, ResetContraseña, OnLoginFailure);
    }

    private void ResetContraseña(SendAccountRecoveryEmailResult result)
    {
        TEXT.text = "contraseña enviada al correo";
    }

    public void RegistroOK(RegisterPlayFabUserResult result)
    {
        TEXT.text=("BIENVENIDO");
        
    }
    public void OnLoginSuccess(LoginResult result)
    {
        TEXT.text = ("Congratulations, you made your first successful API call!");
        //fondoInicio.SetBool("Panel", false);
        StartCoroutine("LoadScena");
    }
    public void OnLoginFailure(PlayFabError error)
    {
        TEXT.text = ("Something went wrong with your first API call.  :(");
        TEXT.text = ("Here's some debug information:");
        Debug.Log(error.GenerateErrorReport());
        TEXT.text = (error.GenerateErrorReport());
    }
    IEnumerator LoadScena()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("SeleccionPersonaje");
    }
    
}
