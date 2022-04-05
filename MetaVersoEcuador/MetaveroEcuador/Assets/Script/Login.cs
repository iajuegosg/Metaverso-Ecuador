using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "login", menuName = "Configuracion", order = 1)]
public class Login : ScriptableObject
{
    public bool recuerdame;
    public string nickName;
    public string correo;
    public string contraseña;

}
